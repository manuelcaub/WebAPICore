namespace WebAPICore.Service
{
    using WebAPICore.Models;

    public interface IUserService : IDbService
    {
         void UpdatePassword(ChangePasswordModel modelPassword);
    }
}