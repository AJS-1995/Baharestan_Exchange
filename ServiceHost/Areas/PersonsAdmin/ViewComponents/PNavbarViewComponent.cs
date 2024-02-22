using _01_QueryManagement.Contracts.Permissions.User;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.PersonsAdmin.ViewComponents
{
    public class PNavbarViewComponent : ViewComponent
    {
        public UserPermissionQueryModel? permissionQueryModels;
        private readonly IUserPermissionQueryModel _permissionQueryModel;
        public PNavbarViewComponent(IUserPermissionQueryModel permissionQueryModel)
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