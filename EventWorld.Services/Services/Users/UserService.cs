using EventWorld.Data.Entities;
using EventWorld.Data.Infrastructure;
using EventWorld.DTO;
using Omu.ValueInjecter;
using System.Linq;

namespace EventWorld.Services.Services.Users
{
    public interface IUserService
    {
        void Add(UserDTO userDTO);
        void Delete(UserDTO userDTO);
        UserDTO GetByID(long id);
        UserDTO GetByEmail(string email);
    }

    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IRepository<User> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
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
            _repository.Delete(userToDelete);
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

        public UserDTO GetByID(long id)
        {
            var user = _repository.GetById(id);
            if (user != null)
            {
                return (UserDTO)new UserDTO().InjectFrom(user);
            }
            return null;
        }
    }
}
