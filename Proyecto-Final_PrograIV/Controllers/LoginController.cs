using Microsoft.AspNetCore.Mvc;
using Proyecto_Final_PrograIV.Model.Auth;
using Proyecto_Final_PrograIV.Model.Auth.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto_Final_PrograIV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly ISvAuth _authService;

        public LoginController(ISvAuth authService)
        {
            _authService = authService;
        }

        // POST api/<AuthController>
        [HttpPost]
        public ActionResult<AuthResponse> Post([FromBody] Auth auth )
        {
            var result = _authService.Authenticate(auth);
            if (result == null)
            {
                return Unauthorized();
            }
            return Ok(result);
        }
    }
}
