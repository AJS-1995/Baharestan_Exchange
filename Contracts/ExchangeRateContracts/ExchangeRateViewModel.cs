namespace Contracts.ExchangeRateContracts
{
    public class ExchangeRateViewModel
    {
        public long Id { get; set; }
        public decimal Amount { get; set; }
        public int MainMoneyId { get; set; }
        public string? MainMoneyName { get; set; }
        public string? MainMoneySymbol { get; set; }
        public decimal PriceBey { get; set; }
        public decimal PriceSell { get; set; }
        public int SecondaryMoneyId { get; set; }
        public string? SecondaryMoneyName { get; set; }
        public string? SecondaryMoneySymbol { get; set; }
        public string? DateDay { get; set; }
        public string? SaveDate { get; set; }
        public int AgenciesId { get; set; }
        public int IdAgencies { get; set; }
        public string? NameAgencies { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public bool Status { get; set; }
        public bool Deleted { get; set; }
    }
}