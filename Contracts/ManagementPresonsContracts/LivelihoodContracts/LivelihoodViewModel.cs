namespace Contracts.ManagementPresonsContracts.LivelihoodContracts
{
    public class LivelihoodViewModel
    {
        public int Id { get; set; }
        public string? SDate { get; set; }
        public string? EDate { get; set; }
        public int PersonsId { get; set; }
        public string? PresonsName { get; set; }
        public decimal Amount { get; set; }
        public bool Cancel { get; set; }
        public int MoneyId { get; set; }
        public string? MoneyName { get; set; }
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