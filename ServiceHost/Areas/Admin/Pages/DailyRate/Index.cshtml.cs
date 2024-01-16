using _0_Framework.Application;
using _0_Framework.Application.Auth;
using _01_QueryManagement.Contracts.Permissions.General;
using Configuration.Permissions.General;
using Contracts.AgenciesContracts;
using Contracts.DailyRateContracts;
using Contracts.ExchangeRateContracts;
using Contracts.MoneyContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.DailyRate
{
    public class IndexModel : PageModel
    {
        public int idAgencies;
        public GeneralPermissionQueryModel? permissionQueryModels;
        private readonly IGeneralPermissionQueryModel? _permissionQueryModel;
        public List<DailyRateViewModel>? DailyRate;
        private readonly IDailyRateApplication? _dailyRateApplication;
        private readonly IMoneyApplication? _moneyApplication;
        private readonly IAuthHelper? _authHelper;
        private readonly IAgenciesApplication? _agenciesApplication;
        private readonly IExchangeRateApplication? _exchangeRateApplication;
        public IndexModel(IGeneralPermissionQueryModel? permissionQueryModel, IDailyRateApplication? DailyRateApplication, IMoneyApplication? moneyApplication, IAuthHelper? authHelper, IAgenciesApplication? agenciesApplication, IExchangeRateApplication? exchangeRateApplication)
        {
            _permissionQueryModel = permissionQueryModel;
            _dailyRateApplication = DailyRateApplication;
            _moneyApplication = moneyApplication;
            _authHelper = authHelper;
            _agenciesApplication = agenciesApplication;
            _exchangeRateApplication = exchangeRateApplication;
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
                    DailyRate = _dailyRateApplication?.GetViewModel(idAgencies);
                }
                else
                {
                    DailyRate = _dailyRateApplication?.GetViewModel();
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
                var command = new DailyRateCreate()
                {
                    IdAgencies = agenciesId,
                    DateDay = DateTime.Now.ToFarsiFull(),
                    Moneys = _moneyApplication?.GetViewModel(),
                    Agencies = _agenciesApplication?.GetViewModel(),
                };
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
            var excommand = new ExchangeRateCreate()
            {
                AgenciesId = command.AgenciesId,
                Amount = command.Amount,
                IdAgencies = command.IdAgencies,
                DateDay = command.DateDay,
                MainMoneyId = command.MainMoneyId,
                PriceBey = command.PriceBey,
                PriceSell = command.PriceSell,
                SecondaryMoneyId = command.MainMoneyId
            };
            _exchangeRateApplication?.Create(excommand);
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
                    var commnd = new DailyRateRemoved()
                    {
                        idAgencies = idAgencies,
                        DailyRateRemoveds = _dailyRateApplication?.GetRemove(idAgencies)
                    };
                    return Partial("./Removed", commnd);
                }
                else
                {
                    var commnd = new DailyRateRemoved()
                    {
                        idAgencies = idAgencies,
                        DailyRateRemoveds = _dailyRateApplication?.GetRemove()
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
                    var commnd = new DailyRateRemoved()
                    {
                        idAgencies = idAgencies,
                        DailyRateRemoveds = _dailyRateApplication?.GetInActive(idAgencies)
                    };
                    return Partial("./Actived", commnd);
                }
                else
                {
                    var commnd = new DailyRateRemoved()
                    {
                        idAgencies = idAgencies,
                        DailyRateRemoveds = _dailyRateApplication?.GetInActive()
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
                var result = _dailyRateApplication?.GetDetails(id);
                result.Moneys = _moneyApplication?.GetViewModel();
                result.Agencies = _agenciesApplication?.GetViewModel();
                result.IdAgencies = agenciesId;
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
            var excommand = new ExchangeRateCreate()
            {
                AgenciesId = command.AgenciesId,
                Amount = command.Amount,
                IdAgencies = command.IdAgencies,
                DateDay = command.DateDay,
                MainMoneyId = command.MainMoneyId,
                PriceBey = command.PriceBey,
                PriceSell = command.PriceSell,
                SecondaryMoneyId = command.MainMoneyId
            };
            _exchangeRateApplication?.Create(excommand);
            return new JsonResult(result);
        }
        public IActionResult OnGetUpdate(int id)
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.EditGeneral == GeneralPermissions.EditGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var agenciesId = _authHelper.CurrentAgenciesId();
                var result = _dailyRateApplication?.GetDetails(id);
                result.Moneys = _moneyApplication?.GetViewModel();
                result.DateDay = DateTime.Now.ToFarsiFull();
                result.IdAgencies = agenciesId;
                return Partial("Update", result);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public JsonResult OnPostUpdate(DailyRateEdit command)
        {
            var result = _dailyRateApplication?.Edit(command);
            var excommand = new ExchangeRateCreate()
            {
                AgenciesId = command.AgenciesId,
                Amount = command.Amount,
                IdAgencies = command.IdAgencies,
                DateDay = command.DateDay,
                MainMoneyId = command.MainMoneyId,
                PriceBey = command.PriceBey,
                PriceSell = command.PriceSell,
                SecondaryMoneyId = command.MainMoneyId
            };
            _exchangeRateApplication?.Create(excommand);
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