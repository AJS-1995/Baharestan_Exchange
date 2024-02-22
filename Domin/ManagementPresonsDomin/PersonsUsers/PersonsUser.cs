using _0_Framework.Domain;
using Domin.ManagementPresonsDomin.PersonsDomin;

namespace Domin.ManagementPresonsDomin.PersonsUsers
{
	public class PersonsUser : EntityBase<int>
	{
		public string? UserName { get; private set; }
		public string? Password { get; private set; }
		public int PersonsId { get; private set; }
		public Persons? Persons { get; private set; }
		public string? ProfilePhoto { get; private set; }
		protected PersonsUser() { }
		public PersonsUser(string username, string password, int personsId, string profilePhoto, int userId, int agenciesId)
		{
			UserName = username;
			Password = password;
			PersonsId = personsId;
			ProfilePhoto = profilePhoto;
			UserId = userId;
			AgenciesId = agenciesId;
		}
		public void Edit(string username, int personsId, string profilePhoto, int userId, int agenciesId)
		{
			UserName = username;
			PersonsId = personsId;
			if (!string.IsNullOrWhiteSpace(profilePhoto))
				ProfilePhoto = profilePhoto;
			UserId = userId;
			AgenciesId = agenciesId;
		}
		public void ChangePassword(string password)
		{
			Password = password;
		}
		public void InActive()
		{
			Status = false;
		}
		public void Active()
		{
			Status = true;
		}
		public void Remove()
		{
			Deleted = true;
		}
		public void Reset()
		{
			Deleted = false;
		}
	}
}