using _0_Framework.Application;
using _01_QueryManagement.Contracts.Permissions.General;
using Configuration.Permissions.General;
using Contracts.ExchangeRateContracts;
using Contracts.MoneyContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.ExchangeRate
{
    public class IndexModel : PageModel
    {
        public GeneralPermissionQueryModel? permissionQueryModels;
        private readonly IGeneralPermissionQueryModel? _permissionQueryModel;
        public List<ExchangeRateViewModel>? ExchangeRate;
        private readonly IExchangeRateApplication? _exchangeRateApplication;
        private readonly IMoneyApplication? _moneyApplication;
        public IndexModel(IGeneralPermissionQueryModel? permissionQueryModel, IExchangeRateApplication? ExchangeRateApplication, IMoneyApplication? moneyApplication)
        {
            _permissionQueryModel = permissionQueryModel;
            _exchangeRateApplication = ExchangeRateApplication;
            _moneyApplication = moneyApplication;
        }
        public IActionResult OnGet()
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.ListGeneral == GeneralPermissions.ListGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                ExchangeRate = _exchangeRateApplication?.GetViewModel();
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
                var command = new ExchangeRateCreate();
                command.DateDay = DateTime.Now.ToFarsiFull();
                command.Moneys = _moneyApplication?.GetViewModel();
                return Partial("./Create", command);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public JsonResult OnPostCreate(ExchangeRateCreate command)
        {
            var result = _exchangeRateApplication?.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemoved()
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.RemovedGeneral == GeneralPermissions.RemovedGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var commnd = new ExchangeRateRemoved()
                {
                    ExchangeRateRemoveds = _exchangeRateApplication?.GetRemove()
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
                var commnd = new ExchangeRateRemoved()
                {
                    ExchangeRateRemoveds = _exchangeRateApplication?.GetInActive()
                };
                return Partial("./Actived", commnd);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public IActionResult OnGetEdit(long id)
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.EditGeneral == GeneralPermissions.EditGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var result = _exchangeRateApplication?.GetDetails(id);
                result.Moneys = _moneyApplication?.GetViewModel();
                return Partial("Edit", result);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public JsonResult OnPostEdit(ExchangeRateEdit command)
        {
            var result = _exchangeRateApplication?.Edit(command);
            return new JsonResult(result);
        }
        public JsonResult OnGetInActive(long id)
        {
            var result = _exchangeRateApplication?.InActive(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetActive(long id)
        {
            var result = _exchangeRateApplication?.Active(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetRemove(long id)
        {
            var result = _exchangeRateApplication?.Remove(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetReset(long id)
        {
            var result = _exchangeRateApplication?.Reset(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetDelete(long id)
        {
            var result = _exchangeRateApplication?.Delete(id);
            return new JsonResult(result);
        }
        public IActionResult OnGetSaved(long id)
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.SavedGeneral == GeneralPermissions.SavedGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var ExchangeRate = _exchangeRateApplication?.GetViewModel().Where(x => x.Id == id).FirstOrDefault();
                var commnd = new ExchangeRateViewModel()
                {
                    DateDay = ExchangeRate?.DateDay,
                    UserName = ExchangeRate?.UserName,
                    SaveDate = ExchangeRate?.SaveDate,
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