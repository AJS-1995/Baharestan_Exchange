using _0_Framework.Application.Auth;
using _01_QueryManagement.Contracts.Permissions.User;
using Contracts.UsersContracts.UsersContracts;

namespace _01_QueryManagement.Query.Permissions
{
    public class UserPermissionQuery : IUserPermissionQueryModel
    {
        private readonly IAuthHelper _authHelper;
        private readonly IUserApplication _userApplication;
        public UserPermissionQuery(IAuthHelper authHelper, IUserApplication userApplication)
        {
            _authHelper = authHelper;
            _userApplication = userApplication;
        }
        public UserPermissionQueryModel GetUsers()
        {
            int userslug = _userApplication.GetDetails(_authHelper.CurrentUserId()).Id;
            UserPermissionQueryModel cod = new UserPermissionQueryModel();
            if (userslug != 0)
            {
                var create = _userApplication.GetDetailsPer(userslug);
                foreach (var item in create.MappedPermissions)
                {
                    if (item.Code == 10)
                    {
                        cod.AdminUsers = item.Code;
                    }
                    if (item.Code == 11)
                    {
                        cod.AddUsers = item.Code;
                    }
                    if (item.Code == 12)
                    {
                        cod.ListUsers = item.Code;
                    }
                    if (item.Code == 13)
                    {
                        cod.EditUser = item.Code;
                    }
                    if (item.Code == 14)
                    {
                        cod.ChangePasswordUser = item.Code;
                    }
                    if (item.Code == 15)
                    {
                        cod.RemoveUser = item.Code;
                    }
                    if (item.Code == 16)
                    {
                        cod.ActiveUser = item.Code;
                    }
                    if (item.Code == 17)
                    {
                        cod.LevelUser = item.Code;
                    }
                    if (item.Code == 18)
                    {
                        cod.SavedUser = item.Code;
                    }
                }
            }
            return cod;
        }
    }
}