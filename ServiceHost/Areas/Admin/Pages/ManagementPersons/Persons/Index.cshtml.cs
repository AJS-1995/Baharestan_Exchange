using _0_Framework.Application.Auth;
using _01_QueryManagement.Contracts.Permissions.General;
using Configuration.Permissions.General;
using Contracts.AgenciesContracts;
using Contracts.ManagementPresonsContracts.PersonsContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Persons
{
    public class IndexModel : PageModel
    {
        public int idAgencies;
        public GeneralPermissionQueryModel? permissionQueryModels;
        private readonly IGeneralPermissionQueryModel? _permissionQueryModel;
        public List<PersonsViewModel>? Persons;
        private readonly IPersonsApplication? _personsApplication;
        private readonly IAuthHelper? _authHelper;
        private readonly IAgenciesApplication? _agenciesApplication;
        public IndexModel(IGeneralPermissionQueryModel? permissionQueryModel, IPersonsApplication? personsApplication, IAuthHelper? authHelper, IAgenciesApplication? agenciesApplication)
        {
            _permissionQueryModel = permissionQueryModel;
            _personsApplication = personsApplication;
            _authHelper = authHelper;
            _agenciesApplication = agenciesApplication;
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
                var command = new PersonsCreate()
                {
                    IdAgencies = agenciesId,
                    Agencies = _agenciesApplication?.GetViewModel(),
                };
                return Partial("./Create", command);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public JsonResult OnPostCreate(PersonsCreate command)
        {
            var result = _personsApplication?.Create(command);
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
                    var commnd = new PersonsRemoved()
                    {
                        idAgencies = idAgencies,
                        PersonsRemoveds = _personsApplication?.GetRemove(idAgencies)
                    };
                    return Partial("./Removed", commnd);
                }
                else
                {
                    var commnd = new PersonsRemoved()
                    {
                        idAgencies = idAgencies,
                        PersonsRemoveds = _personsApplication?.GetRemove()
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
                    var commnd = new PersonsRemoved()
                    {
                        idAgencies = idAgencies,
                        PersonsRemoveds = _personsApplication?.GetInActive(idAgencies)
                    };
                    return Partial("./Actived", commnd);
                }
                else
                {
                    var commnd = new PersonsRemoved()
                    {
                        idAgencies = idAgencies,
                        PersonsRemoveds = _personsApplication?.GetInActive()
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
                var result = _personsApplication?.GetDetails(id);
                result.Agencies = _agenciesApplication?.GetViewModel();
                result.IdAgencies = agenciesId;
                return Partial("Edit", result);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public JsonResult OnPostEdit(PersonsEdit command)
        {
            var result = _personsApplication?.Edit(command);
            return new JsonResult(result);
        }
        public JsonResult OnGetInActive(int id)
        {
            var result = _personsApplication?.InActive(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetActive(int id)
        {
            var result = _personsApplication?.Active(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetRemove(int id)
        {
            var result = _personsApplication?.Remove(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetReset(int id)
        {
            var result = _personsApplication?.Reset(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetDelete(int id)
        {
            var result = _personsApplication?.Delete(id);
            return new JsonResult(result);
        }
        public IActionResult OnGetSaved(int id)
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.SavedGeneral == GeneralPermissions.SavedGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var Persons = _personsApplication?.GetViewModel().Where(x => x.Id == id).FirstOrDefault();
                var commnd = new PersonsViewModel()
                {
                    Name = Persons?.Name,
                    UserName = Persons?.UserName,
                    SaveDate = Persons?.SaveDate,
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
