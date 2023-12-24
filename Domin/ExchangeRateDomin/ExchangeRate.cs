using _0_Framework.Domain;
using Domin.MoneyDomin;

namespace Domin.ExchangeRateDomin
{
    public partial class ExchangeRate : EntityBase<long>
    {
        public decimal Amount { get; private set; }
        public int MainMoneyId { get; private set; }
        public decimal Price { get; private set; }
        public int SecondaryMoneyId { get; private set; }
        public ExchangeRate() { }
        public ExchangeRate(decimal amount, int mainMoneyId, decimal price, int secondaryMoneyId, int userId, int agenciesId)
        {
            Amount = amount;
            MainMoneyId = mainMoneyId;
            Price = price;
            SecondaryMoneyId = secondaryMoneyId;
            UserId = userId;
            AgenciesId = agenciesId;
        }
        public void Edit(decimal amount, int mainMoneyId, decimal price, int secondaryMoneyId, int userId, int agenciesId)
        {
            Amount = amount;
            MainMoneyId = mainMoneyId;
            Price = price;
            SecondaryMoneyId = secondaryMoneyId;
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