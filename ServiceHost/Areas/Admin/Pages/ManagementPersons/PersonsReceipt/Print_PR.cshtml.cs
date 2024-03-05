using _0_Framework.Application;
using _0_Framework.Application.Auth;
using Contracts.AgenciesContracts;
using Contracts.CompanyContracts;
using Contracts.ManagementPresonsContracts.PersonsReceiptContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Admin.Pages.ManagementPersons.PersonsReceipt
{
    public class Print_PRModel : PageModel
    {
        public PersonsReceiptViewModel? receiptEdit;
        public string? CompanyName = "";
        public string? CompanyLogo = "";
        public string? AgenciesName = "";
        public string? AgenciesAddress = "";
        public string? UserName = "";
        private readonly IPersonsReceiptApplication? _personsReceiptApplication;
        private readonly ICompanyApplication? _companyApplication;
        private readonly IAuthHelper? _authHelper;
        private readonly IAgenciesApplication? _agenciesApplication;
        public Print_PRModel(IPersonsReceiptApplication? personsReceiptApplication, ICompanyApplication? companyApplication, IAuthHelper? authHelper, IAgenciesApplication? agenciesApplication)
        {
            _personsReceiptApplication = personsReceiptApplication;
            _companyApplication = companyApplication;
            _authHelper = authHelper;
            _agenciesApplication = agenciesApplication;
        }
        public IActionResult OnGet(long id, OperationResult result)
        {
            if (id != 0 || result.Id !=0)
            {
                receiptEdit = _personsReceiptApplication?.GetViewModel().Where(x => x.Id == id).FirstOrDefault();
                var company = _companyApplication?.GetViewModel().FirstOrDefault();
                CompanyName = company?.Name;
                CompanyLogo = company?.Logo;
                var user = _authHelper.CurrentUserInfo();
                var agencies = new AgenciesEdit();
                agencies = _agenciesApplication?.GetDetails(receiptEdit.AgenciesId);
                AgenciesName = agencies?.Name;
                AgenciesAddress = agencies?.Address;
                UserName = user.UserName;
                return Page();
            }
            else
            {
                return Redirect("./Index");
            }
        }
    }
}