using _0_Framework.Application;
using _01_QueryManagement.Contracts.Permissions.General;
using Configuration.Permissions.General;
using Contracts.ExchangeRateContracts;
using Contracts.MoneyContracts;
using Contracts.PersonnelContracts;
using Contracts.SafeBoxContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Personnel
{
    public class IndexModel : PageModel
    {
        public GeneralPermissionQueryModel? permissionQueryModels;
        private readonly IGeneralPermissionQueryModel? _permissionQueryModel;
        public List<PersonnelViewModel>? Personnel;
        private readonly IPersonnelApplication? _personnelApplication;
        private readonly IMoneyApplication? _moneyApplication;
        private readonly ISafeBoxApplication? _safeBoxApplication;
        public IndexModel(IGeneralPermissionQueryModel? permissionQueryModel, IPersonnelApplication? personnelApplication, IMoneyApplication? moneyApplication, ISafeBoxApplication? safeBoxApplication)
        {
            _permissionQueryModel = permissionQueryModel;
            _personnelApplication = personnelApplication;
            _moneyApplication = moneyApplication;
            _safeBoxApplication = safeBoxApplication;
        }
        public IActionResult OnGet()
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.ListGeneral == GeneralPermissions.ListGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                Personnel = _personnelApplication?.GetViewModel();
                permissionQueryModels = _permissionQueryModel?.GetGeneral();
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
                return Partial("./Create");
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
                var commnd = new PersonnelRemoved()
                {
                    PersonnelRemoveds = _personnelApplication?.GetRemove()
                };
                return Partial("./Removed", commnd);
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
                var commnd = new PersonnelRemoved()
                {
                    PersonnelRemoveds = _personnelApplication?.GetInActive()
                };
                return Partial("./Actived", commnd);
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
                var result = _personnelApplication?.GetDetails(id);
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