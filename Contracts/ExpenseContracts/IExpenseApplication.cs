using _0_Framework.Application;

namespace Contracts.ExpenseContracts
{
    public interface IExpenseApplication
    {
        OperationResult Create(ExpenseCreate command);
        OperationResult Edit(ExpenseEdit command);
        ExpenseEdit GetDetails(long id);
        List<ExpenseViewModel> GetViewModel();
        List<ExpenseViewModel> GetInActive();
        List<ExpenseViewModel> GetRemove();
        OperationResult InActive(long id);
        OperationResult Active(long id);
        OperationResult Remove(long id);
        OperationResult Reset(long id);
        OperationResult Delete(long id);
    }
}
