using _01_QueryManagement.Contracts.AgenciesInfo;
using _01_QueryManagement;
using Microsoft.AspNetCore.Mvc;
using _0_Framework.Application.PersonsAuth;

namespace ServiceHost.Areas.PersonsAdmin.ViewComponents
{
    public class PAgenciesViewComponent : ViewComponent
    {
        private readonly IAgenciesQueryModel _agenciesQueryModel;
        private readonly IPersonsAuthHelper _authHelper;
        public PAgenciesViewComponent(IAgenciesQueryModel agenciesQueryModel, IPersonsAuthHelper authHelper)
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