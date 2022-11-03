using Amrida.Notery.Identity.Core.Models;
using Amrida.Notery.Identity.Core.Utils;

namespace Amrida.Notery.Identity.Core.Repositories
{
    public interface IIdentityRepository
    {
        Task<IdentityOperationResult> AddUser(User user);
        Task<IdentityOperationResult> UserExistsByEmail(string email);
        Task<User> GetUserByEmail(string email);
        Task<User> GetUserByVerificationToken(string verificationToken);
        Task<User> GetUserByResetPasswordToken(string resetToken);
        Task<IdentityOperationResult> Save();
    }
}
