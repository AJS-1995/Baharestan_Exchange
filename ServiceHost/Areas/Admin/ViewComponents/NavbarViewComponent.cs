using _01_QueryManagement.Contracts.Permissions.User;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.Admin.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        public UserPermissionQueryModel? permissionQueryModels;
        private readonly IUserPermissionQueryModel _permissionQueryModel;
        public NavbarViewComponent(IUserPermissionQueryModel permissionQueryModel)
        {
            _permissionQueryModel = permissionQueryModel;
        }
        public IViewComponentResult Invoke()
        {
            permissionQueryModels = _permissionQueryModel.GetUsers();
            return View(permissionQueryModels);
        }
    }
}