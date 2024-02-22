namespace _0_Framework.Application.PersonsAuth
{
    public class PersonsAuthViewModel
    {
        public int Id { get; set; }
        public int PersonsId { get; set; }
        public string? UserName { get; set; }
        public int AgenciesId { get; set; }
        public int RoleId { get; set; }
        public List<int>? Permissions { get; set; }
        public string? Role { get; set; }
        public PersonsAuthViewModel()
        {
        }
        public PersonsAuthViewModel(int id, int personsId, string? userName, int agenciesId, int roleId, List<int>? permissions)
        {
            Id = id;
            PersonsId = personsId;
            UserName = userName;
            AgenciesId = agenciesId;
            RoleId = roleId;
            Permissions = permissions;
        }
    }
}