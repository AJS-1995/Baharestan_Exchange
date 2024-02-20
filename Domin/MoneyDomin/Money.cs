using _0_Framework.Domain;
using Domin.ManagementPresonsDomin.LivelihoodDomin;
using Domin.ManagementPresonsDomin.PersonsMoneyExchangeDomin;
using Domin.ManagementPresonsDomin.PersonsReceiptDomin;

namespace Domin.MoneyDomin
{
    public class Money : EntityBase<int>
    {
        public string? Name { get; set; }
        public string? Country { get; set; }
        public string? Symbol { get; set; }
        public List<PersonsReceipt>? PersonsReceipts { get; }
        public List<Livelihood>? Livelihoods { get; }
        public Money() 
        {
            PersonsReceipts = new List<PersonsReceipt>();
            Livelihoods = new List<Livelihood>();
        }
        public Money(string? name, string? country, string? symbol, int userid, int agenciesId)
        {
            Name = name;
            Country = country;
            Symbol = symbol;
            UserId = userid;
            AgenciesId = agenciesId;
        }
        public void Edit(string? name, string? country, string? symbol, int userid, int agenciesId)
        {
            Name = name;
            Country = country;
            Symbol = symbol;
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