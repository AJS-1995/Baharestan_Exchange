using _0_Framework.Application;

namespace Contracts.ManagementExpenseContracts.ExpenseContracts
{
    public interface IExpenseApplication
    {
        OperationResult Create(ExpenseCreate command);
        OperationResult Edit(ExpenseEdit command);
        ExpenseEdit GetDetails(long id);
        List<ExpenseViewModel> GetViewModel();
        List<ExpenseViewModel> GetViewModel(int agenciesId);
        List<ExpenseViewModel> GetInActive();
        List<ExpenseViewModel> GetInActive(int agenciesId);
        List<ExpenseViewModel> GetRemove();
        List<ExpenseViewModel> GetRemove(int agenciesId);
        OperationResult InActive(long id);
        OperationResult Active(long id);
        OperationResult Remove(long id);
        OperationResult Reset(long id);
        OperationResult Delete(long id);
    }
}