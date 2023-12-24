using _0_Framework.Domain;
using Contracts.AgenciesContracts;

namespace Domin.AgenciesDomin
{
    public interface IAgenciesRepository : IRepository<int, Agencies>
    {
        AgenciesEdit GetDetails(int id);
        List<AgenciesViewModel> GetViewModel();
        List<AgenciesViewModel> GetRemove();
        List<AgenciesViewModel> GetInActive();
    }
}
