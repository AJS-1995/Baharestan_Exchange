using _0_Framework.Application;
using _0_Framework.Application.Auth;
using _01_QueryManagement.Contracts.Permissions.General;
using Configuration.Permissions.General;
using Contracts.MoneyContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Contracts.SafeBoxContracts;
using Contracts.ManagementPresonsContracts.PersonsContracts;
using Contracts.ManagementPresonsContracts.PersonsReceiptContracts;
using Contracts.ManagementPresonsContracts.PersonsMoneyExchangeContracts;
using _01_QueryManagement.Contracts.AccountingsContracts.PersonsModels;

namespace ServiceHost.Areas.Admin.Pages.PersonsReceipt
{
    public class IndexModel : PageModel
    {
        public int idAgencies;
        public int PersonsId;
        public string? PersonsName;
        public GeneralPermissionQueryModel? permissionQueryModels;
        private readonly IGeneralPermissionQueryModel? _permissionQueryModel;
        public List<PersonsReceiptViewModel>? PersonsReceipt;
        public List<PersonsModels>? PersonsAccounting;
        public List<PersonsMoneyExchangeViewModel>? PersonsMoneyExchangeViewModels;
        private readonly IPersonsReceiptApplication? _personsReceiptApplication;
        private readonly IMoneyApplication? _moneyApplication;
        private readonly IAuthHelper? _authHelper;
        private readonly IPersonsApplication? _personsApplication;
        private readonly ISafeBoxApplication? _safeBoxApplication;
        private readonly IPersonsModels _personsModels;
        private readonly IPersonsMoneyExchangeApplication? _personsMoneyExchangeApplication;
        public IndexModel(IGeneralPermissionQueryModel? permissionQueryModel, IPersonsReceiptApplication? PersonsReceiptApplication, IMoneyApplication? moneyApplication, IAuthHelper? authHelper, IPersonsApplication? personsApplication, ISafeBoxApplication? safeBoxApplication, IPersonsModels personsModels, IPersonsMoneyExchangeApplication personsMoneyExchangeApplication)
        {
            _permissionQueryModel = permissionQueryModel;
            _personsReceiptApplication = PersonsReceiptApplication;
            _moneyApplication = moneyApplication;
            _authHelper = authHelper;
            _personsApplication = personsApplication;
            _safeBoxApplication = safeBoxApplication;
            _personsModels = personsModels;
            _personsMoneyExchangeApplication = personsMoneyExchangeApplication;
        }
        public IActionResult OnGet(int personsId)
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.ListGeneral == GeneralPermissions.ListGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                permissionQueryModels = _permissionQueryModel?.GetGeneral();
                var agenciesId = _authHelper.CurrentAgenciesId();
                var persons = _personsApplication?.GetDetails(personsId);
                idAgencies = agenciesId;
                PersonsId = personsId;
                PersonsName = persons?.Name;
                if (idAgencies != 0)
                {
                    if (idAgencies == persons.AgenciesId)
                    {
                        PersonsReceipt = _personsReceiptApplication?.GetViewModel(idAgencies).Where(x => x.PersonsId == personsId).ToList();
                        PersonsAccounting = _personsModels?.PersonsModelss()?.Where(x => x.PersonsId == personsId).ToList();
                        PersonsMoneyExchangeViewModels = _personsMoneyExchangeApplication?.GetViewModel(idAgencies)?.Where(x => x.PersonsId == personsId).ToList();
                        return Page();
                    }
                    else
                    {
                        return Redirect("/Index");
                    }
                }
                else
                {
                    PersonsReceipt = _personsReceiptApplication?.GetViewModel().Where(x => x.PersonsId == personsId).ToList();
                    PersonsAccounting = _personsModels?.PersonsModelss()?.Where(x => x.PersonsId == personsId).ToList();
                    PersonsMoneyExchangeViewModels = _personsMoneyExchangeApplication?.GetViewModel()?.Where(x => x.PersonsId == personsId).ToList();
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
                var command = new PersonsReceiptCreate()
                {
                    IdAgencies = agenciesId,
                    Date = DateTime.Now.ToFarsiFull(),
                    Moneys = _moneyApplication?.GetViewModel(),
                    SafeBoxs = _safeBoxApplication?.GetViewModel(agenciesId),
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
        public IActionResult OnPostCreate(PersonsReceiptCreate command)
        {
            var result = _personsReceiptApplication?.Create(command);
            return RedirectToPage("./Print_PR", result);
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
                    var commnd = new PersonsReceiptRemoved()
                    {
                        idAgencies = idAgencies,
                        PersonsReceiptRemoveds = _personsReceiptApplication?.GetRemove(idAgencies).Where(x=> x.PersonsId == personsId).ToList(),
                        PersonsId = personsId,
                    };
                    return Partial("./Removed", commnd);
                }
                else
                {
                    var commnd = new PersonsReceiptRemoved()
                    {
                        PersonsReceiptRemoveds = _personsReceiptApplication?.GetRemove().Where(x => x.PersonsId == personsId).ToList(),
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
                    var commnd = new PersonsReceiptRemoved()
                    {
                        idAgencies = idAgencies,
                        PersonsReceiptRemoveds = _personsReceiptApplication?.GetInActive(idAgencies).Where(x => x.PersonsId == personsId).ToList(),
                        PersonsId = personsId,
                    };
                    return Partial("./Actived", commnd);
                }
                else
                {
                    var commnd = new PersonsReceiptRemoved()
                    {
                        PersonsReceiptRemoveds = _personsReceiptApplication?.GetInActive().Where(x => x.PersonsId == personsId).ToList(),
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
        public IActionResult OnGetEdit(long id)
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.EditGeneral == GeneralPermissions.EditGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var result = _personsReceiptApplication?.GetDetails(id);
                var persons = _personsApplication?.GetDetails(result.PersonsId);
                int agenciesId = persons.AgenciesId;
                result.Moneys = _moneyApplication?.GetViewModel();
                result.SafeBoxs = _safeBoxApplication?.GetViewModel(agenciesId);
                result.IdAgencies = agenciesId;
                result.PersonName = persons.Name;
                return Partial("Edit", result);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public IActionResult OnPostEdit(PersonsReceiptEdit command)
        {
            var result = _personsReceiptApplication?.Edit(command);
            return RedirectToPage("./Print_PR", result);
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
                    PersonsId = PersonsReceipt.PersonsId,
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
        public IActionResult OnGetPhoto(int id, string name)
        {
            var result = _personsReceiptApplication?.GetViewModel().Where(x => x.Id == id).FirstOrDefault();
            if (result != null)
            {
                var commnd = new PersonsReceiptPhoto();
                if (name == "fingerprint")
                {
                    commnd = new PersonsReceiptPhoto()
                    {
                        Photo = result.Fingerprint,
                        PersonsName = result.PersonName,
                        PhotoName = "نشان انگشت",
                        PersonsId = result.PersonsId,
                    };
                }
                else
                {
                    if (name == "picture")
                    {
                        commnd = new PersonsReceiptPhoto()
                        {
                            Photo = result.Picture,
                            PersonsName = result.PersonName,
                            PhotoName = "عکس",
                            PersonsId = result.PersonsId,
                        };
                    }
                }
                return Partial("./Photo", commnd);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public JsonResult OnGetName(long id)
        {
            var result = _personsReceiptApplication?.GetDetails(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetDate(long id)
        {
            var result = _personsMoneyExchangeApplication?.GetDetails(id);
            return new JsonResult(result);
        }
    }
}