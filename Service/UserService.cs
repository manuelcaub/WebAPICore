namespace WebAPICore.Service
{
    using System.Collections.Generic;
    using WebAPICore.Models;
    using WebAPICore.Data;
    using WebAPICore.Data.Repositories;

    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Create(UserModel user)
        {
            _userRepository.Create(new User
            {
                Email = user.Email,
                Password = user.Password
            });
        }

        public IList<UserModel> GetAllUsersModel()
        {
            return _userRepository.GetAllUsersModel();
        }

        public UserModel GetUserById(int id)
        {
            User user = _userRepository.Read(id);
            return new UserModel
            {
                Id = user.Id,
                Email = user.Email
            };
        }

        public void UpdatePassword(ChangePasswordModel modelPassword)
        {
            User user = _userRepository.GetByEmail(modelPassword.Email);
            if (user.Password == modelPassword.OldPassword)
            {
                user.Password = modelPassword.NewPassword;
                _userRepository.Update(user);
            }
        }
    }
}