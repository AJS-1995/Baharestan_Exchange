using _0_Framework.Application;
using _0_Framework.Application.Auth;
using _01_QueryManagement.Contracts.Permissions.General;
using Configuration.Permissions.General;
using Contracts.AgenciesContracts;
using Contracts.MoneyContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Contracts.ManagementPresonsContracts.PersonsContracts;
using Contracts.ManagementPresonsContracts.PersonsMoneyExchangeContracts;
using Contracts.ManagementPresonsContracts.PersonsReceiptContracts;
using _01_QueryManagement.Contracts.AccountingsContracts.PersonsModels;

namespace ServiceHost.Areas.Admin.Pages.ManagementPersons.PersonsMoneyExchange
{
    public class IndexModel : PageModel
    {
        public int idAgencies;
        public GeneralPermissionQueryModel? permissionQueryModels;
        private readonly IGeneralPermissionQueryModel? _permissionQueryModel;
        public List<PersonsViewModel>? Persons;
        private readonly IPersonsMoneyExchangeApplication? _personsMoneyExchangeApplication;
        private readonly IMoneyApplication? _moneyApplication;
        private readonly IAuthHelper? _authHelper;
        private readonly IAgenciesApplication? _agenciesApplication;
        private readonly IPersonsApplication? _personsApplication;
        private readonly IPersonsModels? _personsModels;
        public IndexModel(IGeneralPermissionQueryModel? permissionQueryModel, IPersonsMoneyExchangeApplication? personsMoneyExchangeApplication, IMoneyApplication? moneyApplication, IAuthHelper? authHelper, IAgenciesApplication? agenciesApplication, IPersonsApplication? personsApplication, IPersonsModels personsModels)
        {
            _permissionQueryModel = permissionQueryModel;
            _personsMoneyExchangeApplication = personsMoneyExchangeApplication;
            _moneyApplication = moneyApplication;
            _authHelper = authHelper;
            _agenciesApplication = agenciesApplication;
            _personsApplication = personsApplication;
            _personsModels = personsModels;
        }
        public IActionResult OnGet()
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.ListGeneral == GeneralPermissions.ListGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
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
        public IActionResult OnGetPersonsCreate(int personsـid)
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.AddGeneral == GeneralPermissions.AddGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var persons = _personsApplication?.GetDetails(personsـid);
                int agenciesId = persons.AgenciesId;
                var command = new PersonsMoneyExchangeCreate()
                {
                    IdAgencies = agenciesId,
                    Date = DateTime.Now.ToFarsiFull(),
                    Moneys = _moneyApplication?.GetViewModel(),
                    AgenciesId = agenciesId,
                    PersonId = personsـid,
                };
                return Partial("./Create", command);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public IActionResult OnPostCreate(PersonsMoneyExchangeCreate command)
        {
            var result = _personsMoneyExchangeApplication?.Create(command);
            return RedirectToPage("./Print_PR", result);
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
                    var commnd = new PersonsMoneyExchangeRemoved()
                    {
                        idAgencies = idAgencies,
                        PersonsMoneyExchangeRemoveds = _personsMoneyExchangeApplication?.GetRemove(idAgencies)
                    };
                    return Partial("./Removed", commnd);
                }
                else
                {
                    var commnd = new PersonsMoneyExchangeRemoved()
                    {
                        PersonsMoneyExchangeRemoveds = _personsMoneyExchangeApplication?.GetRemove()
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
                    var commnd = new PersonsMoneyExchangeRemoved()
                    {
                        idAgencies = idAgencies,
                        PersonsMoneyExchangeRemoveds = _personsMoneyExchangeApplication?.GetInActive(idAgencies)
                    };
                    return Partial("./Actived", commnd);
                }
                else
                {
                    var commnd = new PersonsMoneyExchangeRemoved()
                    {
                        PersonsMoneyExchangeRemoveds = _personsMoneyExchangeApplication?.GetInActive()
                    };
                    return Partial("./Actived", commnd);
                }
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
                var agenciesId = _authHelper.CurrentAgenciesId();
                var result = _personsMoneyExchangeApplication?.GetDetails(id);
                result.Moneys = _moneyApplication?.GetViewModel();
                if (agenciesId != 0)
                {
                    result.Personss = _personsApplication?.GetViewModel(agenciesId);
                }
                else
                {
                    result.Personss = _personsApplication?.GetViewModel();
                }
                result.Agencies = _agenciesApplication?.GetViewModel();
                result.IdAgencies = agenciesId;
                return Partial("Edit", result);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public IActionResult OnPostEdit(PersonsMoneyExchangeEdit command)
        {
            var result = _personsMoneyExchangeApplication?.Edit(command);
            return RedirectToPage("./Print_PR", result);
        }
        public JsonResult OnGetInActive(long id)
        {
            var result = _personsMoneyExchangeApplication?.InActive(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetActive(long id)
        {
            var result = _personsMoneyExchangeApplication?.Active(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetRemove(long id)
        {
            var result = _personsMoneyExchangeApplication?.Remove(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetReset(long id)
        {
            var result = _personsMoneyExchangeApplication?.Reset(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetDelete(long id)
        {
            var result = _personsMoneyExchangeApplication?.Delete(id);
            return new JsonResult(result);
        }
        public IActionResult OnGetSaved(long id)
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.SavedGeneral == GeneralPermissions.SavedGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var PersonsMoneyExchange = _personsMoneyExchangeApplication?.GetViewModel().Where(x => x.Id == id).FirstOrDefault();
                var commnd = new PersonsMoneyExchangeViewModel()
                {
                    Date = PersonsMoneyExchange?.Date,
                    UserName = PersonsMoneyExchange?.UserName,
                    SaveDate = PersonsMoneyExchange?.SaveDate,
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