namespace Contracts.SafeBoxContracts
{
    public class SafeBoxViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Treasurer { get; set; }
        public string? Mobile { get; set; }
        public string? SaveDate { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public bool Status { get; set; }
        public bool Deleted { get; set; }
    }
}
