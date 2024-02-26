using _0_Framework.Application;
using _0_Framework.Application.Auth;
using _0_Framework.Application.PersonsAuth;
using _01_QueryManagement.Contracts.Permissions.General;
using Configuration.Permissions.General;
using Contracts.AgenciesContracts;
using Contracts.ExpenseContracts;
using Contracts.MoneyContracts;
using Contracts.SafeBoxContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.Expenses
{
    public class IndexModel : PageModel
    {
        public int idAgencies;
        public GeneralPermissionQueryModel? permissionQueryModels;
        private readonly IGeneralPermissionQueryModel? _permissionQueryModel;
        public List<ExpenseViewModel>? Expense;
        private readonly IExpenseApplication? _ExpenseApplication;
        private readonly ICollectionApplication? _CollectionApplication;
        private readonly ISafeBoxApplication? _safeBoxApplication;
        private readonly IMoneyApplication? _moneyApplication;
        private readonly IAuthHelper? _authHelper;
        private readonly IAgenciesApplication? _agenciesApplication;
        public IndexModel(IGeneralPermissionQueryModel? permissionQueryModel, IExpenseApplication? ExpenseApplication, ICollectionApplication? CollectionApplication, ISafeBoxApplication? safeBoxApplication, IMoneyApplication? moneyApplication, IAuthHelper? authHelper, IAgenciesApplication? agenciesApplication)
        {
            _permissionQueryModel = permissionQueryModel;
            _ExpenseApplication = ExpenseApplication;
            _CollectionApplication = CollectionApplication;
            _safeBoxApplication = safeBoxApplication;
            _moneyApplication = moneyApplication;
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
                    Expense = _ExpenseApplication?.GetViewModel(idAgencies);
                }
                else
                {
                    Expense = _ExpenseApplication?.GetViewModel();
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
                var SafeBox = _safeBoxApplication?.GetViewModel();
                if (agenciesId != 0)
                {
                    SafeBox = _safeBoxApplication?.GetViewModel(agenciesId);
                }
                var command = new ExpenseCreate()
                {
                    IdAgencies = agenciesId,
                    Agencies = _agenciesApplication?.GetViewModel(),
                    Collections = _CollectionApplication?.GetViewModel(),
                    Date = DateTime.Now.ToFarsi(),
                    SafeBoxs = SafeBox,
                    Moneys = _moneyApplication?.GetViewModel()
                };
                return Partial("./Create", command);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public JsonResult OnPostCreate(ExpenseCreate command)
        {
            var result = _ExpenseApplication?.Create(command);
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
                    var commnd = new ExpenseRemoved()
                    {
                        idAgencies = idAgencies,
                        ExpenseRemoveds = _ExpenseApplication?.GetRemove(idAgencies)
                    };
                    return Partial("./Removed", commnd);
                }
                else
                {
                    var commnd = new ExpenseRemoved()
                    {
                        idAgencies = idAgencies,
                        ExpenseRemoveds = _ExpenseApplication?.GetRemove()
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
                    var commnd = new ExpenseRemoved()
                    {
                        idAgencies = idAgencies,
                        ExpenseRemoveds = _ExpenseApplication?.GetInActive(idAgencies)
                    };
                    return Partial("./Actived", commnd);
                }
                else
                {
                    var commnd = new ExpenseRemoved()
                    {
                        idAgencies = idAgencies,
                        ExpenseRemoveds = _ExpenseApplication?.GetInActive()
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
                var result = _ExpenseApplication?.GetDetails(id);
                int Collectionid = _CollectionApplication.GetDetails(result.Collection_Id).Id;
                result.Agencies = _agenciesApplication?.GetViewModel();
                result.IdAgencies = agenciesId;
                result.Collection_Id = Collectionid;
                result.Collections = _CollectionApplication?.GetViewModel();
                if (agenciesId != 0)
                {
                    result.SafeBoxs = _safeBoxApplication?.GetViewModel(agenciesId);
                }
                else
                {
                    result.SafeBoxs = _safeBoxApplication?.GetViewModel();
                }
                result.Moneys = _moneyApplication?.GetViewModel();
                return Partial("Edit", result);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public JsonResult OnPostEdit(ExpenseEdit command)
        {
            var result = _ExpenseApplication?.Edit(command);
            return new JsonResult(result);
        }
        public JsonResult OnGetInActive(long id)
        {
            var result = _ExpenseApplication?.InActive(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetActive(long id)
        {
            var result = _ExpenseApplication?.Active(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetRemove(long id)
        {
            var result = _ExpenseApplication?.Remove(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetReset(long id)
        {
            var result = _ExpenseApplication?.Reset(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetDelete(long id)
        {
            var result = _ExpenseApplication?.Delete(id);
            return new JsonResult(result);
        }
        public IActionResult OnGetSaved(long id)
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.SavedGeneral == GeneralPermissions.SavedGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var Expense = _ExpenseApplication?.GetViewModel().Where(x => x.Id == id).FirstOrDefault();
                var commnd = new ExpenseViewModel()
                {
                    Description = Expense?.Description,
                    UserName = Expense?.UserName,
                    SaveDate = Expense?.SaveDate,
                };
                return Partial("./Saved", commnd);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public IActionResult OnGetCollection()
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.ListGeneral == GeneralPermissions.ListGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var commnd = new CollectionRemoved()
                {
                    CollectionRemoveds = _CollectionApplication?.GetViewModel()
                };
                return Partial("./Collection", commnd);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public IActionResult OnGetCollectionCreate()
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.AddGeneral == GeneralPermissions.AddGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                return Partial("./CollectionCreate");
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public JsonResult OnPostCollectionCreate(CollectionCreate command)
        {
            var result = _CollectionApplication?.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetCollectionRemoved()
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.RemovedGeneral == GeneralPermissions.RemovedGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var commnd = new CollectionRemoved()
                {
                    CollectionRemoveds = _CollectionApplication?.GetRemove()
                };
                return Partial("./CollectionRemoved", commnd);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public IActionResult OnGetCollectionActived()
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.ActivedGeneral == GeneralPermissions.ActivedGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var commnd = new CollectionRemoved()
                {
                    CollectionRemoveds = _CollectionApplication?.GetInActive()
                };
                return Partial("./CollectionActived", commnd);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public IActionResult OnGetCollectionEdit(int id)
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.EditGeneral == GeneralPermissions.EditGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var result = _CollectionApplication?.GetDetails(id);
                return Partial("CollectionEdit", result);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public JsonResult OnPostCollectionEdit(CollectionEdit command)
        {
            var result = _CollectionApplication?.Edit(command);
            return new JsonResult(result);
        }
        public JsonResult OnGetCollectionInActive(int id)
        {
            var result = _CollectionApplication?.InActive(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetCollectionActive(int id)
        {
            var result = _CollectionApplication?.Active(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetCollectionRemove(int id)
        {
            var result = _CollectionApplication?.Remove(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetCollectionReset(int id)
        {
            var result = _CollectionApplication?.Reset(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetCollectionDelete(int id)
        {
            var result = _CollectionApplication?.Delete(id);
            return new JsonResult(result);
        }
        public IActionResult OnGetCollectionSaved(int id)
        {
            permissionQueryModels = _permissionQueryModel?.GetGeneral();
            if (permissionQueryModels?.SavedGeneral == GeneralPermissions.SavedGeneral || permissionQueryModels?.AdminGeneral == GeneralPermissions.AdminGeneral)
            {
                var ExpenseCategory = _CollectionApplication?.GetViewModel().Where(x => x.Id == id).FirstOrDefault();
                var commnd = new CollectionViewModel()
                {
                    Name = ExpenseCategory?.Name,
                    UserName = ExpenseCategory?.UserName,
                    SaveDate = ExpenseCategory?.SaveDate,
                };
                return Partial("./CollectionSaved", commnd);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public IActionResult OnGetSafeBox(int agenciesid)
        {
            var result = _safeBoxApplication?.GetViewModel(agenciesid);
            return new JsonResult(result);
        }
        public JsonResult OnGetName(int id)
        {
            var result = _ExpenseApplication?.GetDetails(id);
            return new JsonResult(result);
        }
        public JsonResult OnGetCollectionName(int id)
        {
            var result = _CollectionApplication?.GetDetails(id);
            return new JsonResult(result);
        }
    }
}