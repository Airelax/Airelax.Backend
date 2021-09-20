using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Airelax.Application.Messages.Response;
using Airelax.Application.Messages;
using Airelax.Application.Messages.Request;

namespace Airelax.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;
        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        [Route("{memberId}")]
        public async Task<List<MessageDto>> Get(string memberId)
        {
            return await _messageService.GetMessage(memberId);
        }

        [HttpPut]
        [Route("{memberId}/content")]
        public IActionResult UpdateContent(string memberId, MessageInupt messageInupt)
        {
            var message = _messageService.UpdateContent(memberId, messageInupt);
            return Ok(message);
        }

        [HttpPost]
        [Route("{memberId}/create")]
        public IActionResult CreateContent(string memberId, CreateMessageInput messageInupt)
        {
            var message = _messageService.CreateContent(memberId, messageInupt);
            return Ok(message);
        }

        [HttpPut]
        [Route("{memberId}/status")]
        public IActionResult UpdateStatus(string memberId, UpdateStatusInput statusInupt)
        {
            var message = _messageService.UpdateStatus(memberId, statusInupt);
            return Ok(message);
        }

        [HttpPut]
        [Route("{memberId}/ontime")]
        public IActionResult UpdateOnTime(string memberId, UpdateStatusInput statusInupt)
        {
            var message = _messageService.UpdateOnTime(memberId, statusInupt);
            return Ok(message);
        }
    }
}
