namespace Contracts.ManagementPresonsContracts.PersonsUsers
{
    public class PersonsUserViewModel
	{
        public int Id { get; set; }
        public string? UserName { get; set; }
        public int PersonsId { get; set; }
        public string? PersonsName { get; set; }
        public int IdAgencies { get; set; }
        public string? AgenciesName { get; set; }
        public string? ProfilePhoto { get; set; }
        public string? SaveDate { get; set; }
        public int User_Id { get; set; }
        public string? User_Name { get; set; }
        public bool Status { get; set; }
        public bool Deleted { get; set; }
    }
}