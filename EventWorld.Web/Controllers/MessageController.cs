using EventWorld.DTO;
using EventWorld.Services.Services.Messages;
using EventWorld.Web.Helpers;
using EventWorld.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Omu.ValueInjecter;
using System;
using System.Linq;
using System.Security.Claims;

namespace EventWorld.Web.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IActionResult Chat()
        {
            return View();
        }

        public JsonResult GetEventMessages(long eventId)
        {
            var messages = _messageService.GetEventMessages(eventId);
            var messageModels = messages.Select(x =>
            {
                var messageModel = (MessageModel)new MessageModel().InjectFrom(x);
                messageModel.Name = x.User.FirstName + ' ' + x.User.LastName;
                messageModel.Time = RelativeTimeHelper.CalculateRelativeTime(x.Date);
                return messageModel;
            }).ToList();
            return Json(messageModels);
        }

        [HttpPost]
        public JsonResult SendMessage(long eventId, string text)
        {
            var messageDto = new MessageDTO
            {
                EventId = eventId,
                UserId = Convert.ToInt64(HttpContext.User.FindFirstValue("Id")),
                Text = text,
                Date = DateTime.Now
            };

            var message = _messageService.AddMessage(messageDto);
            var messageModel = (MessageModel)new MessageModel().InjectFrom(message);
            messageModel.Name = HttpContext.User.FindFirstValue("FirstName") + ' ' + HttpContext.User.FindFirstValue("LastName");
            messageModel.Time = "now";
            return Json(messageModel);
        }
    }
}