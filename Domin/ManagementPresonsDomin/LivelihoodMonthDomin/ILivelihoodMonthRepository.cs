using _0_Framework.Domain;
using Contracts.ManagementPresonsContracts.LivelihoodMonthContracts;

namespace Domin.ManagementPresonsDomin.LivelihoodMonthDomin
{
    public interface ILivelihoodMonthRepository : IRepository<long, LivelihoodMonth>
    {
        LivelihoodMonthEdit GetDetails(long id);
        List<LivelihoodMonthViewModel> GetViewModel();
        List<LivelihoodMonthViewModel> GetViewModel(int agenciesId);
        List<LivelihoodMonthViewModel> GetRemove();
        List<LivelihoodMonthViewModel> GetRemove(int agenciesId);
        List<LivelihoodMonthViewModel> GetInActive();
        List<LivelihoodMonthViewModel> GetInActive(int agenciesId);
    }
}