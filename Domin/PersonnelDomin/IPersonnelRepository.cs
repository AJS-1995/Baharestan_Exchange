using _0_Framework.Domain;
using Contracts.PersonnelContracts;

namespace Domin.PersonnelDomin
{
    public interface IPersonnelRepository : IRepository<int, Personnel>
    {
        PersonnelEdit GetDetails(int id);
        List<PersonnelViewModel> GetViewModel();
        List<PersonnelViewModel> GetRemove();
        List<PersonnelViewModel> GetInActive();
        List<PersonnelViewModel> GetAll();
    }
}