using Amrida.Notery.Identity.Core.Services;
using Amrida.Notery.Identity.Core.Utils;
using Armida.Notery.Common.DTOs.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Amrida.Notery.Identity.Controllers
{
    public class UserController : Controller
    {
        private readonly IIdentityDataService _identityDataService;

        public UserController(IIdentityDataService identityDataService)
        {
            _identityDataService = identityDataService;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UserRegister(UserRegisterRequestDto request)
        {
            var result = await _identityDataService.UserRegister(request);

            if (IdentityOperationResultCode.UserCreatedSuccessfully == result.Code)
                return Ok(result.Message);
            
            return BadRequest(result.Message);
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UserLogin(UserLoginRequestDto request)
        {
            var result = await _identityDataService.UserLogin(request);

            if (IdentityOperationResultCode.UserLoggedIn == result.Code)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }

        [HttpPost("verify")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UserVerify(string token)
        {
            var result = await _identityDataService.UserVerifyByToken(token);

            if (IdentityOperationResultCode.UserVerified == result.Code)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }

        [HttpPost("forgot-password")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UserForgotPassword(string email)
        {
            var result = await _identityDataService.UserForgotPassword(email);

            if (IdentityOperationResultCode.UserCanResetPassword == result.Code)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }

        [HttpPost("reset-password")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UserResetPassword(UserResetPasswordRequestDto request)
        {
            var result = await _identityDataService.UserResetPassword(request);

            if (IdentityOperationResultCode.UserResetPasswordSuccess == result.Code)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }
    }
}
