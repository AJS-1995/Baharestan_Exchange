namespace Contracts.AgenciesContracts
{
    public class AgenciesViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Mobile { get; set; }
        public string? Responsible { get; set; }
        public int CompanyId { get; set; }
        public string? SaveDate { get; set; }
        public bool Status { get; set; }
        public bool Deleted { get; set; }
        public int UserId { get; set; }
        public string? User_Name { get; set; }
    }
}