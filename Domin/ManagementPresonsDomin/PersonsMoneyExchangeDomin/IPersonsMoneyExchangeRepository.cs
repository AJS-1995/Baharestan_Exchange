using _0_Framework.Domain;
using Contracts.ManagementPresonsContracts.PersonsMoneyExchangeContracts;

namespace Domin.ManagementPresonsDomin.PersonsMoneyExchangeDomin
{
    public interface IPersonsMoneyExchangeRepository : IRepository<long, PersonsMoneyExchange>
    {
        PersonsMoneyExchangeEdit GetDetails(long id);
        List<PersonsMoneyExchangeViewModel> GetViewModel();
        List<PersonsMoneyExchangeViewModel> GetViewModel(int agenciesId);
        List<PersonsMoneyExchangeViewModel> GetRemove();
        List<PersonsMoneyExchangeViewModel> GetRemove(int agenciesId);
        List<PersonsMoneyExchangeViewModel> GetInActive();
        List<PersonsMoneyExchangeViewModel> GetInActive(int agenciesId);
    }
}