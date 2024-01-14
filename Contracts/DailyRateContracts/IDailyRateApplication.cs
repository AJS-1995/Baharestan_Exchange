using _0_Framework.Application;

namespace Contracts.DailyRateContracts
{
    public interface IDailyRateApplication
    {
        OperationResult Create(DailyRateCreate command);
        OperationResult Edit(DailyRateEdit command);
        DailyRateEdit GetDetails(int id);
        List<DailyRateViewModel> GetViewModel();
        List<DailyRateViewModel> GetViewModel(int agenciesId);
        List<DailyRateViewModel> GetInActive();
        List<DailyRateViewModel> GetInActive(int agenciesId);
        List<DailyRateViewModel> GetRemove();
        List<DailyRateViewModel> GetRemove(int agenciesId);
        OperationResult InActive(int id);
        OperationResult Active(int id);
        OperationResult Remove(int id);
        OperationResult Reset(int id);
        OperationResult Delete(int id);
    }
}