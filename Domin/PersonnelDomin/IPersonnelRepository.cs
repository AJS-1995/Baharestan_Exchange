using _0_Framework.Domain;
using Contracts.PersonnelContracts;

namespace Domin.PersonnelDomin
{
    public interface IPersonnelRepository : IRepository<int, Personnel>
    {
        PersonnelEdit GetDetails(int id);
        List<PersonnelViewModel> GetViewModel();
        List<PersonnelViewModel> GetViewModel(int agenciesId);
        List<PersonnelViewModel> GetRemove();
        List<PersonnelViewModel> GetRemove(int agenciesId);
        List<PersonnelViewModel> GetInActive();
        List<PersonnelViewModel> GetInActive(int agenciesId);
        List<PersonnelViewModel> GetAll();
    }
}