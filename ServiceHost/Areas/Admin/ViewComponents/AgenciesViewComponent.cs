using _01_QueryManagement;
using _01_QueryManagement.Contracts.AgenciesInfo;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.Admin.ViewComponents
{
    public class AgenciesViewComponent : ViewComponent
    {
        private readonly IAgenciesQueryModel _agenciesQueryModel;
        public AgenciesViewComponent(IAgenciesQueryModel agenciesQueryModel)
        {
            _agenciesQueryModel = agenciesQueryModel;
        }
        public IViewComponentResult Invoke()
        {
            var result = new SidebarModel
            {
                AgenciessQueryModel = _agenciesQueryModel.GetAgenciess(),
            };
            return View(result);
        }
    }
}