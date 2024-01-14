namespace Contracts.UsersContracts.UsersContracts
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? UserName { get; set; }
        public string? Mobile { get; set; }
        public string? SecurityCod { get; set; }
        public int Role_Id { get; set; }
        public string? Role { get; set; }
        public string? RolePersian { get; set; }
        public int IdAgencies { get; set; }
        public string? NameAgencies { get; set; }
        public string? ProfilePhoto { get; set; }
        public string? SaveDate { get; set; }
        public int User_Id { get; set; }
        public string? User_Name { get; set; }
        public bool Status { get; set; }
        public bool Deleted { get; set; }
    }

}