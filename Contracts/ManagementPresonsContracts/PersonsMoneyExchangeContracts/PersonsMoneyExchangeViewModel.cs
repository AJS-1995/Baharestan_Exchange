namespace Contracts.ManagementPresonsContracts.PersonsMoneyExchangeContracts
{
    public class PersonsMoneyExchangeViewModel
    {
        public long Id { get; set; }
        public string? Date { get; set; }
        public int MoneyId_One { get; set; }
        public string? MoneyName_One { get; set; }
        public decimal Amount_One { get; set; }
        public decimal Price { get; set; }
        public bool Type { get; set; }
        public int MoneyId_Two { get; set; }
        public string? MoneyName_Two { get; set; }
        public decimal Amount_Two { get; set; }
        public int PersonId { get; set; }
        public string? PersonName { get; set; }
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
