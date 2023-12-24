using _0_Framework.Application;

namespace Contracts.SafeBoxContracts
{
    public interface ISafeBoxApplication
    {
        OperationResult Create(SafeBoxCreate command);
        OperationResult Edit(SafeBoxEdit command);
        SafeBoxEdit GetDetails(int id);
        List<SafeBoxViewModel> GetViewModel();
        List<SafeBoxViewModel> GetInActive();
        List<SafeBoxViewModel> GetRemove();
        OperationResult InActive(int id);
        OperationResult Active(int id);
        OperationResult Remove(int id);
        OperationResult Reset(int id);
        OperationResult Delete(int id);
    }
}