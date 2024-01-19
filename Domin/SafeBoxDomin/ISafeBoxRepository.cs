using _0_Framework.Domain;
using Contracts.SafeBoxContracts;

namespace Domin.SafeBoxDomin
{
    public interface ISafeBoxRepository : IRepository<int, SafeBox>
    {
        SafeBoxEdit GetDetails(int id);
        List<SafeBoxViewModel> GetViewModel();
        List<SafeBoxViewModel> GetViewModel(int agenciesId);
        List<SafeBoxViewModel> GetRemove();
        List<SafeBoxViewModel> GetRemove(int agenciesId);
        List<SafeBoxViewModel> GetInActive();
        List<SafeBoxViewModel> GetInActive(int agenciesId);
    }
}