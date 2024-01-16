using _0_Framework.Domain;
using Contracts.ExchangeRateContracts;

namespace Domin.ExchangeRateDomin
{
    public interface IExchangeRateRepository : IRepository<long, ExchangeRate>
    {
        ExchangeRateEdit GetDetails(long id);
        List<ExchangeRateViewModel> GetViewModel();
        List<ExchangeRateViewModel> GetViewModel(int agenciesId);
        List<ExchangeRateViewModel> GetRemove();
        List<ExchangeRateViewModel> GetRemove(int agenciesId);
        List<ExchangeRateViewModel> GetInActive();
        List<ExchangeRateViewModel> GetInActive(int agenciesId);
    }
}