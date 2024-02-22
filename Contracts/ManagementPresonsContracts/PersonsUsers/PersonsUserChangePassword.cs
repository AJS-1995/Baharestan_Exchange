namespace Contracts.ManagementPresonsContracts.PersonsUsers
{
	public class PersonsUserChangePassword
	{
		public int Id { get; set; }
		public string? Password { get; set; }
		public string? RePassword { get; set; }
	}
}