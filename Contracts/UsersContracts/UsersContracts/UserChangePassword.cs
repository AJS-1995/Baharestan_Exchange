namespace Contracts.UsersContracts.UsersContracts
{
    public class UserChangePassword
    {
        public int Id { get; set; }
        public string? Password { get; set; }
        public string? RePassword { get; set; }
        public string? SecurityCod { get; set; }
    }
}