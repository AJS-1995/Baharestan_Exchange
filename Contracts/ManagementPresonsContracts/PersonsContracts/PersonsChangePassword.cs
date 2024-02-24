namespace Contracts.ManagementPresonsContracts.PersonsContracts
{
    public class PersonsChangePassword
    {
        public int Id { get; set; }
        public string? Password { get; set; }
        public string? RePassword { get; set; }
    }
}