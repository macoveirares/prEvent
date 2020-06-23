using EventWorld.Data.Entities;
using EventWorld.Data.Infrastructure;
using EventWorld.DTO;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventWorld.Services.Services.Messages
{
    public interface IMessageService
    {
        MessageDTO AddMessage(MessageDTO messageDto);
        List<MessageDTO> GetEventMessages(long eventId);
        List<int> GetMessagesCountByMonth();
    }

    public class MessageService : IMessageService
    {
        private readonly IRepository<Message> _repository;
        private readonly IUnitOfWork _unitOfWork;

        private Dictionary<string, int> MessagesCountPerMonth = new Dictionary<string, int>
        {
            { "1", 0 },
            { "2", 0 },
            { "3", 0 },
            { "4", 0 },
            { "5", 0 },
            { "6", 0 },
            { "7", 0 },
            { "8", 0 },
            { "9", 0 },
            { "10", 0 },
            { "11", 0 },
            { "12", 0 }
        };

        public MessageService(IRepository<Message> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public MessageDTO AddMessage(MessageDTO messageDto)
        {
            var message = (Message)new Message().InjectFrom(messageDto);
            _repository.Add(message);
            _unitOfWork.Commit();
            return (MessageDTO)new MessageDTO().InjectFrom(message);
        }

        public List<MessageDTO> GetEventMessages(long eventId)
        {
            var messages = _repository.Query()
                .Where(x => x.EventId == eventId)
                .ToList();
            return messages.Select(x =>
            {
                var messageDTO = (MessageDTO)new MessageDTO().InjectFrom(x);
                messageDTO.User = (UserDTO)new UserDTO().InjectFrom(x.User);
                return messageDTO;
            }).OrderByDescending(x => x.Date)
            .ToList();
        }

        public List<int> GetMessagesCountByMonth()
        {
            var currentYear = DateTime.Now.Year;
            var messagesCounts = _repository.Query()
                .Where(x => x.Date.Year == currentYear)
                .GroupBy(x => x.Date.Month)
                .Select(x => new { month = x.Key, count = x.Count() })
                .ToList();
            foreach (var messagesCount in messagesCounts)
            {
                MessagesCountPerMonth[messagesCount.month.ToString()] = messagesCount.count;
            }

            return MessagesCountPerMonth.Select(x => x.Value).ToList();
        }
    }
}
