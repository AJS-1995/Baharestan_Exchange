namespace Contracts.ManagementPresonsContracts.LivelihoodMonthContracts
{
    public class LivelihoodMonthViewModel
    {
        public long Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public int LivelihoodId { get; set; }
        public int PersonsId { get; set; }
        public decimal Amount { get; set; }
        public int MoneyId { get; set; }
        public string? PresonsName { get; set; }
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