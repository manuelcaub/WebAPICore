using Microsoft.AspNetCore.Mvc;
using WebAPICore.Models;
using WebAPICore.ContextDB;
using System.Linq;
using System;

namespace WebAPICore.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        [HttpPost]
        public void Post([FromBody]UserModel user)
        {
            using (var dataContext = new DataBaseContext())
            {
                dataContext.Users.Add(new User { Name = "Manuel" });
                dataContext.Users.Add(new User { Name = "Dani" });
                dataContext.Users.Add(new User { Name = "Gabri" });
                dataContext.SaveChanges();

                foreach (var cat in dataContext.Users.ToList())
                {
                    Console.WriteLine($"Id = {cat.Id}, Name= {cat.Name}, Password = {cat.Password}");
                }

                Console.ReadLine();
            }
        }
    }
}
