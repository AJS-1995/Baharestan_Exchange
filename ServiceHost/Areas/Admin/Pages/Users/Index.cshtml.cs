using _0_Framework.Application.Auth;
using _01_QueryManagement.Contracts.Permissions.User;
using Configuration.Permissions.Users;
using Contracts.UsersContracts.RoleContracts;
using Contracts.UsersContracts.UsersContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Users
{
    public class IndexModel : PageModel
    {
        public List<UserViewModel>? users;
        public UserPermissionQueryModel? permissionQueryModels;
        private readonly IUserPermissionQueryModel? _permissionQueryModel;
        private readonly IRoleApplication? _roleApplication;
        private readonly IUserApplication? _userApplication;
        private readonly IAuthHelper? _AuthHelper;
        public IndexModel(IUserApplication accountApplication, IRoleApplication roleApplication, IUserPermissionQueryModel permissionQueryModel, IAuthHelper authHelper)
        {
            _roleApplication = roleApplication;
            _userApplication = accountApplication;
            _permissionQueryModel = permissionQueryModel;
            _AuthHelper = authHelper;
        }
        public IActionResult OnGet()
        {
            permissionQueryModels = _permissionQueryModel?.GetUsers();
            if (permissionQueryModels?.ListUsers == UserPermissions.ListUsers || permissionQueryModels?.AdminUsers == UserPermissions.AdminUsers)
            {
                users = _userApplication?.GetViewModel();
                return Page();
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public IActionResult OnGetCreate()
        {
            permissionQueryModels = _permissionQueryModel?.GetUsers();
            if (permissionQueryModels?.AddUsers == UserPermissions.AddUsers || permissionQueryModels?.AdminUsers == UserPermissions.AdminUsers)
            {
                var command = new UserCreate
                {
                    Roles = _roleApplication?.GetViewModel()
                };
                return Partial("./Create", command);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public JsonResult OnPostCreate(UserCreate command)
        {
            var result = _userApplication?.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemoved()
        {
            permissionQueryModels = _permissionQueryModel?.GetUsers();
            if (permissionQueryModels?.RemoveUser == UserPermissions.RemoveUser || permissionQueryModels?.AdminUsers == UserPermissions.AdminUsers)
            {
                var commnd = new UserRemoved()
                {
                    UserRemoveds = _userApplication?.GetRemove(),
                };
                return Partial("./Removed", commnd);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public IActionResult OnGetActived()
        {
            permissionQueryModels = _permissionQueryModel?.GetUsers();
            var currentAccout = _AuthHelper?.CurrentUserInfo();
            if (currentAccout?.Id != currentAccout?.Id || permissionQueryModels?.ActiveUser == UserPermissions.ActiveUser || permissionQueryModels?.AdminUsers == UserPermissions.AdminUsers)
            {
                var commnd = new UserRemoved()
                {
                    UserRemoveds = _userApplication?.GetInActive(),
                };
                return Partial("./Actived", commnd);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public IActionResult OnGetEdit(int id)
        {
            permissionQueryModels = _permissionQueryModel?.GetUsers();
            var currentAccout = _AuthHelper?.CurrentUserInfo();
            if (currentAccout?.Id == currentAccout?.Id || permissionQueryModels?.EditUser == UserPermissions.EditUser || permissionQueryModels?.AdminUsers == UserPermissions.AdminUsers)
            {
                var account = _userApplication?.GetDetails(id);
                account.Roles = _roleApplication?.GetViewModel();
                return Partial("Edit", account);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public JsonResult OnPostEdit(UserEdit command)
        {
            var result = _userApplication?.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetChangePassword(int id)
        {
            permissionQueryModels = _permissionQueryModel?.GetUsers();
            var currentAccout = _AuthHelper?.CurrentUserInfo();
            if (currentAccout?.Id == currentAccout?.Id || permissionQueryModels?.ChangePasswordUser == UserPermissions.ChangePasswordUser || permissionQueryModels?.AdminUsers == UserPermissions.AdminUsers)
            {
                var command = new UserChangePassword { Id = id };
                return Partial("ChangePassword", command);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public JsonResult OnPostChangePassword(UserChangePassword command)
        {
            var result = _userApplication?.ChangePassword(command);
            return new JsonResult(result);
        }
        public JsonResult OnGetInActive(int id)
        {
            var result = _userApplication?.InActive(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetActive(int id)
        {
            var result = _userApplication?.Active(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetRemove(int id)
        {
            var result = _userApplication?.Remove(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetReset(int id)
        {
            var result = _userApplication?.Reset(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetDelete(int id)
        {
            var result = _userApplication?.Delete(id);
            return new JsonResult(result);
        }
        public IActionResult OnGetSaved(int id)
        {
            permissionQueryModels = _permissionQueryModel?.GetUsers();
            if (permissionQueryModels?.SavedUser == UserPermissions.SavedUser || permissionQueryModels?.AdminUsers == UserPermissions.AdminUsers)
            {
                var user = _userApplication?.GetViewModel().Where(x => x.Id == id).FirstOrDefault();
                var commnd = new UserViewModel()
                {
                    FullName = user?.FullName,
                    User_Name = user?.User_Name,
                    SaveDate = user?.SaveDate,
                };
                return Partial("./Saved", commnd);
            }
            else
            {
                return Redirect("/Index");
            }
        }
    }

}