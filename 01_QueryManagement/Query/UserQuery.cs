using _01_QueryManagement.Contracts.Users;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace _01_QueryManagement.Query
{
    public class UserQuery : IUserQueryModel
    {
        private readonly BE_Context _context;
        public UserQuery(BE_Context context)
        {
            _context = context;
        }
        public UserQueryModel GetUsers(int id)
        {
            var user = _context.Users.Include(x => x.Role).Select(x => new UserQueryModel
            {
                Id = x.Id,
                FullName = x.FullName,
                UserName = x.UserName,
                Mobile = x.Mobile,
                RoleId = x.RoleId,
                ProfilePhoto = x.ProfilePhoto,
                SaveDate = x.SaveDate,
                Status = x.Status,
                Role = x.Role.Name,
                RolePersian = x.Role.NamePersian
            }).FirstOrDefault(x => x.Id == id);
            return user;
        }
    }
}