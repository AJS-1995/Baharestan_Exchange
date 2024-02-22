using _0_Framework.Application.Auth;
using _0_Framework.Application.PersonsAuth;
using _01_QueryManagement;
using _01_QueryManagement.Contracts.Users;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.Admin.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly IUserQueryModel _userQueryModel;
        private readonly IAuthHelper _authHelper;
        public SidebarViewComponent(IAuthHelper authHelper, IUserQueryModel userQueryModel)
        {
            _authHelper = authHelper;
            _userQueryModel = userQueryModel;
        }
        public IViewComponentResult Invoke()
        {
            var userid = _authHelper.CurrentUserInfo();
            var result = new SidebarModel
            {
                UsersQueryModel = _userQueryModel.GetUsers(userid.Id),
            };
            return View(result);
        }
    }
}