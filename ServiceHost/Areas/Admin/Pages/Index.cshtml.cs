using _0_Framework.Application.Auth;
using _0_Framework.Application.PersonsAuth;
using _01_QueryManagement.Contracts.Permissions.General;
using _01_QueryManagement.Contracts.Permissions.User;
using Configuration.Permissions.General;
using Configuration.Permissions.Users;
using Contracts.CompanyContracts;
using Contracts.DailyRateContracts;
using Contracts.UsersContracts.UsersContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages
{
    public class IndexModel : PageModel
    {
        public int idAgencies;
        public List<DailyRateViewModel>? DailyRate;
        public GeneralPermissionQueryModel? generalpermissionQueryModels;
        private readonly IGeneralPermissionQueryModel? _generalpermissionQueryModel;
        public UserPermissionQueryModel? permissionQueryModels;
        private readonly IUserPermissionQueryModel? _permissionQueryModel;
        private readonly ICompanyApplication? _companyApplication;
        private readonly IUserApplication _userApplication;
        private readonly IDailyRateApplication? _dailyRateApplication;
        private readonly IAuthHelper? _authHelper;
        public IndexModel(ICompanyApplication? companyApplication, IUserPermissionQueryModel? permissionQueryModel, IUserApplication userApplication, IDailyRateApplication? DailyRateApplication, IGeneralPermissionQueryModel? generalpermissionQueryModel, IAuthHelper? authHelper)
        {
            _companyApplication = companyApplication;
            _permissionQueryModel = permissionQueryModel;
            _userApplication = userApplication;
            _dailyRateApplication = DailyRateApplication;
            _generalpermissionQueryModel = generalpermissionQueryModel;
            _authHelper = authHelper;
        }
        public IActionResult OnGet()
        {
            generalpermissionQueryModels = _generalpermissionQueryModel?.GetGeneral();
            if (generalpermissionQueryModels?.ListGeneral == GeneralPermissions.ListGeneral || generalpermissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                generalpermissionQueryModels = _generalpermissionQueryModel?.GetGeneral();
                var agenciesId = _authHelper.CurrentAgenciesId();
                idAgencies = agenciesId;
                if (idAgencies != 0)
                {
                    DailyRate = _dailyRateApplication?.GetViewModel(idAgencies);
                }
                else
                {
                    DailyRate = _dailyRateApplication?.GetViewModel().OrderBy(x => x.Id).ToList();
                }
                return Page();
            }
            else
            {
                return Redirect("/Index");
            }
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