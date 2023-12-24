using _01_QueryManagement.Contracts.Permissions.User;
using Configuration.Permissions.Users;
using Contracts.CompanyContracts;
using Contracts.UsersContracts.UsersContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages
{
    public class IndexModel : PageModel
    {
        public UserPermissionQueryModel? permissionQueryModels;
        private readonly IUserPermissionQueryModel? _permissionQueryModel;
        private readonly ICompanyApplication? _companyApplication;
        private readonly IUserApplication _userApplication;
        public IndexModel(ICompanyApplication? companyApplication, IUserPermissionQueryModel? permissionQueryModel, IUserApplication userApplication)
        {
            _companyApplication = companyApplication;
            _permissionQueryModel = permissionQueryModel;
            _userApplication = userApplication;
        }
        public void OnGet()
        {

        }
        public IActionResult OnGetCompanyEdit()
        {
            permissionQueryModels = _permissionQueryModel?.GetUsers();
            if (permissionQueryModels?.AdminUsers == UserPermissions.AdminUsers)
            {
                var company = _companyApplication?.GetViewModel().FirstOrDefault();
                CompanyEdit com = _companyApplication?.GetDetails(company.Id);
                return Partial("CompanyEdit", com);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public JsonResult OnPostCompanyEdit(CompanyEdit command)
        {
            var result = _companyApplication?.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetLogout()
        {
            _userApplication?.Logout();
            return RedirectToPage("/Index");
        }
    }
}