namespace _01_QueryManagement.Contracts.CompanyInfo
{
    public class CompanyQueryModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Mobile { get; set; }
        public string? Responsible { get; set; }
        public string? Logo { get; set; }
    }
}