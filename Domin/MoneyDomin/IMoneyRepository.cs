using _0_Framework.Domain;
using Contracts.MoneyContracts;

namespace Domin.MoneyDomin
{
    public interface IMoneyRepository : IRepository<int, Money>
    {
        MoneyEdit GetDetails(int id);
        List<MoneyViewModel> GetViewModel();
        List<MoneyViewModel> GetRemove();
        List<MoneyViewModel> GetInActive();
        List<MoneyViewModel> GetAll();
    }
}