namespace Amrida.Notery.Identity.Data.EF.Data
{
    public class User
    {
        public int Id { set; get; }
        public string Email { set; get; } = string.Empty;
        public DateTime? VeryficationDate { get; set; }
        public DateTime? ResetTokenExpirationDate { get; set; }
        public string? VerificationToken { get; set; }
        public string? ResetToken { get; set; }

        public byte[] PasswordHash { set; get; } = new byte[32];
        public byte[] PasswordSalt { set; get; } = new byte[32];
    }
}
