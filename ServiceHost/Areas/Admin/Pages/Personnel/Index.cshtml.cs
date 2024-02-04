using _0_Framework.Application.Auth;
using _01_QueryManagement.Contracts.Permissions.General;
using Configuration.Permissions.General;
using Contracts.AgenciesContracts;
using Contracts.PersonnelContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Personnel
{
    public class IndexModel : PageModel
    {
        public int idAgencies;
        public GeneralPermissionQueryModel? permissionQueryModels;
        private readonly IGeneralPermissionQueryModel? _permissionQueryModel;
        public List<PersonnelViewModel>? Personnel;
        private readonly IPersonnelApplication? _personnelApplication;
        private readonly IAuthHelper? _authHelper;
        private readonly IAgenciesApplication? _agenciesApplication;
        public IndexModel(IGeneralPermissionQueryModel? permissionQueryModel, IPersonnelApplication? personnelApplication, IAuthHelper? authHelper, IAgenciesApplication? agenciesApplication)
        {
            _permissionQueryModel = permissionQueryModel;
            _personnelApplication = personnelApplication;
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
                    Personnel = _personnelApplication?.GetViewModel(idAgencies);
                }
                else
                {
                    Personnel = _personnelApplication?.GetViewModel();
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
                var command = new PersonnelCreate()
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
        public JsonResult OnPostCreate(PersonnelCreate command)
        {
            var result = _personnelApplication?.Create(command);
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
                    var commnd = new PersonnelRemoved()
                    {
                        idAgencies = idAgencies,
                        PersonnelRemoveds = _personnelApplication?.GetRemove(idAgencies)
                    };
                    return Partial("./Removed", commnd);
                }
                else
                {
                    var commnd = new PersonnelRemoved()
                    {
                        idAgencies = idAgencies,
                        PersonnelRemoveds = _personnelApplication?.GetRemove()
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
                    var commnd = new PersonnelRemoved()
                    {
                        idAgencies = idAgencies,
                        PersonnelRemoveds = _personnelApplication?.GetInActive(idAgencies)
                    };
                    return Partial("./Actived", commnd);
                }
                else
                {
                    var commnd = new PersonnelRemoved()
                    {
                        idAgencies = idAgencies,
                        PersonnelRemoveds = _personnelApplication?.GetInActive()
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
                var result = _personnelApplication?.GetDetails(id);
                result.Agencies = _agenciesApplication?.GetViewModel();
                result.IdAgencies = agenciesId;
                return Partial("Edit", result);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public JsonResult OnPostEdit(PersonnelEdit command)
        {
            var result = _personnelApplication?.Edit(command);
            return new JsonResult(result);
        }
        public JsonResult OnGetInActive(int id)
        {
            var result = _personnelApplication?.InActive(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetActive(int id)
        {
            var result = _personnelApplication?.Active(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetRemove(int id)
        {
            var result = _personnelApplication?.Remove(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetReset(int id)
        {
            var result = _personnelApplication?.Reset(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetDelete(int id)
        {
            var result = _personnelApplication?.Delete(id);
            return new JsonResult(result);
        }
        public IActionResult OnGetSaved(int id)
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.SavedGeneral == GeneralPermissions.SavedGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var Personnel = _personnelApplication?.GetViewModel().Where(x => x.Id == id).FirstOrDefault();
                var commnd = new PersonnelViewModel()
                {
                    FullName = Personnel?.FullName,
                    User_Name = Personnel?.User_Name,
                    SaveDate = Personnel?.SaveDate,
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