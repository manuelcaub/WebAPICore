namespace WebAPICore.Controllers
{
    using WebAPICore.Models;
    using WebAPICore.Service;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Post([FromBody]UserModel user)
        {
            _userService.Create(user);
            return Created("GetUser", user);
        }

        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetById(int id)
        {
            return new JsonResult(_userService.GetUserById(id));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return new JsonResult(_userService.GetAllUsersModel());
        }

        [HttpPut]
        public IActionResult Put([FromBody]ChangePasswordModel user)
        {
            _userService.UpdatePassword(user);
            return new JsonResult(user);
        }
    }
}