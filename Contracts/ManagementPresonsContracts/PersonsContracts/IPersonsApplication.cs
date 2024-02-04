using _0_Framework.Application;

namespace Contracts.ManagementPresonsContracts.PersonsContracts
{
    public interface IPersonsApplication
    {
        OperationResult Create(PersonsCreate command);
        OperationResult Edit(PersonsEdit command);
        PersonsEdit GetDetails(int id);
        List<PersonsViewModel> GetViewModel();
        List<PersonsViewModel> GetViewModel(int agenciesId);
        List<PersonsViewModel> GetInActive();
        List<PersonsViewModel> GetInActive(int agenciesId);
        List<PersonsViewModel> GetRemove();
        List<PersonsViewModel> GetRemove(int agenciesId);
        OperationResult InActive(int id);
        OperationResult Active(int id);
        OperationResult Remove(int id);
        OperationResult Reset(int id);
        OperationResult Delete(int id);
    }
}
