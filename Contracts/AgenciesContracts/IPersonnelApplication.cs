using _0_Framework.Application;

namespace Contracts.AgenciesContracts
{
    public interface IAgenciesApplication
    {
        OperationResult Create(AgenciesCreate command);
        OperationResult Edit(AgenciesEdit command);
        AgenciesEdit GetDetails(int id);
        List<AgenciesViewModel> GetViewModel();
        List<AgenciesViewModel> GetInActive();
        List<AgenciesViewModel> GetRemove();
        OperationResult InActive(int id);
        OperationResult Active(int id);
        OperationResult Remove(int id);
        OperationResult Reset(int id);
        OperationResult Delete(int id);
    }
}