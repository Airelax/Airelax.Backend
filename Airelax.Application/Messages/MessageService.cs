using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Airelax.Application.Messages.Request;
using Airelax.Application.Messages.Response;
using Airelax.Domain.Messages;
using Airelax.Domain.RepositoryInterface;
using Airelax.EntityFramework.Repositories;
using Lazcat.Infrastructure.DependencyInjection;

namespace Airelax.Application.Messages
{
    [DependencyInjection(typeof(IMessageService))]
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IHouseRepository _houseRepository;
        private readonly IMemberRepository _memberRepository;
        public MessageService(IMessageRepository messageRepository, IHouseRepository houseRepository, IMemberRepository memberRepository)
        {
            _messageRepository = messageRepository;
            _houseRepository = houseRepository;
            _memberRepository = memberRepository;
        }

        public async Task<List<MessageDto>> GetMessage(string memberId)
        {
            var messages = _messageRepository.GetMessage(memberId);
            List<MessageDto> result = new List<MessageDto>();
            foreach (var item in messages)
            {
                var house = await _houseRepository.GetAsync(x => x.Id == item.HouseId);
                //兩種情況 - 查詢人是房東或房客
                var member = _memberRepository
                    .GetMemberInfoSearchObject(memberId == house.OwnerId ? (item.MemberOneId == memberId ? item.MemberTwoId : item.MemberOneId) : memberId);
                var owner = _memberRepository.GetMemberInfoSearchObject(house.OwnerId);
                result.Add(new MessageDto
                {
                    Id = item.Id,
                    ConnectString = $"{item.MemberOneId}-{item.MemberTwoId}",
                    MemberId = memberId,
                    GusetId = memberId == house.OwnerId ? item.MemberTwoId : item.MemberOneId,
                    Name = member.First().MemberName,
                    Portrait = member.First().Cover,
                    Pictures = house.Photos?.Select(x => x.Image) ?? new List<string>(),
                    MemberOneStatus = item.MemberOneStatus,
                    MemberTwoStatus = item.MemberTwoStatus,
                    Landlord = new LandlordDto
                    {
                        Id = house.OwnerId,
                        HouseId = house.Id,
                        Cover = owner.First().Cover,
                        Name = owner.First().MemberName
                    },
                    TourDetail = new TourDetailDto
                    {
                        StartDate = item.StartDate,
                        EndDate = item.EndDate,
                        Title = house.Title,
                        City = house.HouseLocation?.City,
                        Country = house.HouseLocation?.Country,
                        Town = house.HouseLocation?.Town
                    },
                    Communications = item.Contents.Select(x =>
                        new CommunicationDto
                        {
                            SenderId = x.SenderId,
                            ReceiverId = x.ReceiverId,
                            Content = x.Content,
                            Time = x.Time
                        }).ToList()
                    ,
                    Origin = house.HousePrice?.PerNight ?? 0,
                    PaymentDetail = new PaymentDetail
                    {
                        CleanFee = house.HousePrice?.Fee?.CleanFee??0,
                        ServiceFee = house.HousePrice?.Fee?.ServiceFee??0,
                        TaxFee = house.HousePrice?.Fee?.TaxFee??0,
                    }
                });
            }
            return result;
        }

        public bool UpdateContent(string id, MessageInupt input)
        {
            var message = _messageRepository.UpdateMessage(input.senderId, input.receiverId);
            //重要 signalR有時候會重複寫入資料
            if(message.Contents.Last().SenderId == input.senderId && message.Contents.Last().ReceiverId == input.receiverId && message.Contents.Last().Time == input.time && message.Contents.Last().Content == input.content) return true;
            message.Contents.Add(new MessageContent()
            {
                Content = input.content,
                SenderId = input.senderId,
                ReceiverId = input .receiverId,
                Time = input.time
            });
            Update(message);
            return true;
        }

        public bool UpdateStatus(string id, UpdateStatusInput input)
        {
            var message = _messageRepository.UpdateMessage(input.MemberId, input.OtherId);
            if (message.MemberOneId == input.MemberId) message.MemberOneStatus = 0;
            else message.MemberTwoStatus = 0;
            Update(message);
            return true;
        }

        public bool UpdateOnTime(string id, UpdateStatusInput input)
        
        {
            var message = _messageRepository.UpdateMessage(input.MemberId, input.OtherId);
            if (message.MemberOneId == input.MemberId) message.MemberTwoStatus += 1;
            else message.MemberOneStatus += 1;
            Update(message);
            return true;
        }

        public bool CreateContent(string id, CreateMessageInput input)
        {
            var message = _messageRepository.UpdateMessage(input.MemberOneId, input.MemberTwoId);
            if (message == null)
            {
                var createItem = new Message()
                {
                    MemberOneId = input.MemberOneId,
                    MemberTwoId = input.MemberTwoId,
                    EndDate = input.EndDate,
                    StartDate = input.StartDate,
                    HouseId = input.HouseId,
                    Contents = input.Contents,
                    MemberOneStatus = input.MemberOneStatus,
                    MemberTwoStatus = input.MemberTwoStatus
                };
                _messageRepository.CreateMessage().Add(createItem);
                _messageRepository.Create(createItem);
                _messageRepository.SaveChange();
            }
            else
            {
                var updateItem = new MessageInupt()
                {
                    content = input.Contents.FirstOrDefault().Content,
                    senderId = input.Contents.FirstOrDefault().SenderId,
                    receiverId = input.Contents.FirstOrDefault().ReceiverId,
                    time = input.Contents.FirstOrDefault().Time
                };
                var mes = _messageRepository.UpdateMessage(updateItem.senderId, updateItem.receiverId);
                mes.MemberOneStatus += input.MemberOneStatus;
                mes.Contents.Add(new MessageContent()
                {
                    Content = updateItem.content,
                    SenderId = updateItem.senderId,
                    ReceiverId = updateItem.receiverId,
                    Time = updateItem.time
                });
                Update(mes);
            }
            return true;
        }

        public void Update(Message message)
        {
            _messageRepository.Update(message);
            _messageRepository.SaveChange();
        }
    }
}
