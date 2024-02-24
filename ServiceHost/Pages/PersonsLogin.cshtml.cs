using _0_Framework.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using _0_Framework.Application.PersonsAuth;
using Contracts.ManagementPresonsContracts.PersonsContracts;

namespace ServiceHost.Pages
{
    public class PersonsLoginModel : PageModel
    {
		[TempData]
		public string? Message { get; set; }
		public string? Name = "";
		public int Id = 1;

		private readonly IPersonsApplication _personsApplication;
		private readonly IPersonsAuthHelper _personsAuthHelper;
		public PersonsLoginModel(IPersonsApplication personsApplication, IPersonsAuthHelper personsAuthHelper)
		{
            _personsApplication = personsApplication;
            _personsAuthHelper = personsAuthHelper;
		}
		public IActionResult OnGet()
		{
			var Authenticated = _personsAuthHelper.IsPersonsAuthenticated();
			if (Authenticated == true)
			{
				return Redirect("/PersonsAdmin");
			}
			else
			{
                return Page();
            }
		}
		public IActionResult OnPostLogin(PersonsLogin command)
		{
			OperationResult result = _personsApplication.Login(command);
			if (result.IsSuccedded == true)
			{
				return Redirect("/PersonsAdmin");
			}
			else
			{
				Message = result.Message;
				return Page();
			}
		}
		public IActionResult OnGetLogout()
		{
            _personsApplication.Logout();
			return RedirectToPage("/");
		}
	}
}