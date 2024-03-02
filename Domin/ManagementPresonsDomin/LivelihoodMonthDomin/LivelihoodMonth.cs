using _0_Framework.Domain;
using Domin.AgenciesDomin;
using Domin.ManagementPresonsDomin.LivelihoodDomin;

namespace Domin.ManagementPresonsDomin.LivelihoodMonthDomin
{
    public class LivelihoodMonth : EntityBase<long>
    {
        public int Year { get; private set; }
        public int Month { get; private set; }
        public int LivelihoodId { get; private set; }
        public int PersonsId { get; private set; }
        public decimal Amount { get; private set; }
        public int MoneyId { get; private set; }
        public Agencies? Agenciess { get; private set; }
        public Livelihood? Livelihood { get; private set; }
        public LivelihoodMonth() { }
        public LivelihoodMonth(int year, int month, int livelihoodId, int personsId, decimal amount, int moneyId, int userid, int agenciesId)
        {
            Year = year;
            Month = month;
            LivelihoodId = livelihoodId;
            PersonsId = personsId;
            Amount = amount;
            MoneyId = moneyId;
            UserId = userid;
            AgenciesId = agenciesId;
        }
        public void Edit(int year, int month, int livelihoodId, int personsId, decimal amount, int moneyId, int userid, int agenciesId)
        {
            Year = year;
            Month = month;
            LivelihoodId = livelihoodId;
            PersonsId = personsId;
            Amount = amount;
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