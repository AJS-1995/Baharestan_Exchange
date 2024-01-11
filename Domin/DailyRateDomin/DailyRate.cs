using _0_Framework.Domain;

namespace Domin.DailyRateDomin
{
    public class DailyRate : EntityBase<int>
    {
        public decimal Amount { get; private set; }
        public int MainMoneyId { get; private set; }
        public decimal PriceBey { get; private set; }
        public decimal PriceSell { get; private set; }
        public int SecondaryMoneyId { get; private set; }
        public string? DateDay { get; private set; }
        public DailyRate(decimal amount, int mainMoneyId, decimal priceBey, decimal priceSell, int secondaryMoneyId, string? dateDay, int userId, int agenciesId)
        {
            Amount = amount;
            MainMoneyId = mainMoneyId;
            PriceBey = priceBey;
            PriceSell = priceSell;
            SecondaryMoneyId = secondaryMoneyId;
            DateDay = dateDay;
            UserId = userId;
            AgenciesId = agenciesId;
        }
        public void Edit(decimal amount, int mainMoneyId, decimal priceBey, decimal priceSell, int secondaryMoneyId, string? dateDay, int userId, int agenciesId)
        {
            Amount = amount;
            MainMoneyId = mainMoneyId;
            PriceBey = priceBey;
            PriceSell = priceSell;
            SecondaryMoneyId = secondaryMoneyId;
            DateDay = dateDay;
            UserId = userId;
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