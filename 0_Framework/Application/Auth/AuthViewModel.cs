namespace _0_Framework.Application.Auth
{
    public class AuthViewModel
    {
        public int Id { get; set; }
        public int RoleCod { get; set; }
        public string? Role { get; set; }
        public string? FullName { get; set; }
        public string? UserName { get; set; }
        public string? Mobile { get; set; }
        public int AgenciesId { get; set; }
        public List<int>? Permissions { get; set; }
        public AuthViewModel()
        {
        }
        public AuthViewModel(int id, int rolecod, string fullname, string username, string mobile, int agenciesId, List<int> permissions)
        {
            Id = id;
            RoleCod = rolecod;
            FullName = fullname;
            UserName = username;
            Mobile = mobile;
            AgenciesId = agenciesId;
            Permissions = permissions;
        }
    }
}