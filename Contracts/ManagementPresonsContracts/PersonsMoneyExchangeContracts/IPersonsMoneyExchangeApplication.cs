using _0_Framework.Application;

namespace Contracts.ManagementPresonsContracts.PersonsMoneyExchangeContracts
{
    public interface IPersonsMoneyExchangeApplication
    {
        OperationResult Create(PersonsMoneyExchangeCreate command);
        OperationResult Edit(PersonsMoneyExchangeEdit command);
        PersonsMoneyExchangeEdit GetDetails(long id);
        List<PersonsMoneyExchangeViewModel> GetViewModel();
        List<PersonsMoneyExchangeViewModel> GetViewModel(int agenciesId);
        List<PersonsMoneyExchangeViewModel> GetInActive();
        List<PersonsMoneyExchangeViewModel> GetInActive(int agenciesId);
        List<PersonsMoneyExchangeViewModel> GetRemove();
        List<PersonsMoneyExchangeViewModel> GetRemove(int agenciesId);
        OperationResult InActive(long id);
        OperationResult Active(long id);
        OperationResult Remove(long id);
        OperationResult Reset(long id);
        OperationResult Delete(long id);
    }
}
