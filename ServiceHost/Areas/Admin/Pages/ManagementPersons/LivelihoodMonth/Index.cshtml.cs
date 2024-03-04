using _0_Framework.Application.Auth;
using _0_Framework.Application;
using _01_QueryManagement.Contracts.AccountingsContracts.PersonsModels;
using _01_QueryManagement.Contracts.Permissions.General;
using Configuration.Permissions.General;
using Contracts.ManagementPresonsContracts.LivelihoodMonthContracts;
using Contracts.ManagementPresonsContracts.PersonsContracts;
using Contracts.MoneyContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Contracts.ManagementPresonsContracts.LivelihoodContracts;
using Application;

namespace ServiceHost.Areas.Admin.Pages.ManagementPersons.LivelihoodMonth
{
    public class IndexModel : PageModel
    {
        public int idAgencies;
        public int PersonsId;
        public string? PersonsName;
        public GeneralPermissionQueryModel? permissionQueryModels;
        private readonly IGeneralPermissionQueryModel? _permissionQueryModel;
        public List<LivelihoodMonthViewModel>? LivelihoodMonth;
        private readonly ILivelihoodMonthApplication? _LivelihoodMonthApplication;
        private readonly IMoneyApplication? _moneyApplication;
        private readonly IAuthHelper? _authHelper;
        private readonly IPersonsApplication? _personsApplication;
        private readonly IPersonsModels _personsModels;
        private readonly ILivelihoodApplication? _LivelihoodApplication;
        public IndexModel(IGeneralPermissionQueryModel? permissionQueryModel, ILivelihoodMonthApplication? LivelihoodMonthApplication, IMoneyApplication? moneyApplication, IAuthHelper? authHelper, IPersonsApplication? personsApplication, IPersonsModels personsModels, ILivelihoodApplication? livelihoodApplication)
        {
            _permissionQueryModel = permissionQueryModel;
            _LivelihoodMonthApplication = LivelihoodMonthApplication;
            _moneyApplication = moneyApplication;
            _authHelper = authHelper;
            _personsApplication = personsApplication;
            _personsModels = personsModels;
            _LivelihoodApplication = livelihoodApplication;
        }
        public IActionResult OnGet(int personsId)
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.ListGeneral == GeneralPermissions.ListGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                permissionQueryModels = _permissionQueryModel?.GetGeneral();
                var agenciesId = _authHelper.CurrentAgenciesId();
                var persons = _personsApplication?.GetDetails(personsId);
                _personsModels.LivelihoodMonthModelss();
                idAgencies = agenciesId;
                PersonsId = personsId;
                PersonsName = persons?.Name;
                if (idAgencies != 0)
                {
                    if (idAgencies == persons.AgenciesId)
                    {
                        LivelihoodMonth = _LivelihoodMonthApplication?.GetViewModel(idAgencies).Where(x => x.PersonsId == personsId).ToList();
                        return Page();
                    }
                    else
                    {
                        return Redirect("/Index");
                    }
                }
                else
                {
                    LivelihoodMonth = _LivelihoodMonthApplication?.GetViewModel().Where(x => x.PersonsId == personsId).ToList();
                    return Page();
                }
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public IActionResult OnGetCreate(int personsId)
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.AddGeneral == GeneralPermissions.AddGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var persons = _personsApplication?.GetDetails(personsId);
                int agenciesId = persons.AgenciesId;
                var dates = DateTime.Now.ToFarsi();
                var dyears = Convert.ToInt32(dates.Substring(0, 4));
                var dmonths = Convert.ToInt32(dates.Substring(5, 2));
                var command = new LivelihoodMonthCreate()
                {
                    IdAgencies = agenciesId,
                    Year = dyears,
                    Month = dmonths,
                    Money = _moneyApplication?.GetViewModel(),
                    Livelihoods = _LivelihoodApplication?.GetViewModel().Where(x => x.PersonsId == personsId).ToList(),
                    PersonName = persons.Name,
                    AgenciesId = agenciesId,
                    PersonsId = personsId,
                };
                return Partial("./Create", command);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public IActionResult OnPostCreate(LivelihoodMonthCreate command)
        {
            var result = _LivelihoodMonthApplication?.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemoved(int personsId)
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.RemovedGeneral == GeneralPermissions.RemovedGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var agenciesId = _authHelper.CurrentAgenciesId();
                idAgencies = agenciesId;
                if (idAgencies != 0)
                {
                    var commnd = new LivelihoodMonthRemoved()
                    {
                        idAgencies = idAgencies,
                        LivelihoodMonthRemoveds = _LivelihoodMonthApplication?.GetRemove(idAgencies).Where(x => x.PersonsId == personsId).ToList(),
                        PersonsId = personsId,
                    };
                    return Partial("./Removed", commnd);
                }
                else
                {
                    var commnd = new LivelihoodMonthRemoved()
                    {
                        LivelihoodMonthRemoveds = _LivelihoodMonthApplication?.GetRemove().Where(x => x.PersonsId == personsId).ToList(),
                        PersonsId = personsId,
                    };
                    return Partial("./Removed", commnd);
                }
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public IActionResult OnGetActived(int personsId)
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.ActivedGeneral == GeneralPermissions.ActivedGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var agenciesId = _authHelper.CurrentAgenciesId();
                idAgencies = agenciesId;
                if (idAgencies != 0)
                {
                    var commnd = new LivelihoodMonthRemoved()
                    {
                        idAgencies = idAgencies,
                        LivelihoodMonthRemoveds = _LivelihoodMonthApplication?.GetInActive(idAgencies).Where(x => x.PersonsId == personsId).ToList(),
                        PersonsId = personsId,
                    };
                    return Partial("./Actived", commnd);
                }
                else
                {
                    var commnd = new LivelihoodMonthRemoved()
                    {
                        LivelihoodMonthRemoveds = _LivelihoodMonthApplication?.GetInActive().Where(x => x.PersonsId == personsId).ToList(),
                        PersonsId = personsId,
                    };
                    return Partial("./Actived", commnd);
                }
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public IActionResult OnGetEdit(long personsId)
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.EditGeneral == GeneralPermissions.EditGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var result = _LivelihoodMonthApplication?.GetDetails(personsId);
                var persons = _personsApplication?.GetDetails(result.PersonsId);
                int agenciesId = persons.AgenciesId;
                result.Money = _moneyApplication?.GetViewModel();
                result.Livelihoods = _LivelihoodApplication?.GetViewModel().Where(x => x.PersonsId == result.PersonsId).ToList();
                result.IdAgencies = agenciesId;
                result.PersonName = persons.Name;
                return Partial("Edit", result);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public IActionResult OnPostEdit(LivelihoodMonthEdit command)
        {
            var result = _LivelihoodMonthApplication?.Edit(command);
            return new JsonResult(result);
        }
        public JsonResult OnGetInActive(long id)
        {
            var result = _LivelihoodMonthApplication?.InActive(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetActive(long id)
        {
            var result = _LivelihoodMonthApplication?.Active(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetRemove(long id)
        {
            var result = _LivelihoodMonthApplication?.Remove(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetReset(long id)
        {
            var result = _LivelihoodMonthApplication?.Reset(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetDelete(long id)
        {
            var result = _LivelihoodMonthApplication?.Delete(id);
            return new JsonResult(result);
        }
        public IActionResult OnGetSaved(long personsId)
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.SavedGeneral == GeneralPermissions.SavedGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var LivelihoodMonth = _LivelihoodMonthApplication?.GetViewModel().Where(x => x.Id == personsId).FirstOrDefault();
                var commnd = new LivelihoodMonthViewModel()
                {
                    Year = LivelihoodMonth.Year,
                    Month = LivelihoodMonth.Month,
                    UserName = LivelihoodMonth?.UserName,
                    SaveDate = LivelihoodMonth?.SaveDate,
                    PersonsId = LivelihoodMonth.PersonsId,
                };
                return Partial("./Saved", commnd);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public JsonResult OnGetName(long id)
        {
            var result = _LivelihoodMonthApplication?.GetDetails(id);
            return new JsonResult(result);
        }
        public IActionResult OnGetLivelihood(int livelihoodId)
        {
            var result = _LivelihoodApplication?.GetDetails(livelihoodId);
            return new JsonResult(result);
        }
    }
}