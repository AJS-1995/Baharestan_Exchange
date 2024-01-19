using _0_Framework.Application;
using _0_Framework.Application.Auth;
using _01_QueryManagement.Contracts.Permissions.General;
using Configuration.Permissions.General;
using Contracts.AgenciesContracts;
using Contracts.CompanyContracts;
using Contracts.MoneyContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages
{
    public class SettingsModel : PageModel
    {
        public int idAgencies;
        public List<AgenciesViewModel>? agencies;
        public List<MoneyViewModel>? Money;
        public GeneralPermissionQueryModel? permissionQueryModels;
        private readonly IGeneralPermissionQueryModel? _permissionQueryModel;
        private readonly ICompanyApplication _companyApplication;
        private readonly IAgenciesApplication _agenciesApplication;
        private readonly IAuthHelper _authHelper;
        private readonly IMoneyApplication? _moneyApplication;
        public CompanyEdit? commandCompany;
        public AgenciesEdit? commandAgencies;
        public SettingsModel(IGeneralPermissionQueryModel? permissionQueryModel, ICompanyApplication companyApplication, IAgenciesApplication agenciesApplication, IAuthHelper authHelper, IMoneyApplication? moneyApplication)
        {
            _permissionQueryModel = permissionQueryModel;
            _companyApplication = companyApplication;
            _agenciesApplication = agenciesApplication;
            _authHelper = authHelper;
            _moneyApplication = moneyApplication;
        }
        public IActionResult OnGet()
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var com = _companyApplication.GetViewModel().FirstOrDefault();
                ViewData["Name"] = com?.Name;
                commandCompany = _companyApplication.GetDetails(com.Id);
                var agenciesId = _authHelper.CurrentAgenciesId();
                commandAgencies = _agenciesApplication.GetDetails(agenciesId);
                idAgencies = agenciesId;
                agencies = _agenciesApplication.GetViewModel();
                Money = _moneyApplication?.GetViewModel();
                return Page();
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public IActionResult OnPostCompanyEdit(CompanyEdit commandCompany)
        {
            var operation = new OperationResult();
            operation = _companyApplication.Edit(commandCompany);
            return new JsonResult(operation);
        }
    }
}