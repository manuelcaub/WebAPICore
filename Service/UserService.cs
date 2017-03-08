namespace WebAPICore.Service
{
    using AutoMapper;
    using WebAPICore.Models;
    using WebAPICore.Data;
    using WebAPICore.Data.Repositories;

    public class UserService : AbstractDbService<User>, IUserService
    {
        private IUserRepository _userRepository;
        private IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _userRepository = repository;
            _mapper = mapper;
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