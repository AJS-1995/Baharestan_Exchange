using _0_Framework.Domain;
using Domin.AgenciesDomin;
using Domin.ManagementPresonsDomin.PersonsDomin;

namespace Domin.ManagementPresonsDomin.PersonsMoneyExchangeDomin
{
    public class PersonsMoneyExchange : EntityBase<long>
    {
        public string? Date { get; private set; }
        public int MoneyId_One { get; private set; }
        public decimal Amount_One { get; private set; }
        public decimal Price { get; private set; }
        public bool Type { get; private set; }
        public int MoneyId_Two { get; private set; }
        public decimal Amount_Two { get; private set; }
        public int PersonsId { get; private set; }
        public Persons? Persons { get; private set; }
        public Agencies? Agenciess { get; private set; }
        public PersonsMoneyExchange() { }
        public PersonsMoneyExchange(string? date, int moneyId_One, decimal amount_One, decimal price, bool type, int moneyId_Two, decimal amount_Two, int PersonsId, int userid, int agenciesId)
        {
            Date = date;
            MoneyId_One = moneyId_One;
            Amount_One = amount_One;
            Price = price;
            Type = type;
            MoneyId_Two = moneyId_Two;
            Amount_Two = amount_Two;
            PersonsId = PersonsId;
            UserId = userid;
            AgenciesId = agenciesId;
        }
        public void Edit(string? date, int moneyId_One, decimal amount_One, decimal price, bool type, int moneyId_Two, decimal amount_Two, int PersonsId, int userid, int agenciesId)
        {
            Date = date;
            MoneyId_One = moneyId_One;
            Amount_One = amount_One;
            Price = price;
            Type = type;
            MoneyId_Two = moneyId_Two;
            Amount_Two = amount_Two;
            PersonsId = PersonsId;
            UserId = userid;
            AgenciesId = agenciesId;
        }
        public void InActive()
        {
            Status = false;
        }
        public void Active()
        {
            Status = true;
        }
        public void Remove()
        {
            Deleted = true;
        }
        public void Reset()
        {
            Deleted = false;
        }
    }
}