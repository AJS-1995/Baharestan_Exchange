namespace _0_Framework.Application.PersonsAuth
{
    public interface IPersonsAuthHelper
    {
        PersonsAuthViewModel CurrentUserInfo();
        int CurrentUserId();
        int CurrentAgenciesId();
        int CurrentPersonsId();
        bool IsPersonsAuthenticated();
        void Signin(PersonsAuthViewModel user);
        void SignOut();
        List<int> GetPermissions();
    }
}