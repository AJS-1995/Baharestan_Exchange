using _0_Framework.Domain;
using Contracts.ManagementPresonsContracts.PersonsUsers;
using Domin.ManagementPresonsDomin.PersonsUsers;

namespace Domin.PersonsUsersDomin
{
	public interface IPersonsUserRepository : IRepository<int, PersonsUser>
    {
        PersonsUser GetBy(string personsUsername);
        PersonsUserEdit GetDetails(int id);
		List<PersonsUserViewModel> GetViewModel();
		List<PersonsUserViewModel> GetViewModel(int agenciesId);
		List<PersonsUserViewModel> GetRemove();
		List<PersonsUserViewModel> GetRemove(int agenciesId);
		List<PersonsUserViewModel> GetInActive();
		List<PersonsUserViewModel> GetInActive(int agenciesId);
	}
}