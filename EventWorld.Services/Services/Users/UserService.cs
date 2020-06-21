using EventWorld.Data.Entities;
using EventWorld.Data.Infrastructure;
using EventWorld.DTO;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventWorld.Services.Services.Users
{
    public interface IUserService
    {
        void Add(UserDTO userDTO);
        void Delete(UserDTO userDTO);
        void SaveFeedback(long eventId, long userId, int rating);
        UserDTO GetById(long id);
        UserDTO GetByEmail(string email);
        List<EventDTO> GetUserEnrolledEvents(long userId);
    }

    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;
        private readonly IRepository<EventGuest> _eventGuestRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IRepository<User> repository, IRepository<EventGuest> eventGuestRepository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _eventGuestRepository = eventGuestRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(UserDTO userDTO)
        {
            var userToAdd = (User)new User().InjectFrom(userDTO);
            _repository.Add(userToAdd);
            _unitOfWork.Commit();
        }

        public void Delete(UserDTO userDTO)
        {
            var userToDelete = _repository.GetById(userDTO.Id);
            userToDelete.Deleted = true;
            _unitOfWork.Commit();
        }

        public UserDTO GetByEmail(string email)
        {
            var user = _repository.Query().Where(x => x.Email == email).SingleOrDefault();
            if (user != null)
            {
                return (UserDTO)new UserDTO().InjectFrom(user);
            }
            return null;
        }

        public UserDTO GetById(long id)
        {
            var user = _repository.GetById(id);
            if (user != null)
            {
                return (UserDTO)new UserDTO().InjectFrom(user);
            }
            return null;
        }

        public List<EventDTO> GetUserEnrolledEvents(long userId)
        {
            var events = _eventGuestRepository.Query()
                .Where(x => !x.Deleted
                && x.IsApproved
                && x.UserId == userId
                && !x.ReceivedFeedback
                && x.Event.Date >= DateTime.Now)
                .Select(x => x.Event)
                .ToList();
            return events.Select(x => (EventDTO)new EventDTO().InjectFrom(x)).ToList();
        }

        public void SaveFeedback(long eventId, long userId, int rating)
        {
            var user = _repository.GetById(userId);
            user.Rating = user.Rating == 0 ? rating : (int)Math.Floor((double)((user.Rating + rating) / 2));
            var eventGuest = _eventGuestRepository.Query()
                .Where(x => x.EventId == eventId && x.UserId == userId && x.IsApproved && !x.Deleted && !x.ReceivedFeedback)
                .FirstOrDefault();
            eventGuest.ReceivedFeedback = true;
            _unitOfWork.Commit();
        }
    }
}
