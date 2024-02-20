using _0_Framework.Domain;
using Contracts.ManagementPresonsContracts.LivelihoodContracts;

namespace Domin.ManagementPresonsDomin.LivelihoodDomin
{
    public interface ILivelihoodRepository : IRepository<int, Livelihood>
    {
        LivelihoodEdit GetDetails(int id);
        List<LivelihoodViewModel> GetViewModel();
        List<LivelihoodViewModel> GetViewModel(int agenciesId);
        List<LivelihoodViewModel> GetRemove();
        List<LivelihoodViewModel> GetRemove(int agenciesId);
        List<LivelihoodViewModel> GetInActive();
        List<LivelihoodViewModel> GetInActive(int agenciesId);
    }
}