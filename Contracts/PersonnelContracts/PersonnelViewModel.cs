namespace Contracts.PersonnelContracts
{
    public class PersonnelViewModel
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Fathers_Name { get; set; }
        public string? Mobile { get; set; }
        public string? Address { get; set; }
        public string? Cart_Id { get; set; }
        public string? Photo { get; set; }
        public int AgenciesId { get; set; }
        public int IdAgencies { get; set; }
        public string? AgenciesName { get; set; }
        public string? SaveDate { get; set; }
        public int User_Id { get; set; }
        public string? User_Name { get; set; }
        public bool Status { get; set; }
        public bool Deleted { get; set; }
    }
}
