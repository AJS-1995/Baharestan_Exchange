using _0_Framework.Application;

namespace Contracts.ExpenseContracts
{
    public interface ICollectionApplication
    {
        OperationResult Create(CollectionCreate command);
        OperationResult Edit(CollectionEdit command);
        CollectionEdit GetDetails(int id);
        List<CollectionViewModel> GetViewModel();
        List<CollectionViewModel> GetInActive();
        List<CollectionViewModel> GetRemove();
        OperationResult InActive(int id);
        OperationResult Active(int id);
        OperationResult Remove(int id);
        OperationResult Reset(int id);
        OperationResult Delete(int id);
    }
}
