using Amrida.Notery.Identity.Core.Utils;
using Armida.Notery.Common.DTOs.Identity;

namespace Amrida.Notery.Identity.Core.Services
{
    public interface IIdentityDataService
    {
        Task<IdentityOperationResult> UserRegister(UserRegisterRequestDto request);
        Task<IdentityOperationResult> UserLogin(UserLoginRequestDto request);
        Task<IdentityOperationResult> UserVerifyByToken(string verificationToken);
        Task<IdentityOperationResult> UserForgotPassword(string userEmail);
        Task<IdentityOperationResult> UserResetPassword(UserResetPasswordRequestDto request);
    }
}
