using EventWorld.Data.Entities;
using EventWorld.Data.Infrastructure;
using EventWorld.DTO;
using Omu.ValueInjecter;
using System.Collections.Generic;
using System.Linq;

namespace EventWorld.Services.Services.Messages
{
    public interface IMessageService
    {
        MessageDTO AddMessage(MessageDTO messageDto);
        List<MessageDTO> GetEventMessages(long eventId);
    }

    public class MessageService : IMessageService
    {
        private readonly IRepository<Message> _repository;
        private readonly IUnitOfWork _unitOfWork;

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
    }
}
