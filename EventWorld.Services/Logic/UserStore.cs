using EventWorld.Data.Infrastructure;
using EventWorld.DTO;
using EventWorld.Services.Services.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EventWorld.Services.Logic
{
    public class UserStore : IUserStore<UserDTO>, IUserPasswordStore<UserDTO>, IUserEmailStore<UserDTO>
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;

        public UserStore(IUserService userService, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
        }

        public Task<IdentityResult> CreateAsync(UserDTO user, CancellationToken cancellationToken)
        {
            _userService.Add(user);
            return Task.FromResult(IdentityResult.Success);
        }

        public Task<IdentityResult> DeleteAsync(UserDTO user, CancellationToken cancellationToken)
        {
            _userService.Delete(user);
            return Task.FromResult(IdentityResult.Success);
        }

        public void Dispose()
        {
        }

        public Task<UserDTO> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
        {
            var userEntity = _userService.GetByEmail(normalizedEmail);
            if (userEntity == null)
                return Task.FromResult<UserDTO>(null);
            return Task.FromResult(userEntity);
        }

        public Task<UserDTO> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            var userEntity = _userService.GetById(Convert.ToInt64(userId));
            if (userEntity == null)
                return Task.FromResult<UserDTO>(null);
            return Task.FromResult(userEntity);
        }

        public Task<UserDTO> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            return Task.FromResult(new UserDTO());
        }

        public Task<string> GetEmailAsync(UserDTO user, CancellationToken cancellationToken)
        => Task.FromResult(user.Email);

        public Task<bool> GetEmailConfirmedAsync(UserDTO user, CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }

        public Task<string> GetNormalizedEmailAsync(UserDTO user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Email);
        }

        public Task<string> GetNormalizedUserNameAsync(UserDTO user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Email);
        }

        public Task<string> GetPasswordHashAsync(UserDTO user, CancellationToken cancellationToken)
            => Task.FromResult(user.Password);

        public Task<long> GetUserIdAsync(UserDTO user, CancellationToken cancellationToken)
            => Task.FromResult(user.Id);

        public Task<string> GetUserNameAsync(UserDTO user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Email);
        }

        public Task<bool> HasPasswordAsync(UserDTO user, CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }

        public Task SetEmailAsync(UserDTO user, string email, CancellationToken cancellationToken)
        {
            user.Email = email;
            return Task.CompletedTask;
        }

        public Task SetEmailConfirmedAsync(UserDTO user, bool confirmed, CancellationToken cancellationToken)
        {
            return Task.FromResult(new UserDTO());
        }

        public Task SetNormalizedEmailAsync(UserDTO user, string normalizedEmail, CancellationToken cancellationToken)
        {
            return Task.FromResult(new UserDTO());
        }

        public Task SetNormalizedUserNameAsync(UserDTO user, string normalizedName, CancellationToken cancellationToken)
        {
            return Task.FromResult(new UserDTO());
        }

        public Task SetPasswordHashAsync(UserDTO user, string passwordHash, CancellationToken cancellationToken)
        {
            user.Password = passwordHash;
            return Task.CompletedTask;
        }

        public Task SetUserNameAsync(UserDTO user, string userName, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task<IdentityResult> UpdateAsync(UserDTO user, CancellationToken cancellationToken)
        {
            return Task.FromResult(new IdentityResult());
        }

        Task<string> IUserStore<UserDTO>.GetUserIdAsync(UserDTO user, CancellationToken cancellationToken)
        => Task.FromResult(user.Id.ToString());
    }
}
