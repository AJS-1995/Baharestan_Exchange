using _0_Framework.Application;
using _0_Framework.Application.Auth;
using _0_Framework.Application.PersonsAuth;
using Contracts.AgenciesContracts;
using Contracts.CompanyContracts;
using Contracts.UsersContracts.UsersContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string? Message { get; set; }
        public string? Name = "";
        public int Id = 1;

        private readonly ICompanyApplication _companyApplication;
        private readonly IAgenciesApplication _agenciesApplication;
        private readonly IUserApplication _UserApplication;
        private readonly IAuthHelper _authHelper;
        public IndexModel(IUserApplication UserApplication, IAuthHelper authHelper, ICompanyApplication companyApplication, IAgenciesApplication agenciesApplication)
        {
            _UserApplication = UserApplication;
            _authHelper = authHelper;
            _companyApplication = companyApplication;
            _agenciesApplication = agenciesApplication;
        }
        public IActionResult OnGet()
        {
            var Authenticated = _authHelper.IsAuthenticated();
            if (Authenticated == true)
            {
                return Redirect("/Admin");
            }
            else
            {
                var company = _companyApplication.GetViewModel();
                if (company.Count != 0)
                {
                    Name = _companyApplication.GetViewModel().First().Name;
                    Id = _companyApplication.GetViewModel().First().Id;
                    var agencies = _agenciesApplication.GetViewModel();
                    if (agencies.Count !=0)
                    {
                        var user = _UserApplication.GetViewModel();
                        if (user.Count != 0)
                        {
                            return Page();
                        }
                        else
                        {
                            var command = new UserCreate()
                            {
                                FullName = "Administrator",
                                Mobile = "+ (93) 79-6815655",
                                Password = "123456",
                                RoleId = 1,
                                UserName = "Admin",
                                SecurityCod = "Admin",
                                Permissions = new List<int> { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150 }
                            };
                            _UserApplication.Create(command);
                            return Page();
                        }
                    }
                    else
                    {
                        var command = new AgenciesCreate()
                        {
                            Name = "مرکزی",
                            Mobile = "+ (93) 79-6815655",
                            Address = "هرات شهرنو مارکت ضیا زیرزمینی دوکان ۱۷",
                            CompanyId = Id,
                            Responsible = "عبدالجبار"
                        };
                        _agenciesApplication.Create(command);
                        return Page();
                    }
                }
                else
                {
                    var com = new CompanyCreate()
                    {
                        Name = "صرافی بهارستان",
                        Address = "هرات شهرنو مارکت ضیا زیرزمینی دوکان ۱۷",
                        Mobile = "+ (93) 79-6815655",
                        Responsible = "عبدالجبار سروری"
                    };
                    _companyApplication.Create(com);
                    return Page();
                }
            }
        }
        public IActionResult OnPostLogin(UserLogin command)
        {
            OperationResult result = _UserApplication.Login(command);
            if (result.IsSuccedded == true)
            {
                return Redirect("/Admin");
            }
            else
            {
                Message = result.Message;
                return Page();
            }
        }
        public IActionResult OnGetLogout()
        {
            _UserApplication.Logout();
            return RedirectToPage("/");
        }
    }
}