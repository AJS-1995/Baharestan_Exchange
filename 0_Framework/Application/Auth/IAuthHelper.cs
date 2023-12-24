namespace _0_Framework.Application.Auth
{
    public interface IAuthHelper
    {
        void SignOut();
        bool IsAuthenticated();
        void Signin(AuthViewModel user);
        string CurrentUserRole();
        AuthViewModel CurrentUserInfo();
        List<int> GetPermissions();
        int CurrentUserId();
        int CurrentAgenciesId();
        string CurrentUserMobile();
    }
}