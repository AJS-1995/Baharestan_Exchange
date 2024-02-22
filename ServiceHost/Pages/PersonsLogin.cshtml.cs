using _0_Framework.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using _0_Framework.Application.PersonsAuth;
using Contracts.ManagementPresonsContracts.PersonsUsers;

namespace ServiceHost.Pages
{
    public class PersonsLoginModel : PageModel
    {
		[TempData]
		public string? Message { get; set; }
		public string? Name = "";
		public int Id = 1;

		private readonly IPersonsUserApplication _personsUserApplication;
		private readonly IPersonsAuthHelper _personsAuthHelper;
		public PersonsLoginModel(IPersonsUserApplication personsUserApplication, IPersonsAuthHelper personsAuthHelper)
		{
            _personsUserApplication = personsUserApplication;
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
		public IActionResult OnPostLogin(PersonsUserLogin command)
		{
			OperationResult result = _personsUserApplication.Login(command);
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
            _personsUserApplication.Logout();
			return RedirectToPage("/");
		}
	}
}