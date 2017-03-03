namespace WebAPICore.Data.Repositories
{
    using System.Linq;
    using System.Collections.Generic;

    public class UserRepository : IUserRepository
    {
        DataBaseContext _dataContext;

        public UserRepository(DataBaseContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Create(User user)
        {
            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();
        }

        public IList<User> ReadAll()
        {
            return _dataContext.Users.ToList();
        }

        public User Read(int id)
        {
            return _dataContext.Users.Find(id);
        }

        public void Update(User user)
        {
            _dataContext.Users.Update(user);
            _dataContext.SaveChanges();
        }

        public void Delete(int id)
        {
            User user = _dataContext.Users.FirstOrDefault(userDB => userDB.Id == id);
            if(user != null)
            {
                _dataContext.Users.Remove(user);
                _dataContext.SaveChanges();
            }
        }
    }
}