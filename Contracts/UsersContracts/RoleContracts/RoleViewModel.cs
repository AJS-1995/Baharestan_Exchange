namespace Contracts.UsersContracts.RoleContracts
{
    public class RoleViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Cod { get; set; }
        public string? NamePersian { get; set; }
        public string? SaveDate { get; set; }
        public bool Status { get; set; }
        public bool Deleted { get; set; }
        public int User_Id { get; set; }
        public string? User_Name { get; set; }
    }
}