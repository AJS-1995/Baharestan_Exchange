using _0_Framework.Application;

namespace Contracts.ManagementPresonsContracts.PersonsUsers
{
	public interface IPersonsUserApplication
	{
		PersonsUserViewModel GetPersonsUserBy(int id);
		OperationResult Create(PersonsUserCreate command);
		OperationResult Edit(PersonsUserEdit command);
		OperationResult ChangePassword(PersonsUserChangePassword command);
		PersonsUserEdit GetDetails(int id);
		List<PersonsUserViewModel> GetViewModel(int agenciesId);
		List<PersonsUserViewModel> GetInActive();
		List<PersonsUserViewModel> GetInActive(int agenciesId);
		List<PersonsUserViewModel> GetRemove();
		List<PersonsUserViewModel> GetRemove(int agenciesId);
		OperationResult Login(PersonsUserLogin command);
		OperationResult Logout();
		OperationResult InActive(int id);
		OperationResult Active(int id);
		OperationResult Remove(int id);
		OperationResult Reset(int id);
		OperationResult Delete(int id);
	}
}