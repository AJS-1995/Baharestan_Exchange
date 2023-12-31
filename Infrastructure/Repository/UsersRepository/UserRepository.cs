﻿using _0_Framework.Infrastructure;
using _0_Framework.Infrastructure.Permission;
using Contracts.UsersContracts.UsersContracts;
using Domin.UsersDomin;
using Microsoft.EntityFrameworkCore;

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
            return _context.Users.Where(x => x.Status == true && x.Deleted == false).Select(x => new UserViewModel
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
            }).OrderBy(x => x.Id).ToList();
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
            return _context.Users.Where(x => x.Deleted == true).Select(x => new UserViewModel
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
            }).OrderBy(x => x.Id).ToList();
        }

        public List<UserViewModel> GetInActive()
        {
            return _context.Users.Where(x => x.Status == false).Select(x => new UserViewModel
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
            }).OrderBy(x => x.Id).ToList();
        }
    }
}