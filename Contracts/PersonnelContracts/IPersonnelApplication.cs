using _0_Framework.Application;

namespace Contracts.PersonnelContracts
{
    public interface IPersonnelApplication
    {
        OperationResult Create(PersonnelCreate command);
        OperationResult Edit(PersonnelEdit command);
        PersonnelEdit GetDetails(int id);
        List<PersonnelViewModel> GetViewModel();
        List<PersonnelViewModel> GetViewModel(int agenciesId);
        List<PersonnelViewModel> GetInActive();
        List<PersonnelViewModel> GetInActive(int agenciesId);
        List<PersonnelViewModel> GetRemove();
        List<PersonnelViewModel> GetRemove(int agenciesId);
        OperationResult InActive(int id);
        OperationResult Active(int id);
        OperationResult Remove(int id);
        OperationResult Reset(int id);
        OperationResult Delete(int id);
    }
}