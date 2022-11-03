namespace Amrida.Notery.Identity.Core.Utils
{
    public class IdentityOperationResult
    {
        private IdentityOperationResult(IdentityOperationResultCode code, string message)
        {
            Code = code;
            Message = message;
        }

        public IdentityOperationResultCode Code { get; set; }
        public string Message { get; set; } = string.Empty;

        public static IdentityOperationResult UserTokenNotValid => new IdentityOperationResult(IdentityOperationResultCode.UserTokenNotValid, "User Token is not valid.");
        public static IdentityOperationResult UserExists => new IdentityOperationResult(IdentityOperationResultCode.UserExists, "User already exists.");
        public static IdentityOperationResult UserCreatedSuccessfully => new IdentityOperationResult(IdentityOperationResultCode.UserCreatedSuccessfully, "User created successfully.");
        public static IdentityOperationResult UserDoesNotExist => new IdentityOperationResult(IdentityOperationResultCode.UserDoesNotExist, "User does not exist.");
        public static IdentityOperationResult UserBadPassword => new IdentityOperationResult(IdentityOperationResultCode.UserBadPassword, "Password is not correct.");
        public static IdentityOperationResult UserNotVerified => new IdentityOperationResult(IdentityOperationResultCode.UserNotVerified, "User is not verified.");
        public static IdentityOperationResult UserLoggedIn => new IdentityOperationResult(IdentityOperationResultCode.UserLoggedIn, "User is now logged in.");
        public static IdentityOperationResult UserVerified => new IdentityOperationResult(IdentityOperationResultCode.UserVerified, "User is verified.");
        public static IdentityOperationResult UserCannotVerify => new IdentityOperationResult(IdentityOperationResultCode.UserCannotVerify, "User cannot be verified at this time.");
        public static IdentityOperationResult UserCannotResetPassword => new IdentityOperationResult(IdentityOperationResultCode.UserCannotResetPassword, "Cannot reset the password at this time.");
        public static IdentityOperationResult UserCanResetPassword => new IdentityOperationResult(IdentityOperationResultCode.UserCanResetPassword, "Password can now be reset.");
        public static IdentityOperationResult UserResetPasswordSuccess => new IdentityOperationResult(IdentityOperationResultCode.UserResetPasswordSuccess, "Password reset successfully.");
        public static IdentityOperationResult ChangesSaved => new IdentityOperationResult(IdentityOperationResultCode.ChangesSaved, string.Empty);
        public static IdentityOperationResult ChangesNotSaved => new IdentityOperationResult(IdentityOperationResultCode.ChangesNotSaved, string.Empty);
    }

    public enum IdentityOperationResultCode
    {
        UserTokenNotValid,
        UserExists,
        UserCreatedSuccessfully,
        UserDoesNotExist,
        UserBadPassword,
        UserNotVerified,
        UserLoggedIn,
        UserVerified,
        UserCannotVerify,
        UserCanResetPassword,
        UserCannotResetPassword,
        UserResetPasswordSuccess,
        ChangesSaved,
        ChangesNotSaved
    }
}
