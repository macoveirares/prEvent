using EventWorld.Data.Entities;
using EventWorld.Data.Infrastructure;
using EventWorld.DTO;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventWorld.Services.Services.EventTypes
{
    public interface IEventTypeService
    {
        List<EventTypeDTO> GetEventTypes();
        string GetImageForEvent(long id);
    }

    public class EventTypeService : IEventTypeService
    {
        private readonly IRepository<EventType> _repository;

        public EventTypeService(IRepository<EventType> repository)
        {
            _repository = repository;
        }

        public List<EventTypeDTO> GetEventTypes()
        {
            return _repository.GetAll().Select(x => (EventTypeDTO)new EventTypeDTO().InjectFrom(x)).ToList();
        }

        public string GetImageForEvent(long id)
        {
            var imagePath = _repository.Query().Where(x => x.Id == id).Select(x => x.ImagePath).FirstOrDefault();
            var images = imagePath.Split(';');
            var randomNumber = new Random().Next(0, 3);
            return images[randomNumber];
        }
    }
}
