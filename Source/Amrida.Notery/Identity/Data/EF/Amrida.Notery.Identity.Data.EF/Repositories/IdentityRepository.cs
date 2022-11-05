using Amrida.Notery.Identity.Core;
using Amrida.Notery.Identity.Core.Models;
using Amrida.Notery.Identity.Core.Repositories;
using Amrida.Notery.Identity.Core.Utils;
using Microsoft.EntityFrameworkCore;

namespace Amrida.Notery.Identity.Data.EF.Repositories
{
    public class IdentityRepository : IIdentityRepository
    {
        private readonly IIdentityDataContext _dataContext;

        public IdentityRepository(IIdentityDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IdentityOperationResult> AddUser(User model)
        {
            _dataContext.Users.Add(model);
            var savingResult = await _dataContext.SaveChangesAsync();

            if (savingResult > 0)
                return IdentityOperationResult.UserCreatedSuccessfully;

            return IdentityOperationResult.ChangesNotSaved;
        }

        public async Task<User> GetUserByEmail(string email) =>
            await _dataContext.Users.FirstOrDefaultAsync(u => u.Email == email);

        public async Task<User> GetUserByResetPasswordToken(string resetToken) =>
            await _dataContext.Users.FirstOrDefaultAsync(u => u.ResetToken == resetToken);

        public async Task<User> GetUserByVerificationToken(string verificationToken) =>
            await _dataContext.Users.FirstOrDefaultAsync(u => u.VerificationToken == verificationToken);

        public async Task<IdentityOperationResult> Save()
        {
            var savingResult = await _dataContext.SaveChangesAsync();

            if (savingResult > 0)
                return IdentityOperationResult.ChangesSaved;

            return IdentityOperationResult.ChangesNotSaved;
        }

        public IdentityOperationResult UserExistsByEmail(string email)
        {
            if (_dataContext.Users.Any(u => email == u.Email))
                return IdentityOperationResult.UserExists;

            return IdentityOperationResult.UserDoesNotExist;
        }
    }
}
