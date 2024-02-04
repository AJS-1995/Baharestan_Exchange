using _0_Framework.Domain;
using Contracts.ManagementPresonsContracts.PersonsReceiptContracts;

namespace Domin.ManagementPresonsDomin.PersonsReceiptDomin
{
    public interface IPersonsReceiptRepository : IRepository<long, PersonsReceipt>
    {
        PersonsReceiptEdit GetDetails(long id);
        List<PersonsReceiptViewModel> GetViewModel();
        List<PersonsReceiptViewModel> GetViewModel(int agenciesId);
        List<PersonsReceiptViewModel> GetRemove();
        List<PersonsReceiptViewModel> GetRemove(int agenciesId);
        List<PersonsReceiptViewModel> GetInActive();
        List<PersonsReceiptViewModel> GetInActive(int agenciesId);
    }
}