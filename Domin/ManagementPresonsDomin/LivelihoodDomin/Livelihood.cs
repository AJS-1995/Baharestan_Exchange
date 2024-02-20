using _0_Framework.Domain;
using Domin.AgenciesDomin;
using Domin.ManagementPresonsDomin.PersonsDomin;
using Domin.MoneyDomin;

namespace Domin.ManagementPresonsDomin.LivelihoodDomin
{
    public class Livelihood : EntityBase<int>
    {
        public string? SDate { get; private set; }
        public string? EDate { get; private set; }
        public int PersonsId { get; private set; }
        public decimal Amount { get; private set; }
        public bool Cancel { get; private set; }
        public int MoneyId { get; private set; }
        public Agencies? Agenciess { get; private set; }
        public Persons? Persons { get; private set; }
        public Money? Moneys { get; private set; }
        public Livelihood() { }
        public Livelihood(string? sDate, string? eDate, int personsId, decimal amount, bool cancel, int moneyId, int userid, int agenciesId)
        {
            SDate = sDate;
            EDate = eDate;
            PersonsId = personsId;
            Amount = amount;
            Cancel = cancel;
            MoneyId = moneyId;
            UserId = userid;
            AgenciesId = agenciesId;
        }
        public void Edit(string? sDate, string? eDate, int personsId, decimal amount, bool cancel, int moneyId, int userid, int agenciesId)
        {
            SDate = sDate;
            EDate = eDate;
            PersonsId = personsId;
            Amount = amount;
            Cancel = cancel;
            MoneyId = moneyId;
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