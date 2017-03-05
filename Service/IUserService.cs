namespace WebAPICore.Service
{
    using System.Collections.Generic;
    using WebAPICore.Models;

    public interface IUserService
    {
         void UpdatePassword(ChangePasswordModel modelPassword);

         void Create(UserModel user);

         IList<UserModel> GetAllUsersModel();

         UserModel GetUserById(int id);
    }
}