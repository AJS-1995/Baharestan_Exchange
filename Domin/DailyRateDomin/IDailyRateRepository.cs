using _0_Framework.Domain;
using Contracts.DailyRateContracts;

namespace Domin.DailyRateDomin
{
    public interface IDailyRateRepository : IRepository<int, DailyRate>
    {
        DailyRateEdit GetDetails(int id);
        List<DailyRateViewModel> GetViewModel();
        List<DailyRateViewModel> GetRemove();
        List<DailyRateViewModel> GetInActive();
    }
}