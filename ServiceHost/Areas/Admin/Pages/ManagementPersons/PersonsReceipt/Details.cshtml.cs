using _0_Framework.Application;
using _0_Framework.Application.Auth;
using _01_QueryManagement.Contracts.AccountingsContracts.PersonsModels;
using _01_QueryManagement.Contracts.Permissions.General;
using Configuration.Permissions.General;
using Contracts.AgenciesContracts;
using Contracts.ManagementPresonsContracts.PersonsContracts;
using Contracts.ManagementPresonsContracts.PersonsReceiptContracts;
using Contracts.MoneyContracts;
using Contracts.SafeBoxContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.PersonsReceipt
{
    public class DetailsModel : PageModel
    {
        public int idAgencies;
        public int Persons_Id;
        public string? Persons_Name;
        public GeneralPermissionQueryModel? permissionQueryModels;
        private readonly IGeneralPermissionQueryModel? _permissionQueryModel;
        public List<PersonsReceiptViewModel>? PersonsReceipt;
        public List<PersonsModels>? PersonsAccounting;
        private readonly IPersonsReceiptApplication? _personsReceiptApplication;
        private readonly IMoneyApplication? _moneyApplication;
        private readonly IAuthHelper? _authHelper;
        private readonly IAgenciesApplication? _agenciesApplication;
        private readonly IPersonsApplication? _personsApplication;
        private readonly ISafeBoxApplication? _safeBoxApplication;
        private readonly IPersonsModels _personsModels;
        public DetailsModel(IGeneralPermissionQueryModel? permissionQueryModel, IPersonsReceiptApplication? PersonsReceiptApplication, IMoneyApplication? moneyApplication, IAuthHelper? authHelper, IAgenciesApplication? agenciesApplication, IPersonsApplication? personsApplication, ISafeBoxApplication? safeBoxApplication, IPersonsModels personsModels)
        {
            _permissionQueryModel = permissionQueryModel;
            _personsReceiptApplication = PersonsReceiptApplication;
            _moneyApplication = moneyApplication;
            _authHelper = authHelper;
            _agenciesApplication = agenciesApplication;
            _personsApplication = personsApplication;
            _safeBoxApplication = safeBoxApplication;
            _personsModels = personsModels;
        }
        public IActionResult OnGet(int persons_id)
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.ListGeneral == GeneralPermissions.ListGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                permissionQueryModels = _permissionQueryModel?.GetGeneral();
                var agenciesId = _authHelper.CurrentAgenciesId();
                var persons = _personsApplication?.GetDetails(persons_id);
                idAgencies = agenciesId;
                Persons_Id = persons_id;
                Persons_Name = persons?.Name;
                if (idAgencies != 0)
                {
                    if (idAgencies == persons.AgenciesId)
                    {
                        PersonsReceipt = _personsReceiptApplication?.GetViewModel(idAgencies).Where(x => x.PersonId == persons_id).ToList();
                        PersonsAccounting = _personsModels?.PersonsModelss()?.Where(x => x.PersonsId == persons_id).ToList();
                        return Page();
                    }
                    else
                    {
                        return Redirect("/Index");
                    }
                }
                else
                {
                    PersonsReceipt = _personsReceiptApplication?.GetViewModel().Where(x => x.PersonId == persons_id).ToList();
                    PersonsAccounting = _personsModels?.PersonsModelss()?.Where(x => x.PersonsId == persons_id).ToList();
                    return Page();
                }
            }
            else
            {
                return Redirect("/Details");
            }
        }
        public IActionResult OnGetCreateDetails(int persons_id)
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.AddGeneral == GeneralPermissions.AddGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var persons = _personsApplication?.GetDetails(persons_id);
                int agenciesId = persons.AgenciesId;
                var command = new PersonsReceiptCreate()
                {
                    IdAgencies = agenciesId,
                    Date = DateTime.Now.ToFarsiFull(),
                    Moneys = _moneyApplication?.GetViewModel(),
                    SafeBoxs = _safeBoxApplication?.GetViewModel(agenciesId),
                    PersonName = persons.Name,
                    AgenciesId = agenciesId,
                    PersonId = persons_id,
                };
                return Partial("./CreateDetails", command);
            }
            else
            {
                return Redirect("/Details");
            }
        }
        public IActionResult OnGetEditDetails(long id)
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.EditGeneral == GeneralPermissions.EditGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var result = _personsReceiptApplication?.GetDetails(id);
                var persons = _personsApplication?.GetDetails(result.PersonId);
                int agenciesId = persons.AgenciesId;
                result.Moneys = _moneyApplication?.GetViewModel();
                result.SafeBoxs = _safeBoxApplication?.GetViewModel(agenciesId);
                result.IdAgencies = agenciesId;
                result.PersonName = persons.Name;
                return Partial("EditDetails", result);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public IActionResult OnGetRemoved(int persons_id)
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.RemovedGeneral == GeneralPermissions.RemovedGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var commnd = new PersonsReceiptRemoved()
                {
                    PersonsReceiptRemoveds = _personsReceiptApplication?.GetRemove().Where(x=> x.PersonId == persons_id).ToList(),
                };
                return Partial("./Removed", commnd);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public IActionResult OnGetActived(int persons_id)
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.ActivedGeneral == GeneralPermissions.ActivedGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var commnd = new PersonsReceiptRemoved()
                {
                    PersonsReceiptRemoveds = _personsReceiptApplication?.GetInActive().Where(x => x.PersonId == persons_id).ToList(),
                };
                return Partial("./Actived", commnd);
            }
            else
            {
                return Redirect("/Index");
            }
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
        public IActionResult OnGetMoneyTransfer(int persons_id)
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.AddGeneral == GeneralPermissions.AddGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var persons = _personsApplication?.GetDetails(persons_id);
                int agenciesId = persons.AgenciesId;
                var command = new PersonsReceiptCreate()
                {
                    IdAgencies = agenciesId,
                    Date = DateTime.Now.ToFarsiFull(),
                    Moneys = _moneyApplication?.GetViewModel(),
                    SafeBoxs = _safeBoxApplication?.GetViewModel(agenciesId),
                    PersonName = persons.Name,
                    AgenciesId = agenciesId,
                    PersonId = persons_id,
                };
                return Partial("./MoneyTransfer", command);
            }
            else
            {
                return Redirect("/Details");
            }
        }
    }
}