using _0_Framework.Infrastructure.Permission;

namespace Configuration.Permissions.General
{
    public class GeneralPermissionExposer : IPermissionExposer
    {
        public Dictionary<string, List<PermissionDto>> Expose()
        {
            return new Dictionary<string, List<PermissionDto>>
            {
                {
                    "عمومی", new List<PermissionDto>
                    {
                        new PermissionDto(GeneralPermissions.AdminGeneral, "مدیریت عمومی"),
                        new PermissionDto(GeneralPermissions.AddGeneral, "ثبت جدید عمومی"),
                        new PermissionDto(GeneralPermissions.EditGeneral, "ویرایش عمومی"),
                        new PermissionDto(GeneralPermissions.RemoveGeneral, "حذف عمومی"),
                        new PermissionDto(GeneralPermissions.ActiveGeneral, "غیرفعال عمومی"),
                        new PermissionDto(GeneralPermissions.ListGeneral, "لیست ها عمومی"),
                        new PermissionDto(GeneralPermissions.RemovedGeneral, "حذف شده ها عمومی"),
                        new PermissionDto(GeneralPermissions.ActivedGeneral, "غیرفعال شده ها عمومی"),
                        new PermissionDto(GeneralPermissions.SavedGeneral, "ثبت کننده عمومی"),
                    }
                }
            };
        }
    }
}