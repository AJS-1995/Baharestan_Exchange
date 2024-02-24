using _0_Framework.Infrastructure;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Security.Claims;

namespace _0_Framework.Application.PersonsAuth
{
    public class PersonsAuthHelper : IPersonsAuthHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public PersonsAuthHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public PersonsAuthViewModel CurrentPersonsInfo()
        {
            var result = new PersonsAuthViewModel();
            if (!IsPersonsAuthenticated())
                return result;

            var personsclaims = _contextAccessor.HttpContext.User.Claims.ToList();
            result.Id = int.Parse(personsclaims.FirstOrDefault(x => x.Type == "Id").Value);
            result.AgenciesId = int.Parse(personsclaims.FirstOrDefault(x => x.Type == "AgenciesId").Value);
            result.UserName = personsclaims.FirstOrDefault(x => x.Type == "UserName").Value;
            result.RoleId = int.Parse(personsclaims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value);
            result.Role = Roles.GetRoleBy(result.RoleId);
            return result;
        }
        public int CurrentPersonsId()
        {
            return IsPersonsAuthenticated()
                ? int.Parse(_contextAccessor.HttpContext.User.Claims.First(x => x.Type == "Id")?.Value) : 0;
        }
        public int CurrentAgenciesId()
        {
            return IsPersonsAuthenticated()
                ? int.Parse(_contextAccessor.HttpContext.User.Claims.First(x => x.Type == "AgenciesId")?.Value) : 0;
        }
        public bool IsPersonsAuthenticated()
        {
            return _contextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }
        public void Signin(PersonsAuthViewModel user)
        {
            var personsclaims = new List<Claim>
            {
                new Claim("Id", user.Id.ToString()),
                new Claim("AgenciesId", user.AgenciesId.ToString()),
                new Claim("RoleId", user.RoleId.ToString()),
                new Claim(ClaimTypes.Role, user.RoleId.ToString()),
            };
            var claimsIdentity = new ClaimsIdentity(personsclaims, CookieAuthenticationDefaults.AuthenticationScheme);
            var PersonsAuthProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1)
            };
            _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                PersonsAuthProperties);
        }
        public void SignOut()
        {
            _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
        public List<int> GetPermissions()
        {
            if (!IsPersonsAuthenticated())
                return new List<int>();

            var permissions = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "permissions")
                ?.Value;
            return JsonConvert.DeserializeObject<List<int>>(permissions);
        }
    }
}