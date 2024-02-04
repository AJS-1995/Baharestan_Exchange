using _0_Framework.Infrastructure;
using _0_Framework.Infrastructure.Permission;
using Contracts.UsersContracts.UsersContracts;
using Domin.UsersDomin;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Infrastructure.Repository.UsersRepository
{
    public class UserRepository : RepositoryBase<int, User>, IUserRepository
    {
        private readonly BE_Context _context;
        public UserRepository(BE_Context context) : base(context)
        {
            _context = context;
        }
        public User GetBy(string? username)
        {
            return _context.Users.FirstOrDefault(x => x.UserName == username);
        }
        public UserEdit GetDetails(int id)
        {
            var role = _context.Users.Select(x => new UserEdit
            {
                Id = x.Id,
                FullName = x.FullName,
                Mobile = x.Mobile,
                RoleId = x.RoleId,
                UserName = x.UserName,
                SecurityCod = x.SecurityCod,
                MappedPermissions = MapPermissions(x.Permissions),
            }).AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
            if (role != null)
            {
                role.Permissions = role.MappedPermissions.Select(x => x.Code).ToList();
            }
            return role;
        }
        private static List<PermissionDto> MapPermissions(IEnumerable<Permission> permissions)
        {
            return permissions.Select(x => new PermissionDto(x.Code, x.Name)).ToList();
        }
        public List<UserViewModel> GetViewModel()
        {
            var agencies = _context.Agenciess.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.Users.Where(x => x.Status == true && x.Deleted == false).Select(x => new UserViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                Mobile = x.Mobile,
                SecurityCod = x.SecurityCod,
                ProfilePhoto = x.ProfilePhoto,
                Role = x.Role.Name,
                RolePersian = x.Role.NamePersian,
                Role_Id = x.RoleId,
                UserName = x.UserName,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                User_Id = x.UserId,
                User_Name = x.UserName,
                IdAgencies = x.AgenciesId
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.AgenciesName = agencies.FirstOrDefault(x => x.Id == item.IdAgencies)?.Name);
            return result;
        }
        public UserPermissionsCreate GetDetailsPer(int id)
        {
            var role = _context.Users.Select(x => new UserPermissionsCreate
            {
                Id = x.Id,
                FullName = x.FullName,
                MappedPermissions = MapPermissions(x.Permissions),
            }).AsNoTracking().FirstOrDefault(x => x.Id == id);
            role.Permissions = role.MappedPermissions.Select(x => x.Code).ToList();
            return role;
        }

        public List<UserViewModel> GetRemove()
        {
            var agencies = _context.Agenciess.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.Users.Where(x => x.Deleted == true).Select(x => new UserViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                Mobile = x.Mobile,
                SecurityCod = x.SecurityCod,
                ProfilePhoto = x.ProfilePhoto,
                Role = x.Role.Name,
                RolePersian = x.Role.NamePersian,
                Role_Id = x.RoleId,
                UserName = x.UserName,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                User_Id = x.UserId,
                User_Name = x.UserName,
                IdAgencies = x.AgenciesId
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.AgenciesName = agencies.FirstOrDefault(x => x.Id == item.IdAgencies)?.Name);
            return result;
        }

        public List<UserViewModel> GetInActive()
        {
            var agencies = _context.Agenciess.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.Users.Where(x => x.Status == false).Select(x => new UserViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                Mobile = x.Mobile,
                SecurityCod = x.SecurityCod,
                ProfilePhoto = x.ProfilePhoto,
                Role = x.Role.Name,
                RolePersian = x.Role.NamePersian,
                Role_Id = x.RoleId,
                UserName = x.UserName,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                User_Id = x.UserId,
                User_Name = x.UserName,
                IdAgencies = x.AgenciesId
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.AgenciesName = agencies.FirstOrDefault(x => x.Id == item.IdAgencies)?.Name);
            return result;
        }
    }
}