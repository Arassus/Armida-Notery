using Amrida.Notery.Identity.Core.Models;
using Amrida.Notery.Identity.Core.Repositories;
using Amrida.Notery.Identity.Core.Services;
using Amrida.Notery.Identity.Core.Utils;
using Armida.Notery.Common.DTOs.Identity;
using System.Security.Cryptography;
using System.Text;

namespace Amrida.Notery.Identity.Data.EF.Services
{
    public class IdentityDataService : IIdentityDataService
    {
        private const int _tokenByteCount = 64;
        private readonly IIdentityRepository _identityRepository;

        public IdentityDataService(IIdentityRepository identityRepository)
        {
            _identityRepository = identityRepository;
        }

        public async Task<IdentityOperationResult> UserRegister(UserRegisterRequestDto request)
        {
            var result = _identityRepository.UserExistsByEmail(request.Email);

            if (IdentityOperationResultCode.UserExists == result.Code)
                return result;

            CreatePasswordHash(request.Password,
                 out byte[] passwordHash,
                 out byte[] passwordSalt);

            var user = new User
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                VerificationToken = CreateRandomToken()
            };

            return await _identityRepository.AddUser(user);
        }

        public async Task<IdentityOperationResult> UserLogin(UserLoginRequestDto request)
        {
            var user = await _identityRepository.GetUserByEmail(request.Email);

            if (user == null)
                return IdentityOperationResult.UserDoesNotExist;

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
                return IdentityOperationResult.UserBadPassword;

            if (user.VeryficationDate == null)
                return IdentityOperationResult.UserNotVerified;

            return IdentityOperationResult.UserLoggedIn;
        }

        public async Task<IdentityOperationResult> UserVerifyByToken(string verificationToken)
        {
            var user = await _identityRepository.GetUserByVerificationToken(verificationToken);

            if (user == null)
                return IdentityOperationResult.UserTokenNotValid;

            user.VeryficationDate = DateTime.UtcNow;
            var result = await _identityRepository.Save();

            if (IdentityOperationResultCode.ChangesNotSaved == result.Code)
                return IdentityOperationResult.UserCannotVerify;

            return IdentityOperationResult.UserVerified;
        }

        public async Task<IdentityOperationResult> UserForgotPassword(string userEmail)
        {
            var user = await _identityRepository.GetUserByEmail(userEmail);

            if (user == null)
                return IdentityOperationResult.UserDoesNotExist;

            user.ResetToken = CreateRandomToken();
            user.ResetTokenExpirationDate = DateTime.UtcNow.AddDays(1);
            var result = await _identityRepository.Save();

            if (IdentityOperationResultCode.ChangesNotSaved == result.Code)
                return IdentityOperationResult.UserCannotResetPassword;

            return IdentityOperationResult.UserCanResetPassword;
        }

        public async Task<IdentityOperationResult> UserResetPassword(UserResetPasswordRequestDto request)
        {
            var user = await _identityRepository.GetUserByVerificationToken(request.Token);

            if (user == null)
                return IdentityOperationResult.UserTokenNotValid;

            CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.ResetToken = null;
            user.ResetTokenExpirationDate = null;
            var result = await _identityRepository.Save();

            if (IdentityOperationResultCode.ChangesNotSaved == result.Code)
                return IdentityOperationResult.UserCannotResetPassword;

            return IdentityOperationResult.UserResetPasswordSuccess;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmacSHA512 = new HMACSHA512())
            {
                passwordSalt = hmacSHA512.Key;
                passwordHash = hmacSHA512.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            byte[] hash;

            using (var hmacSHA512 = new HMACSHA512(passwordSalt))
                hash = hmacSHA512.ComputeHash(Encoding.UTF8.GetBytes(password));

            return hash.SequenceEqual(passwordHash);
        }

        private string CreateRandomToken()
            => Convert.ToHexString(RandomNumberGenerator.GetBytes(_tokenByteCount));
    }
}
