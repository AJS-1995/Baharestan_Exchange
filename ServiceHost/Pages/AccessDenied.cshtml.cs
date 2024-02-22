using _0_Framework.Application.Auth;
using _0_Framework.Application.PersonsAuth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class AccessDeniedModel : PageModel
    {
        private readonly IPersonsAuthHelper _personsAuthHelper;
        private readonly IAuthHelper _authHelper;
        public AccessDeniedModel(IPersonsAuthHelper personsAuthHelper, IAuthHelper authHelper)
        {
            _personsAuthHelper = personsAuthHelper;
            _authHelper = authHelper;
        }
        public IActionResult OnGet()
        {
            try
            {
                if (_personsAuthHelper.CurrentPersonsId() == 0)
                {
                    return Redirect("/Admin");
                }
                else
                {
                    return Redirect("/PersonsAdmin");
                }
            }
            catch (Exception)
            {
                return Redirect("/Admin");
            }
        }
    }
}
