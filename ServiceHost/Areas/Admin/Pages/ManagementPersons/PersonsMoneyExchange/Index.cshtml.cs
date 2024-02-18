using _0_Framework.Application;
using _0_Framework.Application.Auth;
using _01_QueryManagement.Contracts.AccountingsContracts.PersonsModels;
using _01_QueryManagement.Contracts.Permissions.General;
using Configuration.Permissions.General;
using Contracts.ManagementPresonsContracts.PersonsContracts;
using Contracts.ManagementPresonsContracts.PersonsMoneyExchangeContracts;
using Contracts.MoneyContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.ManagementPersons.PersonsMoneyExchange
{
    public class IndexModel : PageModel
    {
        public int idAgencies;
        public int PersonsId;
        public string? PersonsName;
        public GeneralPermissionQueryModel? permissionQueryModels;
        private readonly IGeneralPermissionQueryModel? _permissionQueryModel;
        public List<PersonsMoneyExchangeViewModel>? PersonsMoneyExchangeViewModels;
        private readonly IPersonsMoneyExchangeApplication? _personsMoneyExchangeApplication;
        private readonly IPersonsApplication? _personsApplication;
        private readonly IPersonsModels _personsModels;
        private readonly IMoneyApplication? _moneyApplication;
        private readonly IAuthHelper? _authHelper;
        public IndexModel(IGeneralPermissionQueryModel? permissionQueryModel, IPersonsMoneyExchangeApplication? personsMoneyExchangeApplication, IPersonsApplication? personsApplication, IPersonsModels personsModels, IMoneyApplication? moneyApplication, IAuthHelper? authHelper)
        {
            _permissionQueryModel = permissionQueryModel;
            _personsMoneyExchangeApplication = personsMoneyExchangeApplication;
            _personsApplication = personsApplication;
            _personsModels = personsModels;
            _moneyApplication = moneyApplication;
            _authHelper = authHelper;
        }
        public void OnGet()
        {
        }
        public IActionResult OnGetCreate(int personsId)
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.AddGeneral == GeneralPermissions.AddGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var persons = _personsApplication?.GetDetails(personsId);
                int agenciesId = persons.AgenciesId;
                var command = new PersonsMoneyExchangeCreate()
                {
                    IdAgencies = agenciesId,
                    Date = DateTime.Now.ToFarsiFull(),
                    Moneys = _moneyApplication?.GetViewModel(),
                    AgenciesId = agenciesId,
                    PersonId = personsId,
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
            return new JsonResult(result);
        }
        public IActionResult OnGetMoney(int moneyId, int personId)
        {
            var rest = _personsModels.PersonsModelss()?.Where(x => x.PersonId == personId && x.MoneyId == moneyId).ToList();
            decimal result = 0;
            if (rest?.Count != 0)
            {
                result = rest.FirstOrDefault().Rest;
            }
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.EditGeneral == GeneralPermissions.EditGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var result = _personsMoneyExchangeApplication?.GetDetails(id);
                var persons = _personsApplication?.GetDetails(result.PersonId);
                int agenciesId = persons.AgenciesId;
                result.Moneys = _moneyApplication?.GetViewModel();
                result.IdAgencies = agenciesId;
                result.PersonName = persons.Name;
                result.AgenciesId = agenciesId;
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
            return new JsonResult(result);
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
                    PersonId = PersonsMoneyExchange.PersonId,
                    PersonName = PersonsMoneyExchange.PersonName,
                };
                return Partial("./Saved", commnd);
            }
            else
            {
                return Redirect("/Index");
            }
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
                    var commnd = new PersonsMoneyExchangeRemoved()
                    {
                        idAgencies = idAgencies,
                        PersonsMoneyExchangeRemoveds = _personsMoneyExchangeApplication?.GetRemove(idAgencies).Where(x => x.PersonId == personsId).ToList(),
                        PersonId = personsId,
                    };
                    return Partial("./Removed", commnd);
                }
                else
                {
                    var commnd = new PersonsMoneyExchangeRemoved()
                    {
                        PersonsMoneyExchangeRemoveds = _personsMoneyExchangeApplication?.GetRemove().Where(x => x.PersonId == personsId).ToList(),
                        PersonId = personsId,
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
                    var commnd = new PersonsMoneyExchangeRemoved()
                    {
                        idAgencies = idAgencies,
                        PersonsMoneyExchangeRemoveds = _personsMoneyExchangeApplication?.GetInActive(idAgencies).Where(x => x.PersonId == personsId).ToList(),
                        PersonId = personsId,
                    };
                    return Partial("./Actived", commnd);
                }
                else
                {
                    var commnd = new PersonsMoneyExchangeRemoved()
                    {
                        PersonsMoneyExchangeRemoveds = _personsMoneyExchangeApplication?.GetInActive().Where(x => x.PersonId == personsId).ToList(),
                        PersonId = personsId,
                    };
                    return Partial("./Actived", commnd);
                }
            }
            else
            {
                return Redirect("/Index");
            }
        }
    }
}
