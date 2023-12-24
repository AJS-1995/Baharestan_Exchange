using _0_Framework.Domain;
using Contracts.ExchangeRateContracts;

namespace Domin.ExchangeRateDomin
{
    public interface IExchangeRateRepository : IRepository<long, ExchangeRate>
    {
        ExchangeRateEdit GetDetails(long id);
        List<ExchangeRateViewModel> GetViewModel();
        List<ExchangeRateViewModel> GetRemove();
        List<ExchangeRateViewModel> GetInActive();
    }
}