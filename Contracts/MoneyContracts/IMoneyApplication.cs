using _0_Framework.Application;

namespace Contracts.MoneyContracts
{
    public interface IMoneyApplication
    {
        OperationResult Create(MoneyCreate command);
        OperationResult Edit(MoneyEdit command);
        MoneyEdit GetDetails(int id);
        List<MoneyViewModel> GetViewModel();
        List<MoneyViewModel> GetInActive();
        List<MoneyViewModel> GetRemove();
        OperationResult InActive(int id);
        OperationResult Active(int id);
        OperationResult Remove(int id);
        OperationResult Reset(int id);
        OperationResult Delete(int id);
    }
}
