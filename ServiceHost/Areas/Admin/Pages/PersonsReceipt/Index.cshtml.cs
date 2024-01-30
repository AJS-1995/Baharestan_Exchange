using _0_Framework.Application;
using _0_Framework.Application.Auth;
using _01_QueryManagement.Contracts.Permissions.General;
using Configuration.Permissions.General;
using Contracts.AgenciesContracts;
using Contracts.PersonsReceiptContracts;
using Contracts.MoneyContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Contracts.PersonsContracts;
using Contracts.SafeBoxContracts;

namespace ServiceHost.Areas.Admin.Pages.PersonsReceipt
{
    public class IndexModel : PageModel
    {
        public int idAgencies;
        public GeneralPermissionQueryModel? permissionQueryModels;
        private readonly IGeneralPermissionQueryModel? _permissionQueryModel;
        public List<PersonsViewModel>? Persons;
        private readonly IPersonsReceiptApplication? _personsReceiptApplication;
        private readonly IMoneyApplication? _moneyApplication;
        private readonly IAuthHelper? _authHelper;
        private readonly IAgenciesApplication? _agenciesApplication;
        private readonly IPersonsApplication? _personsApplication;
        private readonly ISafeBoxApplication? _safeBoxApplication;
        public IndexModel(IGeneralPermissionQueryModel? permissionQueryModel, IPersonsReceiptApplication? PersonsReceiptApplication, IMoneyApplication? moneyApplication, IAuthHelper? authHelper, IAgenciesApplication? agenciesApplication, IPersonsApplication? personsApplication, ISafeBoxApplication? safeBoxApplication)
        {
            _permissionQueryModel = permissionQueryModel;
            _personsReceiptApplication = PersonsReceiptApplication;
            _moneyApplication = moneyApplication;
            _authHelper = authHelper;
            _agenciesApplication = agenciesApplication;
            _personsApplication = personsApplication;
            _safeBoxApplication = safeBoxApplication;
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
                    Persons = _personsApplication?.GetViewModel(idAgencies);
                }
                else
                {
                    Persons = _personsApplication?.GetViewModel();
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
                var persons = _personsApplication?.GetViewModel();
                var safeBoxs = _safeBoxApplication?.GetViewModel();
                if (agenciesId != 0)
                {
                    persons = _personsApplication?.GetViewModel(agenciesId);
                    safeBoxs = _safeBoxApplication?.GetViewModel(agenciesId);
                }
                var command = new PersonsReceiptCreate()
                {
                    IdAgencies = agenciesId,
                    Date = DateTime.Now.ToFarsiFull(),
                    Moneys = _moneyApplication?.GetViewModel(),
                    Persons = persons,
                    SafeBoxs = safeBoxs,
                    Agencies = _agenciesApplication?.GetViewModel()
                };
                return Partial("./Create", command);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public JsonResult OnPostCreate(PersonsReceiptCreate command)
        {
            var result = _personsReceiptApplication?.Create(command);
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
                    var commnd = new PersonsReceiptRemoved()
                    {
                        idAgencies = idAgencies,
                        PersonsReceiptRemoveds = _personsReceiptApplication?.GetRemove(idAgencies)
                    };
                    return Partial("./Removed", commnd);
                }
                else
                {
                    var commnd = new PersonsReceiptRemoved()
                    {
                        PersonsReceiptRemoveds = _personsReceiptApplication?.GetRemove()
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
                    var commnd = new PersonsReceiptRemoved()
                    {
                        idAgencies = idAgencies,
                        PersonsReceiptRemoveds = _personsReceiptApplication?.GetInActive(idAgencies)
                    };
                    return Partial("./Actived", commnd);
                }
                else
                {
                    var commnd = new PersonsReceiptRemoved()
                    {
                        PersonsReceiptRemoveds = _personsReceiptApplication?.GetInActive()
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
                var result = _personsReceiptApplication?.GetDetails(id);
                result.Moneys = _moneyApplication?.GetViewModel();
                if (agenciesId != 0)
                {
                    result.Persons = _personsApplication?.GetViewModel(agenciesId);
                    result.SafeBoxs = _safeBoxApplication?.GetViewModel(agenciesId);
                }
                else
                {
                    result.Persons = _personsApplication?.GetViewModel();
                    result.SafeBoxs = _safeBoxApplication?.GetViewModel();
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
        public JsonResult OnPostEdit(PersonsReceiptEdit command)
        {
            var result = _personsReceiptApplication?.Edit(command);
            return new JsonResult(result);
        }
        public JsonResult OnGetInActive(long id)
        {
            var result = _personsReceiptApplication?.InActive(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetActive(long id)
        {
            var result = _personsReceiptApplication?.Active(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetRemove(long id)
        {
            var result = _personsReceiptApplication?.Remove(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetReset(long id)
        {
            var result = _personsReceiptApplication?.Reset(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetDelete(long id)
        {
            var result = _personsReceiptApplication?.Delete(id);
            return new JsonResult(result);
        }
        public IActionResult OnGetSaved(long id)
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.SavedGeneral == GeneralPermissions.SavedGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var PersonsReceipt = _personsReceiptApplication?.GetViewModel().Where(x => x.Id == id).FirstOrDefault();
                var commnd = new PersonsReceiptViewModel()
                {
                    Date = PersonsReceipt?.Date,
                    UserName = PersonsReceipt?.UserName,
                    SaveDate = PersonsReceipt?.SaveDate,
                };
                return Partial("./Saved", commnd);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public IActionResult OnGetPerson(int agenciesid)
        {
            var result = _personsApplication?.GetViewModel(agenciesid);
            return new JsonResult(result);
        }
        public IActionResult OnGetSafeBox(int agenciesid)
        {
            var result = _safeBoxApplication?.GetViewModel(agenciesid);
            return new JsonResult(result);
        }
    }
}