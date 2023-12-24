using _0_Framework.Domain;
using Contracts.PersonsContracts;

namespace Domin.PersonsDomin
{
    public interface IPersonsRepository : IRepository<int, Persons>
    {
        PersonsEdit GetDetails(int id);
        List<PersonsViewModel> GetViewModel();
        List<PersonsViewModel> GetRemove();
        List<PersonsViewModel> GetInActive();
    }
}
