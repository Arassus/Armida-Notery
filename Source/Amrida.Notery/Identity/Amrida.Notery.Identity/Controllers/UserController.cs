using Armida.Notery.Common.DTOs.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Amrida.Notery.Identity.Controllers
{
    public class UserController : Controller
    {
        [HttpPost("register")]
        public IActionResult Register(UserRegisterRequestDto request)
        {
            return Ok("No user yet");
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginRequestDto request)
        {
            return Ok("Whatever . . .");
        }

        [HttpPost("verify")]
        public IActionResult Verify(string token)
        {
            return Ok("Seems legit");
        }

        [HttpPost("forgot-password")]
        public IActionResult ForgotPassword(string email)
        {
            return Ok("The safety word is 'banana'");
        }

        [HttpPost("reset-password")]
        public IActionResult ResettPassword(UserResetPasswordRequestDto request)
        {
            return Ok("Password reset");
        }
    }
}
