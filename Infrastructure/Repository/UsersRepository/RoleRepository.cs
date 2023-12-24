using _0_Framework.Infrastructure;
using Contracts.UsersContracts.RoleContracts;
using Domin.UsersDomin;

namespace Infrastructure.Repository.UsersRepository
{
    public class RoleRepository : RepositoryBase<int, Role>, IRoleRepository
    {
        private readonly BE_Context _context;
        public RoleRepository(BE_Context context) : base(context)
        {
            _context = context;
        }
        public RoleEdit GetDetails(int id)
        {
            var role = _context.Roles.Select(x => new RoleEdit
            {
                Id = x.Id,
                Name = x.Name,
                NamePersian = x.NamePersian,
            }).FirstOrDefault(x => x.Id == id);
            return role;
        }
        public List<RoleViewModel> GetInActive()
        {
            return _context.Roles.Where(x => x.Status == false).Select(x => new RoleViewModel
            {
                Id = x.Id,
                Name = x.Name,
                SaveDate = x.SaveDate,
                NamePersian = x.NamePersian,
                Cod = x.Cod,
                Deleted = x.Deleted,
                Status = x.Status,
                User_Id = x.UserId,
            }).OrderBy(x => x.Id).ToList();
        }
        public List<RoleViewModel> GetRemove()
        {
            return _context.Roles.Where(x => x.Deleted == true).Select(x => new RoleViewModel
            {
                Id = x.Id,
                Name = x.Name,
                SaveDate = x.SaveDate,
                NamePersian = x.NamePersian,
                Cod = x.Cod,
                Deleted = x.Deleted,
                Status = x.Status,
                User_Id = x.UserId,
            }).OrderBy(x => x.Id).ToList();
        }
        public List<RoleViewModel> GetViewModel()
        {
            return _context.Roles.Where(x => x.Status == true && x.Deleted == false).Select(x => new RoleViewModel
            {
                Id = x.Id,
                Name = x.Name,
                SaveDate = x.SaveDate,
                NamePersian = x.NamePersian,
                Cod = x.Cod,
                Deleted = x.Deleted,
                Status = x.Status,
                User_Id = x.UserId,
            }).OrderBy(x => x.Id).ToList();
        }
    }
}