namespace _01_QueryManagement.Contracts.AccountingsContracts.PersonsModels
{
    public class PersonsModels
    {
        public int PersonId { get; set; }
        public string? PersonsName { get; set; }
        public int MoneyId { get; set; }
        public string? MoneyName { get; set; }
        public string? MoneySymbol { get; set; }
        public decimal Receipts { get; set; }
        public decimal Slavery { get; set; }
        public decimal Rest { get; set; }
    }
}