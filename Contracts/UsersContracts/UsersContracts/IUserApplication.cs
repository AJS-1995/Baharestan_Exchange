using _0_Framework.Application;

namespace Contracts.UsersContracts.UsersContracts
{
	public interface IUserApplication
    {
        UserViewModel GetUserBy(int id);
        OperationResult Create(UserCreate command);
        OperationResult Edit(UserEdit command);
        OperationResult Edit(UserPermissionsCreate command);
        OperationResult ChangePassword(UserChangePassword command);
        UserEdit GetDetails(int id);
        UserPermissionsCreate GetDetailsPer(int id);
        List<UserViewModel> GetViewModel();
        List<UserViewModel> GetInActive();
        List<UserViewModel> GetRemove();
        OperationResult Login(UserLogin command);
        OperationResult Logout();
        OperationResult InActive(int id);
        OperationResult Active(int id);
        OperationResult Remove(int id);
        OperationResult Reset(int id);
        OperationResult Delete(int id);
    }
}