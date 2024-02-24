using _0_Framework.Domain;
using Contracts.ManagementPresonsContracts.PersonsContracts;

namespace Domin.ManagementPresonsDomin.PersonsDomin
{
    public interface IPersonsRepository : IRepository<int, Persons>
    {
        Persons GetBy(string? personsUsername);
        PersonsEdit GetDetails(int id);
        List<PersonsViewModel> GetViewModel();
        List<PersonsViewModel> GetViewModel(int agenciesId);
        List<PersonsViewModel> GetRemove();
        List<PersonsViewModel> GetRemove(int agenciesId);
        List<PersonsViewModel> GetInActive();
        List<PersonsViewModel> GetInActive(int agenciesId);
    }
}