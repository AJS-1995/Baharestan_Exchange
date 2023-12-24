using _0_Framework.Application;

namespace Contracts.PersonsContracts
{
    public interface IPersonsApplication
    {
        OperationResult Create(PersonsCreate command);
        OperationResult Edit(PersonsEdit command);
        PersonsEdit GetDetails(int id);
        List<PersonsViewModel> GetViewModel();
        List<PersonsViewModel> GetInActive();
        List<PersonsViewModel> GetRemove();
        OperationResult InActive(int id);
        OperationResult Active(int id);
        OperationResult Remove(int id);
        OperationResult Reset(int id);
        OperationResult Delete(int id);
    }
}
