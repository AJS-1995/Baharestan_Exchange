namespace Contracts.MoneyContracts
{
    public class MoneyViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameSymblo { get; set; }
        public string? Country { get; set; }
        public string? Symbol { get; set; }
        public string? SaveDate { get; set; }
        public int User_Id { get; set; }
        public string? User_Name { get; set; }
        public bool Status { get; set; }
        public bool Deleted { get; set; }
    }
}
