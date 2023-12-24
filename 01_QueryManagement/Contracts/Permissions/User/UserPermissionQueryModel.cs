namespace _01_QueryManagement.Contracts.Permissions.User
{
    public class UserPermissionQueryModel
    {
        public int AdminUsers { get; set; }
        public int AddUsers { get; set; }
        public int ListUsers { get; set; }
        public int EditUser { get; set; }
        public int ChangePasswordUser { get; set; }
        public int RemoveUser { get; set; }
        public int ActiveUser { get; set; }
        public int LevelUser { get; set; }
        public int SavedUser { get; set; }
    }
}