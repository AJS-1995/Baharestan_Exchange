using _01_QueryManagement.Contracts.AccountingsContracts.ExpenseModels;
using Domin.AgenciesDomin;
using Domin.ManagementExpenseDomin.ExpenseDomin;
using Domin.MoneyDomin;

namespace _01_QueryManagement.Query.AccountingsQuery
{
    public class ExpenseQuery : IExpenseModels
    {
        private readonly IExpenseRepository _expenseRepository;
        private readonly IMoneyRepository _moneyRepository;
        private readonly IAgenciesRepository _agenciesRepository;
        public ExpenseQuery(IExpenseRepository expenseRepository, IMoneyRepository moneyRepository, IAgenciesRepository agenciesRepository)
        {
            _expenseRepository = expenseRepository;
            _moneyRepository = moneyRepository;
            _agenciesRepository = agenciesRepository;
        }

        public List<ExpenseModels>? ExpenseModelss(int agenciesId)
        {
            var expenseModels = new List<ExpenseModels>();
            var moneies = _moneyRepository.GetViewModel();
            var agencies = _agenciesRepository.GetDetails(agenciesId);
            foreach (var money in moneies)
            {
                var expense = _expenseRepository.GetViewModel().Where(x => x.AgenciesId == agenciesId && x.MoneyId == money.Id).ToList();
                var rest = expense.Sum(x => x.Amount);
                if (rest != 0)
                {
                    expenseModels.Add(new ExpenseModels()
                    {
                        MoneyId = money.Id,
                        MoneyName = money.Name,
                        MoneySymbol = money.Symbol,
                        Rest = rest,
                        AgenciesId = agenciesId,
                        AgenciesName = agencies.Name,
                    });
                }
            }
            return expenseModels.ToList();
        }

        public List<ExpenseModels>? ExpenseModelss()
        {
            var expenseModels = new List<ExpenseModels>();
            var moneies = _moneyRepository.GetViewModel();
            foreach (var money in moneies)
            {
                var expense = _expenseRepository.GetViewModel().Where(x => x.MoneyId == money.Id).ToList();
                var rest = expense.Sum(x => x.Amount);
                if (rest != 0)
                {
                    expenseModels.Add(new ExpenseModels()
                    {
                        MoneyId = money.Id,
                        MoneyName = money.Name,
                        MoneySymbol = money.Symbol,
                        Rest = rest,
                        AgenciesId = 0,
                    });
                }
            }
            return expenseModels.ToList();
        }
    }
}
