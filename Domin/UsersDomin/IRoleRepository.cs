using _0_Framework.Domain;
using Contracts.UsersContracts.RoleContracts;

namespace Domin.UsersDomin
{
    public interface IRoleRepository : IRepository<int, Role>
    {
        RoleEdit GetDetails(int id);
        List<RoleViewModel> GetViewModel();
        List<RoleViewModel> GetRemove();
        List<RoleViewModel> GetInActive();
    }
}