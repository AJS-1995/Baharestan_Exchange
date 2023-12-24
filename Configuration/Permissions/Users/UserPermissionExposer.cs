using _0_Framework.Infrastructure.Permission;

namespace Configuration.Permissions.Users
{
    public class UserPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {
                    "کاربران", new List<PermissionDto>
                    {
                        new PermissionDto(UserPermissions.AdminUsers, "مدیریت کاربران"),
                        new PermissionDto(UserPermissions.AddUsers, "ثبت کاربر جدید"),
                        new PermissionDto(UserPermissions.ListUsers, "لیست کاربران"),
                        new PermissionDto(UserPermissions.EditUser, "ویرایش کاربر"),
                        new PermissionDto(UserPermissions.ChangePasswordUser, "تغیر رمز کاربر"),
                        new PermissionDto(UserPermissions.RemoveUser, "حذف کاربر"),
                        new PermissionDto(UserPermissions.ActiveUser, "غیرفعال کاربر"),
                        new PermissionDto(UserPermissions.LevelUser, "سطح دسترسی کاربر"),
                        new PermissionDto(UserPermissions.SavedUser, "ثبت کننده کاربر"),
                    }
                }
            };
        }
    }
}