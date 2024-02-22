using _01_QueryManagement.Contracts.Users;
using _01_QueryManagement;
using Microsoft.AspNetCore.Mvc;
using _0_Framework.Application.PersonsAuth;

namespace ServiceHost.Areas.PersonsAdmin.ViewComponents
{
    public class PSidebarViewComponent : ViewComponent
    {
        private readonly IUserQueryModel _userQueryModel;
        private readonly IPersonsAuthHelper _authHelper;
        public PSidebarViewComponent(IPersonsAuthHelper authHelper, IUserQueryModel userQueryModel)
        {
            _authHelper = authHelper;
            _userQueryModel = userQueryModel;
        }
        public IViewComponentResult Invoke()
        {
            int userid = _authHelper.CurrentPersonsId();
            var result = new SidebarModel
            {
                PersonsQueryModel = _userQueryModel.GetPersons(userid),
            };
            return View(result);
        }
    }
}