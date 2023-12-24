using _0_Framework.Infrastructure;
using _0_Framework.Infrastructure.Permission;
using _01_QueryManagement.Contracts.Permissions.User;
using Configuration.Permissions.Users;
using Contracts.UsersContracts.UsersContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Admin.Pages.Users
{
    [Authorize(Roles = Roles.Admin)]
    public class LevelModel : PageModel
    {
        public UserPermissionsCreate? Command;
        public List<SelectListItem>? Permissions = new List<SelectListItem>();
        public UserPermissionQueryModel? permissionQueryModels;
        private readonly IUserApplication? _userApplication;
        private readonly IEnumerable<IPermissionExposer>? _exposers;
        private readonly IUserPermissionQueryModel? _permissionQueryModel;
        public LevelModel(IUserApplication userApplication, IEnumerable<IPermissionExposer> exposers, IUserPermissionQueryModel permissionQueryModel)
        {
            _userApplication = userApplication;
            _exposers = exposers;
            _permissionQueryModel = permissionQueryModel;
        }
        public IActionResult OnGet(int id)
        {
            permissionQueryModels = _permissionQueryModel?.GetUsers();
            if (permissionQueryModels?.LevelUser == UserPermissions.LevelUser || permissionQueryModels?.AdminUsers == UserPermissions.AdminUsers)
            {
                Command = _userApplication?.GetDetailsPer(id);
                foreach (var exposer in _exposers)
                {
                    var exposedPermissions = exposer.Expose();
                    foreach (var (key, value) in exposedPermissions)
                    {
                        var group = new SelectListGroup { Name = key };
                        foreach (var permission in value)
                        {
                            var item = new SelectListItem(permission.Name, permission.Code.ToString())
                            {
                                Group = group
                            };

                            if (Command.MappedPermissions.Any(x => x.Code == permission.Code))
                                item.Selected = true;

                            Permissions?.Add(item);
                        }
                    }
                }
                return Page();
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public IActionResult OnPost(UserPermissionsCreate command)
        {
            var result = _userApplication?.Edit(command);
            return RedirectToPage("Index");
        }
    }
}