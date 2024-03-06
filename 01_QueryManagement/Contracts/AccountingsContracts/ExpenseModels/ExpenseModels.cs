namespace _01_QueryManagement.Contracts.AccountingsContracts.ExpenseModels
{
    public class ExpenseModels
    {
        public int AgenciesId { get; set; }
        public string? AgenciesName { get; set; }
        public int MoneyId { get; set; }
        public string? MoneyName { get; set; }
        public string? MoneySymbol { get; set; }
        public decimal Rest { get; set; }
    }
}