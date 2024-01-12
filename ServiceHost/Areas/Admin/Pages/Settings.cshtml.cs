using _0_Framework.Application;
using _0_Framework.Application.Auth;
using _01_QueryManagement.Contracts.Permissions.General;
using Configuration.Permissions.General;
using Contracts.AgenciesContracts;
using Contracts.CompanyContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages
{
    public class SettingsModel : PageModel
    {
        public GeneralPermissionQueryModel? permissionQueryModels;
        private readonly IGeneralPermissionQueryModel? _permissionQueryModel;
        private readonly ICompanyApplication _companyApplication;
        private readonly IAgenciesApplication _agenciesApplication;
        private readonly IAuthHelper _authHelper;
        public CompanyEdit? commandCompany;
        public AgenciesEdit? commandAgencies;
        public SettingsModel(IGeneralPermissionQueryModel? permissionQueryModel, ICompanyApplication companyApplication, IAgenciesApplication agenciesApplication, IAuthHelper authHelper)
        {
            _permissionQueryModel = permissionQueryModel;
            _companyApplication = companyApplication;
            _agenciesApplication = agenciesApplication;
            _authHelper = authHelper;
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