using _0_Framework.Application.Auth;
using _01_QueryManagement.Contracts.Permissions.General;
using Configuration.Permissions.General;
using Contracts.AgenciesContracts;
using Contracts.SafeBoxContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.SafeBoxs
{
    public class IndexModel : PageModel
    {
        public int idAgencies;
        public GeneralPermissionQueryModel? permissionQueryModels;
        private readonly IGeneralPermissionQueryModel? _permissionQueryModel;
        public List<SafeBoxViewModel>? SafeBox;
        private readonly ISafeBoxApplication? _safeBoxApplication;
        private readonly IAuthHelper? _authHelper;
        private readonly IAgenciesApplication? _agenciesApplication;
        public IndexModel(IGeneralPermissionQueryModel? permissionQueryModel, ISafeBoxApplication? safeBoxApplication, IAuthHelper? authHelper, IAgenciesApplication? agenciesApplication)
        {
            _permissionQueryModel = permissionQueryModel;
            _safeBoxApplication = safeBoxApplication;
            _authHelper = authHelper;
            _agenciesApplication = agenciesApplication;
        }
        public IActionResult OnGet()
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.ListGeneral == GeneralPermissions.ListGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                permissionQueryModels = _permissionQueryModel?.GetGeneral();
                var agenciesId = _authHelper.CurrentAgenciesId();
                idAgencies = agenciesId;
                if (idAgencies != 0)
                {
                    SafeBox = _safeBoxApplication?.GetViewModel(idAgencies);
                }
                else
                {
                    SafeBox = _safeBoxApplication?.GetViewModel();
                }
                return Page();
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public IActionResult OnGetCreate()
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.AddGeneral == GeneralPermissions.AddGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var agenciesId = _authHelper.CurrentAgenciesId();
                var command = new SafeBoxCreate()
                {
                    IdAgencies = agenciesId,
                    Agencies = _agenciesApplication?.GetViewModel(),
                };
                return Partial("./Create", command);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public JsonResult OnPostCreate(SafeBoxCreate command)
        {
            var result = _safeBoxApplication?.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemoved()
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.RemovedGeneral == GeneralPermissions.RemovedGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var agenciesId = _authHelper.CurrentAgenciesId();
                idAgencies = agenciesId;
                if (idAgencies != 0)
                {
                    var commnd = new SafeBoxRemoved()
                    {
                        idAgencies = idAgencies,
                        SafeBoxRemoveds = _safeBoxApplication?.GetRemove(idAgencies)
                    };
                    return Partial("./Removed", commnd);
                }
                else
                {
                    var commnd = new SafeBoxRemoved()
                    {
                        idAgencies = idAgencies,
                        SafeBoxRemoveds = _safeBoxApplication?.GetRemove()
                    };
                    return Partial("./Removed", commnd);
                }
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public IActionResult OnGetActived()
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.ActivedGeneral == GeneralPermissions.ActivedGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var agenciesId = _authHelper.CurrentAgenciesId();
                idAgencies = agenciesId;
                if (idAgencies != 0)
                {
                    var commnd = new SafeBoxRemoved()
                    {
                        idAgencies = idAgencies,
                        SafeBoxRemoveds = _safeBoxApplication?.GetInActive(idAgencies)
                    };
                    return Partial("./Actived", commnd);
                }
                else
                {
                    var commnd = new SafeBoxRemoved()
                    {
                        idAgencies = idAgencies,
                        SafeBoxRemoveds = _safeBoxApplication?.GetInActive()
                    };
                    return Partial("./Actived", commnd);
                }
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public IActionResult OnGetEdit(int id)
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.EditGeneral == GeneralPermissions.EditGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var agenciesId = _authHelper.CurrentAgenciesId();
                var result = _safeBoxApplication?.GetDetails(id);
                result.Agencies = _agenciesApplication?.GetViewModel();
                result.IdAgencies = agenciesId;
                return Partial("Edit", result);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public JsonResult OnPostEdit(SafeBoxEdit command)
        {
            var result = _safeBoxApplication?.Edit(command);
            return new JsonResult(result);
        }
        public JsonResult OnGetInActive(int id)
        {
            var result = _safeBoxApplication?.InActive(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetActive(int id)
        {
            var result = _safeBoxApplication?.Active(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetRemove(int id)
        {
            var result = _safeBoxApplication?.Remove(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetReset(int id)
        {
            var result = _safeBoxApplication?.Reset(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetDelete(int id)
        {
            var result = _safeBoxApplication?.Delete(id);
            return new JsonResult(result);
        }
        public IActionResult OnGetSaved(int id)
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.SavedGeneral == GeneralPermissions.SavedGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var SafeBox = _safeBoxApplication?.GetViewModel().Where(x => x.Id == id).FirstOrDefault();
                var commnd = new SafeBoxViewModel()
                {
                    Name = SafeBox?.Name,
                    UserName = SafeBox?.UserName,
                    SaveDate = SafeBox?.SaveDate,
                };
                return Partial("./Saved", commnd);
            }
            else
            {
                return Redirect("/Index");
            }
        }
    }
}