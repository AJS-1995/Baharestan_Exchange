using _0_Framework.Application;

namespace Contracts.ManagementPresonsContracts.LivelihoodContracts
{
    public interface ILivelihoodApplication
    {
        OperationResult Create(LivelihoodCreate command);
        OperationResult Edit(LivelihoodEdit command);
        LivelihoodEdit GetDetails(int id);
        List<LivelihoodViewModel> GetViewModel();
        List<LivelihoodViewModel> GetViewModel(int agenciesId);
        List<LivelihoodViewModel> GetInActive();
        List<LivelihoodViewModel> GetInActive(int agenciesId);
        List<LivelihoodViewModel> GetRemove();
        List<LivelihoodViewModel> GetRemove(int agenciesId);
        OperationResult InActive(int id);
        OperationResult Active(int id);
        OperationResult Remove(int id);
        OperationResult Reset(int id);
        OperationResult Delete(int id);
    }
}