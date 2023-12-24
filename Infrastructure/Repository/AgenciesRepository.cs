using _0_Framework.Infrastructure;
using Contracts.AgenciesContracts;
using Domin.AgenciesDomin;

namespace Infrastructure.Repository
{
    public class AgenciesRepository : RepositoryBase<int, Agencies>, IAgenciesRepository
    {
        private readonly BE_Context _context;
        public AgenciesRepository(BE_Context context) : base(context)
        {
            _context = context;
        }
        public AgenciesEdit GetDetails(int id)
        {
            var Agencies = _context.Agenciess.Select(x => new AgenciesEdit
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                CompanyId = x.CompanyId,
                Mobile = x.Mobile,
                Responsible = x.Responsible
            }).FirstOrDefault(x => x.Id == id);
            return Agencies;
        }
        public List<AgenciesViewModel> GetInActive()
        {
            return _context.Agenciess.Where(x => x.Status == false).Select(x => new AgenciesViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                CompanyId = x.CompanyId,
                Mobile = x.Mobile,
                Responsible = x.Responsible,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                UserId = x.UserId,
            }).OrderBy(x => x.Id).ToList();
        }
        public List<AgenciesViewModel> GetRemove()
        {
            return _context.Agenciess.Where(x => x.Deleted == true).Select(x => new AgenciesViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                CompanyId = x.CompanyId,
                Mobile = x.Mobile,
                Responsible = x.Responsible,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                UserId = x.UserId,
            }).OrderBy(x => x.Id).ToList();
        }
        public List<AgenciesViewModel> GetViewModel()
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var query = _context.Agenciess.Where(x => x.Status == true && x.Deleted == false).Select(x => new AgenciesViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                CompanyId = x.CompanyId,
                Mobile = x.Mobile,
                Responsible = x.Responsible,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                UserId = x.UserId,
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.User_Name = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            return result;
        }
        public List<AgenciesViewModel> GetAll()
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var query = _context.Agenciess.Where(x => x.Deleted == false).Select(x => new AgenciesViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                CompanyId = x.CompanyId,
                Mobile = x.Mobile,
                Responsible = x.Responsible,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                UserId = x.UserId,
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.User_Name = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            return result;
        }
    }
}