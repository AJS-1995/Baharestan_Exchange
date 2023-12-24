using _0_Framework.Domain;
using Contracts.ExpenseContracts;

namespace Domin.ExpenseDomin
{
    public interface ICollectionRepository : IRepository<int, Collection>
    {
        CollectionEdit GetDetails(int id);
        List<CollectionViewModel> GetViewModel();
        List<CollectionViewModel> GetRemove();
        List<CollectionViewModel> GetInActive();
    }
}
