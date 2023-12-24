using _0_Framework.Application;
using _01_QueryManagement.Contracts.Permissions.General;
using Configuration.Permissions.General;
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
        public CompanyEdit? command;
        public SettingsModel(IGeneralPermissionQueryModel? permissionQueryModel, ICompanyApplication companyApplication)
        {
            _permissionQueryModel = permissionQueryModel;
            _companyApplication = companyApplication;
        }
        public IActionResult OnGet()
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var com = _companyApplication.GetViewModel().FirstOrDefault();
                ViewData["Name"] = com?.Name;
                command = _companyApplication.GetDetails(com.Id);
                return Page();
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public IActionResult OnPost(CompanyEdit command)
        {
            var operation = new OperationResult();
            operation = _companyApplication.Edit(command);
            return new JsonResult(operation);
        }
    }
}