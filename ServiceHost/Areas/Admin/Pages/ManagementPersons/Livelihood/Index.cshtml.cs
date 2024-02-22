using _0_Framework.Application.Auth;
using _01_QueryManagement.Contracts.Permissions.General;
using Configuration.Permissions.General;
using Contracts.ManagementPresonsContracts.PersonsContracts;
using Contracts.ManagementPresonsContracts.LivelihoodContracts;
using Contracts.MoneyContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using _0_Framework.Application;
using _0_Framework.Application.PersonsAuth;

namespace ServiceHost.Areas.Admin.Pages.ManagementPersons.Livelihood
{
    public class IndexModel : PageModel
    {
        public int idAgencies;
        public int PersonsId;
        public string? PersonsName;
        public GeneralPermissionQueryModel? permissionQueryModels;
        private readonly IGeneralPermissionQueryModel? _permissionQueryModel;
        public List<LivelihoodViewModel>? Livelihood;
        private readonly ILivelihoodApplication? _LivelihoodApplication;
        private readonly IMoneyApplication? _moneyApplication;
        private readonly IAuthHelper? _authHelper;
        private readonly IPersonsApplication? _personsApplication;
        public IndexModel(IGeneralPermissionQueryModel? permissionQueryModel, ILivelihoodApplication? LivelihoodApplication, IMoneyApplication? moneyApplication, IAuthHelper? authHelper, IPersonsApplication? personsApplication)
        {
            _permissionQueryModel = permissionQueryModel;
            _LivelihoodApplication = LivelihoodApplication;
            _moneyApplication = moneyApplication;
            _authHelper = authHelper;
            _personsApplication = personsApplication;
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
                        Livelihood = _LivelihoodApplication?.GetViewModel(idAgencies).Where(x => x.PersonsId == personsId).ToList();
                        return Page();
                    }
                    else
                    {
                        return Redirect("/Index");
                    }
                }
                else
                {
                    Livelihood = _LivelihoodApplication?.GetViewModel().Where(x => x.PersonsId == personsId).ToList();
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
                var edate = DateTime.Now.AddYears(1);
                var p = edate.AddDays(-2);
                var command = new LivelihoodCreate()
                {
                    IdAgencies = agenciesId,
                    SDate = DateTime.Now.ToFarsi(),
                    EDate = p.ToFarsi(),
                    Money = _moneyApplication?.GetViewModel(),
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
        public IActionResult OnPostCreate(LivelihoodCreate command)
        {
            var result = _LivelihoodApplication?.Create(command);
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
                    var commnd = new LivelihoodRemoved()
                    {
                        idAgencies = idAgencies,
                        LivelihoodRemoveds = _LivelihoodApplication?.GetRemove(idAgencies).Where(x => x.PersonsId == personsId).ToList(),
                        PersonsId = personsId,
                    };
                    return Partial("./Removed", commnd);
                }
                else
                {
                    var commnd = new LivelihoodRemoved()
                    {
                        LivelihoodRemoveds = _LivelihoodApplication?.GetRemove().Where(x => x.PersonsId == personsId).ToList(),
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
                    var commnd = new LivelihoodRemoved()
                    {
                        idAgencies = idAgencies,
                        LivelihoodRemoveds = _LivelihoodApplication?.GetInActive(idAgencies).Where(x => x.PersonsId == personsId).ToList(),
                        PersonsId = personsId,
                    };
                    return Partial("./Actived", commnd);
                }
                else
                {
                    var commnd = new LivelihoodRemoved()
                    {
                        LivelihoodRemoveds = _LivelihoodApplication?.GetInActive().Where(x => x.PersonsId == personsId).ToList(),
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
        public IActionResult OnGetEdit(int id)
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.EditGeneral == GeneralPermissions.EditGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var result = _LivelihoodApplication?.GetDetails(id);
                var persons = _personsApplication?.GetDetails(result.PersonsId);
                int agenciesId = persons.AgenciesId;
                result.Money = _moneyApplication?.GetViewModel();
                result.IdAgencies = agenciesId;
                result.PersonName = persons.Name;
                return Partial("Edit", result);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public IActionResult OnPostEdit(LivelihoodEdit command)
        {
            var result = _LivelihoodApplication?.Edit(command);
            return new JsonResult(result);
        }
        public JsonResult OnGetInActive(int id)
        {
            var result = _LivelihoodApplication?.InActive(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetActive(int id)
        {
            var result = _LivelihoodApplication?.Active(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetRemove(int id)
        {
            var result = _LivelihoodApplication?.Remove(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetReset(int id)
        {
            var result = _LivelihoodApplication?.Reset(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetDelete(int id)
        {
            var result = _LivelihoodApplication?.Delete(id);
            return new JsonResult(result);
        }
        public IActionResult OnGetSaved(long id)
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.SavedGeneral == GeneralPermissions.SavedGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var Livelihood = _LivelihoodApplication?.GetViewModel().Where(x => x.Id == id).FirstOrDefault();
                var commnd = new LivelihoodViewModel()
                {
                    SDate = Livelihood.SDate,
                    EDate = Livelihood.EDate,
                    UserName = Livelihood?.UserName,
                    SaveDate = Livelihood?.SaveDate,
                    PersonsId = Livelihood.PersonsId,
                };
                return Partial("./Saved", commnd);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public JsonResult OnGetName(int id)
        {
            var result = _LivelihoodApplication?.GetDetails(id);
            return new JsonResult(result);
        }
    }
}