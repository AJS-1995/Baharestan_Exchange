using _0_Framework.Application;

namespace Contracts.ManagementPresonsContracts.LivelihoodMonthContracts
{
    public interface ILivelihoodMonthApplication
    {
        OperationResult Create(LivelihoodMonthCreate command);
        OperationResult Edit(LivelihoodMonthEdit command);
        LivelihoodMonthEdit GetDetails(long id);
        List<LivelihoodMonthViewModel> GetViewModel();
        List<LivelihoodMonthViewModel> GetViewModel(int agenciesId);
        List<LivelihoodMonthViewModel> GetInActive();
        List<LivelihoodMonthViewModel> GetInActive(int agenciesId);
        List<LivelihoodMonthViewModel> GetRemove();
        List<LivelihoodMonthViewModel> GetRemove(int agenciesId);
        OperationResult InActive(long id);
        OperationResult Active(long id);
        OperationResult Remove(long id);
        OperationResult Reset(long id);
        OperationResult Delete(long id);
    }
}