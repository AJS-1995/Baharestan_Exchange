using _0_Framework.Application.Auth;
using _0_Framework.Application.PersonsAuth;
using _01_QueryManagement.Contracts.Permissions.General;
using Contracts.UsersContracts.UsersContracts;

namespace _01_QueryManagement.Query.Permissions
{
    public class GeneralPermissionQuery : IGeneralPermissionQueryModel
    {
        private readonly IAuthHelper _authHelper;
        private readonly IUserApplication _userApplication;
        public GeneralPermissionQuery(IAuthHelper authHelper, IUserApplication userApplication)
        {
            _authHelper = authHelper;
            _userApplication = userApplication;
        }
        public GeneralPermissionQueryModel GetGeneral()
        {
            var id = _userApplication.GetDetails(_authHelper.CurrentUserId()).Id;
            GeneralPermissionQueryModel cod = new GeneralPermissionQueryModel();
            if (id != 0)
            {
                var create = _userApplication.GetDetailsPer(id);
                foreach (var item in create.MappedPermissions)
                {
                    if (item.Code == 20)
                    {
                        cod.AdminGeneral = item.Code;
                    }
                    if (item.Code == 21)
                    {
                        cod.AddGeneral = item.Code;
                    }
                    if (item.Code == 22)
                    {
                        cod.EditGeneral = item.Code;
                    }
                    if (item.Code == 23)
                    {
                        cod.RemoveGeneral = item.Code;
                    }
                    if (item.Code == 24)
                    {
                        cod.ActiveGeneral = item.Code;
                    }
                    if (item.Code == 25)
                    {
                        cod.ListGeneral = item.Code;
                    }
                    if (item.Code == 126)
                    {
                        cod.RemovedGeneral = item.Code;
                    }
                    if (item.Code == 27)
                    {
                        cod.ActivedGeneral = item.Code;
                    }
                    if (item.Code == 28)
                    {
                        cod.SavedGeneral = item.Code;
                    }
                }
            }
            return cod;
        }
    }

}