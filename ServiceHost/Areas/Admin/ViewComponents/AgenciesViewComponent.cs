using _0_Framework.Application.Auth;
using _0_Framework.Application.PersonsAuth;
using _01_QueryManagement;
using _01_QueryManagement.Contracts.AgenciesInfo;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.Admin.ViewComponents
{
    public class AgenciesViewComponent : ViewComponent
    {
        private readonly IAgenciesQueryModel _agenciesQueryModel;
        private readonly IAuthHelper _authHelper;
        public AgenciesViewComponent(IAgenciesQueryModel agenciesQueryModel, IAuthHelper authHelper)
        {
            _agenciesQueryModel = agenciesQueryModel;
            _authHelper = authHelper;
        }
        public IViewComponentResult Invoke()
        {
            var agenciesId = _authHelper.CurrentAgenciesId();
            if (agenciesId == 0)
            {
                var result = new SidebarModel
                {
                    AgenciessQueryModel = _agenciesQueryModel.GetAgenciess(),
                };
                return View(result);
            }
            else
            {
                var result = new SidebarModel
                {
                    AgenciessQueryModel = _agenciesQueryModel.GetAgenciess(agenciesId),
                };
                return View(result);
            }
        }
    }
}