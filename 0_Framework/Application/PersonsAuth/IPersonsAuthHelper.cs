namespace _0_Framework.Application.PersonsAuth
{
    public interface IPersonsAuthHelper
    {
        PersonsAuthViewModel CurrentPersonsInfo();
        int CurrentPersonsId();
        int CurrentAgenciesId();
        bool IsPersonsAuthenticated();
        void Signin(PersonsAuthViewModel user);
        void SignOut();
        List<int> GetPermissions();
    }
}