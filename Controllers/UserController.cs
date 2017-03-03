namespace WebAPICore.Controllers
{
    using WebAPICore.Data;
    using WebAPICore.Data.Repositories;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _repUser;

        public UsersController(IUserRepository repUser)
        {
            _repUser = repUser;
        }

        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            _repUser.Create(user);
            return Created("GetUser", user);
        }

        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetById(int id)
        {
            return new JsonResult(_repUser.Read(id));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return new JsonResult(_repUser.ReadAll());
        }

        [HttpPut]
        public IActionResult Put([FromBody]User user)
        {
            _repUser.Update(user);
            return new JsonResult(user);
        }
    }
}