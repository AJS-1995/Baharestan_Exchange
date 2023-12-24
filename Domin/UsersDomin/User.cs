using _0_Framework.Domain;

namespace Domin.UsersDomin
{
    public class User : EntityBase<int>
    {
        public string? FullName { get; private set; }
        public string? UserName { get; private set; }
        public string? Password { get; private set; }
        public string? Mobile { get; private set; }
        public string? SecurityCod { get; private set; }
        public int RoleId { get; private set; }
        public Role? Role { get; private set; }
        public string? ProfilePhoto { get; private set; }
        public List<Permission>? Permissions { get; private set; }
        protected User() { }
        public User(string fullname, string username, string password, string mobile, string securitycod, int roleId, string profilePhoto, List<Permission> permissions, int userId, int agenciesId)
        {
            FullName = fullname;
            UserName = username;
            Password = password;
            Mobile = mobile;
            SecurityCod = securitycod;
            RoleId = roleId;
            ProfilePhoto = profilePhoto;
            Permissions = permissions;
            UserId = userId;
            AgenciesId = agenciesId;
        }
        public void Edit(string fullname, string username, string mobile, int roleId, string profilePhoto, int userId, int agenciesId)
        {
            FullName = fullname;
            UserName = username;
            Mobile = mobile;
            RoleId = roleId;
            if (!string.IsNullOrWhiteSpace(profilePhoto))
                ProfilePhoto = profilePhoto;
            UserId = userId;
            AgenciesId = agenciesId;
        }
        public void Edit(List<Permission> permissions, int userId)
        {
            Permissions = permissions;
            UserId = userId;
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