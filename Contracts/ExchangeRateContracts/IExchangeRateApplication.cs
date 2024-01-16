using _0_Framework.Application;

namespace Contracts.ExchangeRateContracts
{
    public interface IExchangeRateApplication
    {
        OperationResult Create(ExchangeRateCreate command);
        OperationResult Edit(ExchangeRateEdit command);
        ExchangeRateEdit GetDetails(long id);
        List<ExchangeRateViewModel> GetViewModel();
        List<ExchangeRateViewModel> GetViewModel(int agenciesId);
        List<ExchangeRateViewModel> GetInActive();
        List<ExchangeRateViewModel> GetInActive(int agenciesId);
        List<ExchangeRateViewModel> GetRemove();
        List<ExchangeRateViewModel> GetRemove(int agenciesId);
        OperationResult InActive(long id);
        OperationResult Active(long id);
        OperationResult Remove(long id);
        OperationResult Reset(long id);
        OperationResult Delete(long id);
    }
}