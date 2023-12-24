using _0_Framework.Application;

namespace Contracts.PersonnelContracts
{
    public interface IPersonnelApplication
    {
        OperationResult Create(PersonnelCreate command);
        OperationResult Edit(PersonnelEdit command);
        PersonnelEdit GetDetails(int id);
        List<PersonnelViewModel> GetViewModel();
        List<PersonnelViewModel> GetInActive();
        List<PersonnelViewModel> GetRemove();
        OperationResult InActive(int id);
        OperationResult Active(int id);
        OperationResult Remove(int id);
        OperationResult Reset(int id);
        OperationResult Delete(int id);
    }
}