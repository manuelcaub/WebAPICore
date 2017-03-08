namespace WebAPICore.Data.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByEmail(string email);
    }
}