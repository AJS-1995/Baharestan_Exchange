using _01_QueryManagement.Contracts.CompanyInfo;
using _01_QueryManagement;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.PersonsAdmin.ViewComponents
{
    public class PCompanyInfoViewComponent : ViewComponent
    {
        private readonly ICompanyQueryModel _companyQueryModel;
        public PCompanyInfoViewComponent(ICompanyQueryModel companyQueryModel)
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