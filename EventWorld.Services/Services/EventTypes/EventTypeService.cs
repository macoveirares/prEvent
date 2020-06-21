using EventWorld.Data.Entities;
using EventWorld.Data.Infrastructure;
using EventWorld.DTO;
using Omu.ValueInjecter;
using System.Collections.Generic;
using System.Linq;

namespace EventWorld.Services.Services.EventTypes
{
    public interface IEventTypeService
    {
        List<EventTypeDTO> GetEventTypes();
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
    }
}
