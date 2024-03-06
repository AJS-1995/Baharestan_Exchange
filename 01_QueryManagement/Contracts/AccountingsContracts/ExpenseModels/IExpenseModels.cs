namespace _01_QueryManagement.Contracts.AccountingsContracts.ExpenseModels
{
    public interface IExpenseModels
    {
        List<ExpenseModels>? ExpenseModelss(int agenciesId);
        List<ExpenseModels>? ExpenseModelss();
    }
}