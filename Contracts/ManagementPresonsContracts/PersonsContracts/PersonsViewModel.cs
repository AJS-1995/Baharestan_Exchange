namespace Contracts.ManagementPresonsContracts.PersonsContracts
{
    public class PersonsViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Mobile { get; set; }
        public string? Address { get; set; }
        public string? Company { get; set; }
        public string? Guarantor { get; set; }
        public string? GuarantorPhoto { get; set; }
        public int AgenciesId { get; set; }
        public int IdAgencies { get; set; }
        public string? AgenciesName { get; set; }
        public string? SaveDate { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public bool Status { get; set; }
        public bool Deleted { get; set; }
    }
}
