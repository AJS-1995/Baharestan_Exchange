using _0_Framework.Application;
using _01_QueryManagement.Contracts.Permissions.General;
using Configuration.Permissions.General;
using Contracts.DailyRateContracts;
using Contracts.MoneyContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.DailyRate
{
    public class IndexModel : PageModel
    {
        public GeneralPermissionQueryModel? permissionQueryModels;
        private readonly IGeneralPermissionQueryModel? _permissionQueryModel;
        public List<DailyRateViewModel>? DailyRate;
        private readonly IDailyRateApplication? _dailyRateApplication;
        private readonly IMoneyApplication? _moneyApplication;
        public IndexModel(IGeneralPermissionQueryModel? permissionQueryModel, IDailyRateApplication? DailyRateApplication, IMoneyApplication? moneyApplication)
        {
            _permissionQueryModel = permissionQueryModel;
            _dailyRateApplication = DailyRateApplication;
            _moneyApplication = moneyApplication;
        }
        public IActionResult OnGet()
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.ListGeneral == GeneralPermissions.ListGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                DailyRate = _dailyRateApplication?.GetViewModel();
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
                var command = new DailyRateCreate();
                command.DateDay = DateTime.Now.ToFarsiFull();
                command.Moneys = _moneyApplication?.GetViewModel();
                return Partial("./Create", command);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public JsonResult OnPostCreate(DailyRateCreate command)
        {
            var result = _dailyRateApplication?.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemoved()
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.RemovedGeneral == GeneralPermissions.RemovedGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var commnd = new DailyRateRemoved()
                {
                    DailyRateRemoveds = _dailyRateApplication?.GetRemove()
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
                var commnd = new DailyRateRemoved()
                {
                    DailyRateRemoveds = _dailyRateApplication?.GetInActive()
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
                var result = _dailyRateApplication?.GetDetails(id);
                result.Moneys = _moneyApplication?.GetViewModel();
                return Partial("Edit", result);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public JsonResult OnPostEdit(DailyRateEdit command)
        {
            var result = _dailyRateApplication?.Edit(command);
            return new JsonResult(result);
        }
        public JsonResult OnGetInActive(int id)
        {
            var result = _dailyRateApplication?.InActive(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetActive(int id)
        {
            var result = _dailyRateApplication?.Active(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetRemove(int id)
        {
            var result = _dailyRateApplication?.Remove(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetReset(int id)
        {
            var result = _dailyRateApplication?.Reset(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetDelete(int id)
        {
            var result = _dailyRateApplication?.Delete(id);
            return new JsonResult(result);
        }
        public IActionResult OnGetSaved(int id)
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.SavedGeneral == GeneralPermissions.SavedGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var DailyRate = _dailyRateApplication?.GetViewModel().Where(x => x.Id == id).FirstOrDefault();
                var commnd = new DailyRateViewModel()
                {
                    DateDay = DailyRate?.DateDay,
                    UserName = DailyRate?.UserName,
                    SaveDate = DailyRate?.SaveDate,
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