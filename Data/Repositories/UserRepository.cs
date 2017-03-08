namespace WebAPICore.Data.Repositories
{
    using System.Linq;
    using System.Collections.Generic;
    using System;

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

        public User Read(ulong id)
        {
            return _dataContext.Users.Find(id);
        }

        public void Update(User user)
        {
            _dataContext.Users.Update(user);
            _dataContext.SaveChanges();
        }

        public void Delete(User user)
        {
            if(user != null)
            {
                _dataContext.Users.Remove(user);
                _dataContext.SaveChanges();
            }
        }

        public IList<TResult> GetAll<TResult>(Func<User, TResult> map)
        {
            return _dataContext.Users.Select(map).ToList();
        }

        public User GetByEmail(string email)
        {
            return _dataContext.Users.FirstOrDefault(user => user.Email == email);
        }

        public IList<TResult> ReadAll<TResult>(Func<User, TResult> map)
        {
            return _dataContext.Users.Select(map).ToList();
        }

        public IList<TResult> ReadByPredicate<TResult>(Func<User, bool> predicate, Func<User, TResult> map)
        {
            return _dataContext.Users.Where(predicate).Select(map).ToList();
        }
    }
}