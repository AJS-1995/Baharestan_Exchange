using _0_Framework.Infrastructure.Permission;

namespace Contracts.UsersContracts.UsersContracts
{
    public class UserPermissionsCreate
    {
        public List<int> Permissions { get; set; }
        public int Id { get; set; }
        public string? FullName { get; set; }
        public List<PermissionDto>? MappedPermissions { get; set; }

        public UserPermissionsCreate()
        {
            Permissions = new List<int>();
        }
    }
}