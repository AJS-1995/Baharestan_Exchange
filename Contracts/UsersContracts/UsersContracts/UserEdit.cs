using _0_Framework.Infrastructure.Permission;

namespace Contracts.UsersContracts.UsersContracts
{
	public class UserEdit : UserCreate
    {
        public int Id { get; set; }
        public List<PermissionDto>? MappedPermissions { get; set; }
        public UserEdit()
        {
            Permissions = new List<int>();
        }
    }
}