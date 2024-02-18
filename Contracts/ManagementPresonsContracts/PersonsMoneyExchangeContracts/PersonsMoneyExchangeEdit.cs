namespace Contracts.ManagementPresonsContracts.PersonsMoneyExchangeContracts
{
    public class PersonsMoneyExchangeEdit : PersonsMoneyExchangeCreate
    {
        public long Id { get; set; }
        public string? PersonName { get; set; }
    }
}
