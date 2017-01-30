namespace WebAPICore.Controllers
{
    using WebAPICore.Models;
    using Microsoft.AspNetCore.Mvc;

    public class UsersController
    {
        [HttpPost]
        public void Post([FromBody]UserModel user)
        {

        }
    }
}