using _0_Framework.Application;

namespace Contracts.ManagementPresonsContracts.PersonsReceiptContracts
{
    public interface IPersonsReceiptApplication
    {
        OperationResult Create(PersonsReceiptCreate command);
        OperationResult Edit(PersonsReceiptEdit command);
        PersonsReceiptEdit GetDetails(long id);
        List<PersonsReceiptViewModel> GetViewModel();
        List<PersonsReceiptViewModel> GetViewModel(int agenciesId);
        List<PersonsReceiptViewModel> GetInActive();
        List<PersonsReceiptViewModel> GetInActive(int agenciesId);
        List<PersonsReceiptViewModel> GetRemove();
        List<PersonsReceiptViewModel> GetRemove(int agenciesId);
        OperationResult InActive(long id);
        OperationResult Active(long id);
        OperationResult Remove(long id);
        OperationResult Reset(long id);
        OperationResult Delete(long id);
    }
}
