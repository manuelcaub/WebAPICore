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
            _userService.Create<UserModel>(user);
            return Created("GetUser", user);
        }

        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetById(ulong id)
        {
            return new JsonResult(_userService.ReadById<UserModel>(id));
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return new JsonResult(_userService.ReadAll<UserModel>());
        }

        [HttpPut]
        public IActionResult Put([FromBody]ChangePasswordModel user)
        {
            _userService.UpdatePassword(user);
            return new JsonResult(user);
        }
    }
}