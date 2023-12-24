using _0_Framework.Domain;
using Contracts.UsersContracts.UsersContracts;

namespace Domin.UsersDomin
{
    public interface IUserRepository : IRepository<int, User>
    {
        User GetBy(string username);
        UserEdit GetDetails(int id);
        UserPermissionsCreate GetDetailsPer(int id);
        List<UserViewModel> GetViewModel();
        List<UserViewModel> GetRemove();
        List<UserViewModel> GetInActive();
    }
}