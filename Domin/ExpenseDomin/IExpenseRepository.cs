using _0_Framework.Domain;
using Contracts.ExpenseContracts;

namespace Domin.ExpenseDomin
{
    public interface IExpenseRepository : IRepository<long, Expense>
    {
        ExpenseEdit GetDetails(long id);
        List<ExpenseViewModel> GetViewModel();
        List<ExpenseViewModel> GetRemove();
        List<ExpenseViewModel> GetInActive();
    }
}