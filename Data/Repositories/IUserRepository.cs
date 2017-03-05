namespace WebAPICore.Data.Repositories
{
    using System.Collections.Generic;
    using WebAPICore.Models;

    public interface IUserRepository : IRepository<User>
    {
        IList<UserModel> GetAllUsersModel();

        User GetByEmail(string email);
    }
}