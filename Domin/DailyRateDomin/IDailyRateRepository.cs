using _0_Framework.Domain;
using Contracts.DailyRateContracts;

namespace Domin.DailyRateDomin
{
    public interface IDailyRateRepository : IRepository<int, DailyRate>
    {
        DailyRateEdit GetDetails(int id);
        List<DailyRateViewModel> GetViewModel();
        List<DailyRateViewModel> GetViewModel(int agenciesId);
        List<DailyRateViewModel> GetRemove();
        List<DailyRateViewModel> GetRemove(int agenciesId);
        List<DailyRateViewModel> GetInActive();
        List<DailyRateViewModel> GetInActive(int agenciesId);
    }
}