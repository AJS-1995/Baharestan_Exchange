using _0_Framework.Domain;
using Contracts.ExpenseContracts;

namespace Domin.ExpenseDomin
{
    public interface IExpenseRepository : IRepository<long, Expense>
    {
        ExpenseEdit GetDetails(long id);
        List<ExpenseViewModel> GetViewModel();
        List<ExpenseViewModel> GetViewModel(int agenciesId);
        List<ExpenseViewModel> GetRemove();
        List<ExpenseViewModel> GetRemove(int agenciesId);
        List<ExpenseViewModel> GetInActive();
        List<ExpenseViewModel> GetInActive(int agenciesId);
    }
}