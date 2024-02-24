using _0_Framework.Application.PersonsAuth;
using _01_QueryManagement.Contracts.AccountingsContracts.PersonsModels;
using Contracts.ManagementPresonsContracts.PersonsContracts;
using Contracts.ManagementPresonsContracts.PersonsMoneyExchangeContracts;
using Contracts.ManagementPresonsContracts.PersonsReceiptContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.PersonsAdmin.Pages
{
    public class IndexModel : PageModel
    {
        public int idAgencies;
        public int PersonsId;
        public string? PersonsName;
        public List<PersonsReceiptViewModel>? PersonsReceipt;
        public List<PersonsModels>? PersonsAccounting;
        public List<PersonsMoneyExchangeViewModel>? PersonsMoneyExchangeViewModels;
        private readonly IPersonsReceiptApplication? _personsReceiptApplication;
        private readonly IPersonsApplication? _personsApplication;
        private readonly IPersonsModels _personsModels;
        private readonly IPersonsMoneyExchangeApplication? _personsMoneyExchangeApplication;
        private readonly IPersonsAuthHelper _personsAuthHelper;
        public IndexModel(IPersonsReceiptApplication? PersonsReceiptApplication, IPersonsApplication? personsApplication, IPersonsModels personsModels, IPersonsMoneyExchangeApplication personsMoneyExchangeApplication, IPersonsAuthHelper personsAuthHelper)
        {
            _personsReceiptApplication = PersonsReceiptApplication;
            _personsApplication = personsApplication;
            _personsModels = personsModels;
            _personsMoneyExchangeApplication = personsMoneyExchangeApplication;
            _personsAuthHelper = personsAuthHelper;
        }
        public IActionResult OnGet()
        {
            var agenciesId = _personsAuthHelper.CurrentAgenciesId();
            var personsId = _personsAuthHelper.CurrentPersonsId();
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
        public IActionResult OnGetLogout()
        {
            _personsAuthHelper?.SignOut();
            return RedirectToPage("/PersonsLogin");
        }
    }
}