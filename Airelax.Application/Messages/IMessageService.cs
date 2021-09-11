using System.Collections.Generic;
using System.Threading.Tasks;
using Airelax.Application.Messages.Request;
using Airelax.Application.Messages.Response;
using Airelax.Domain.Messages;

namespace Airelax.Application.Messages
{
    public interface IMessageService
    {
        Task<List<MessageDto>> GetMessage(string memberId);
        bool UpdateContent(string id, MessageInupt input);
        bool CreateContent(string id, CreateMessageInput input);
        void Update(Message message);
    }
}