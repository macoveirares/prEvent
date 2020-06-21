using EventWorld.Data.Entities;
using EventWorld.Data.Infrastructure;
using EventWorld.DTO;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventWorld.Services.Services.Events
{
    public interface IEventService
    {
        void AddEvent(EventDTO eventDTO);
        void DeleteEvent(long eventId);
        void ApproveEvent(long eventId);
        void ApproveEnrollment(long eventId, long userId);
        void RejectEnrollment(long eventId, long userId);
        void AttendEvent(long userId, long eventId);
        bool CheckIfUserAttendsEvent(long userId, long eventId);
        EventDTO GetById(long eventId);
        List<EventDTO> GetEvents(string searchTerm, long categoryId, int skip, int take);
        List<EventDTO> GetUserAttendedEvents(long userId);
        List<EventDTO> GetUserUpcomingEvents(long userId);
        List<EventDTO> GetEventsToApprove();
        List<UserDTO> GetEventAttendes(long id, bool isApproved);
    }

    public class EventService : IEventService
    {
        private readonly IRepository<Event> _repository;
        private readonly IRepository<EventGuest> _eventGuestRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EventService(IRepository<Event> repository, IRepository<EventGuest> eventGuestRepository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _eventGuestRepository = eventGuestRepository;
            _unitOfWork = unitOfWork;
        }

        public void AddEvent(EventDTO eventDTO)
        {
            var eventToAdd = (Event)new Event().InjectFrom(eventDTO);

            _repository.Add(eventToAdd);
            _unitOfWork.Commit();
        }

        public void DeleteEvent(long eventId)
        {
            var eventEntity = _repository.Query().Where(x => x.Id == eventId).FirstOrDefault();
            eventEntity.Deleted = true;
            _unitOfWork.Commit();
        }

        public void ApproveEvent(long eventId)
        {
            var eventEntity = _repository.Query().Where(x => x.Id == eventId).FirstOrDefault();
            eventEntity.IsApproved = true;
            _unitOfWork.Commit();
        }

        public bool CheckIfUserAttendsEvent(long userId, long eventId)
        {
            return _eventGuestRepository.Query().Any(x => x.UserId == userId
            && x.EventId == eventId
            && !x.Deleted);
        }

        public void AttendEvent(long userId, long eventId)
        {
            var eventGuest = new EventGuest
            {
                UserId = userId,
                EventId = eventId,
                IsApproved = false,
                Deleted = false
            };

            _eventGuestRepository.Add(eventGuest);
            _unitOfWork.Commit();
        }

        public EventDTO GetById(long eventId)
        {
            var eventEntity = _repository.GetById(eventId);
            var eventDto = (EventDTO)new EventDTO().InjectFrom(eventEntity);
            eventDto.EventType = (EventTypeDTO)new EventTypeDTO().InjectFrom(eventEntity.EventType);
            return eventDto;
        }

        public List<EventDTO> GetEvents(string searchTerm, long categoryId, int skip, int take)
        {
            var query = _repository.Query().Where(x => !x.Deleted && x.IsApproved && x.Date > DateTime.Now);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(x => x.Title.Contains(searchTerm) || x.Description.Contains(searchTerm));
            }

            if (categoryId > 0)
            {
                query = query.Where(x => x.EventTypeId == categoryId);
            }

            if (skip > 0)
            {
                query = query.Skip(skip);
            }

            var events = query.Take(take + 1).ToList();

            return events.Select(x =>
            {
                var eventDto = (EventDTO)new EventDTO().InjectFrom(x);
                eventDto.EventType = (EventTypeDTO)new EventTypeDTO().InjectFrom(x.EventType);
                return eventDto;
            }).ToList();
        }

        public List<EventDTO> GetEventsToApprove()
        {
            var eventsToApprove = _repository.Query().Where(x => !x.Deleted && !x.IsApproved).ToList();
            return eventsToApprove.Select(x =>
            {
                var eventDto = (EventDTO)new EventDTO().InjectFrom(x);
                eventDto.EventType = (EventTypeDTO)new EventTypeDTO().InjectFrom(x.EventType);
                return eventDto;
            }).ToList();
        }

        public List<EventDTO> GetUserAttendedEvents(long userId)
        {
            var lastMonthDate = DateTime.Now.AddDays(-30);
            var userAttendedEvents = _eventGuestRepository.Query()
                .Where(x => x.UserId == userId
            && !x.Event.Deleted
            && x.Event.IsApproved
            && !x.Deleted
            && x.Event.Date > lastMonthDate
            && x.Event.Date < DateTime.Now)
            .Select(x => x.Event)
            .OrderByDescending(x => x.Date)
            .Take(4)
            .ToList();
            return userAttendedEvents.Select(x =>
            {
                var eventDto = (EventDTO)new EventDTO().InjectFrom(x);
                eventDto.EventType = (EventTypeDTO)new EventTypeDTO().InjectFrom(x.EventType);
                return eventDto;
            }).ToList();
        }

        public List<EventDTO> GetUserUpcomingEvents(long userId)
        {
            var userEvents = _repository.Query()
                .Where(x => x.CreatorUserId == userId
            && !x.Deleted
            && x.IsApproved
            && x.Date > DateTime.Now)
            .OrderByDescending(x => x.Date)
            .Take(4)
            .ToList();

            return userEvents.Select(x =>
            {
                var eventDto = (EventDTO)new EventDTO().InjectFrom(x);
                eventDto.EventType = (EventTypeDTO)new EventTypeDTO().InjectFrom(x.EventType);
                return eventDto;
            }).ToList();
        }

        public List<UserDTO> GetEventAttendes(long id, bool isApproved)
        {
            var usersToAttend = _eventGuestRepository.Query()
                .Where(x => x.EventId == id && x.IsApproved == isApproved && !x.Deleted && !x.ReceivedFeedback)
                .Select(x => x.User)
                .ToList();
            return usersToAttend.Select(x => (UserDTO)new UserDTO().InjectFrom(x)).ToList();
        }

        public void ApproveEnrollment(long eventId, long userId)
        {
            var eventGuest = _eventGuestRepository.Query()
                .Where(x => x.EventId == eventId && x.UserId == userId && !x.IsApproved && !x.Deleted && !x.ReceivedFeedback)
                .FirstOrDefault();
            eventGuest.IsApproved = true;
            _unitOfWork.Commit();
        }

        public void RejectEnrollment(long eventId, long userId)
        {
            var eventGuest = _eventGuestRepository.Query()
                .Where(x => x.EventId == eventId && x.UserId == userId && !x.IsApproved && !x.Deleted && !x.ReceivedFeedback)
                .FirstOrDefault();
            eventGuest.Deleted = true;
            _unitOfWork.Commit();
        }
    }
}
