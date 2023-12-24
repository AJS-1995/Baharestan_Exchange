using _01_QueryManagement;
using _01_QueryManagement.Contracts.AgenciesInfo;
using _01_QueryManagement.Contracts.CompanyInfo;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.Admin.ViewComponents
{
    public class CompanyInfoViewComponent : ViewComponent
    {
        private readonly ICompanyQueryModel _companyQueryModel;
        public CompanyInfoViewComponent(ICompanyQueryModel companyQueryModel)
        {
            _companyQueryModel = companyQueryModel;
        }
        public IViewComponentResult Invoke()
        {
            var result = new SidebarModel
            {
                CompaneisQueryModel = _companyQueryModel.GetCompaneis(),
            };
            return View(result);
        }
    }
}
