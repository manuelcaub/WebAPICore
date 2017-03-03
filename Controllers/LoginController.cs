namespace WebAPICore.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using WebAPICore.Service;

    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly LoginService _loginService = new LoginService();

        [HttpGet("token")]
        public async Task<IActionResult> GetToken()
        {
            return new JsonResult(await Task.Run(() => _loginService.GenerateToken()));
        }
    }
}
