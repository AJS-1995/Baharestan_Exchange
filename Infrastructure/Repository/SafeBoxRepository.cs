using _0_Framework.Infrastructure;
using Contracts.SafeBoxContracts;
using Domin.SafeBoxDomin;

namespace Infrastructure.Repository
{
    public class SafeBoxRepository : RepositoryBase<int, SafeBox>, ISafeBoxRepository
    {
        private readonly BE_Context _context;
        public SafeBoxRepository(BE_Context context) : base(context)
        {
            _context = context;
        }
        public SafeBoxEdit GetDetails(int id)
        {
            var SafeBox = _context.SafeBoxs.Select(x => new SafeBoxEdit
            {
                Id = x.Id,
                Name = x.Name,
                Treasurer = x.Treasurer,
                Mobile = x.Mobile,
                AgenciesId = x.AgenciesId,
            }).FirstOrDefault(x => x.Id == id);
            return SafeBox;
        }
        public List<SafeBoxViewModel> GetInActive()
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var agencies = _context.Agenciess.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.SafeBoxs.Where(x => x.Status == false).Select(x => new SafeBoxViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Treasurer = x.Treasurer,
                Mobile = x.Mobile,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                UserId = x.UserId,
                AgenciesId = x.AgenciesId,
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = ((users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName));
            result.ForEach(item => item.AgenciesName = agencies.FirstOrDefault(x => x.Id == item.AgenciesId)?.Name);
            return result;
        }
        public List<SafeBoxViewModel> GetInActive(int agenciesId)
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var agencies = _context.Agenciess.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.SafeBoxs.Where(x => x.Status == false && x.AgenciesId == agenciesId).Select(x => new SafeBoxViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Treasurer = x.Treasurer,
                Mobile = x.Mobile,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                UserId = x.UserId,
                AgenciesId = x.AgenciesId,
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = ((users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName));
            result.ForEach(item => item.AgenciesName = agencies.FirstOrDefault(x => x.Id == item.AgenciesId)?.Name);
            return result;
        }
        public List<SafeBoxViewModel> GetRemove()
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var agencies = _context.Agenciess.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.SafeBoxs.Where(x => x.Deleted == true).Select(x => new SafeBoxViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Treasurer = x.Treasurer,
                Mobile = x.Mobile,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                UserId = x.UserId,
                AgenciesId = x.AgenciesId,
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = ((users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName));
            result.ForEach(item => item.AgenciesName = agencies.FirstOrDefault(x => x.Id == item.AgenciesId)?.Name);
            return result;
        }
        public List<SafeBoxViewModel> GetRemove(int agenciesId)
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var agencies = _context.Agenciess.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.SafeBoxs.Where(x => x.Deleted == true && x.AgenciesId == agenciesId).Select(x => new SafeBoxViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Treasurer = x.Treasurer,
                Mobile = x.Mobile,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                UserId = x.UserId,
                AgenciesId = x.AgenciesId,
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = ((users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName));
            result.ForEach(item => item.AgenciesName = agencies.FirstOrDefault(x => x.Id == item.AgenciesId)?.Name);
            return result;
        }
        public List<SafeBoxViewModel> GetViewModel()
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var agencies = _context.Agenciess.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.SafeBoxs.Where(x => x.Status == true && x.Deleted == false).Select(x => new SafeBoxViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Treasurer = x.Treasurer,
                Mobile = x.Mobile,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                UserId = x.UserId,
                AgenciesId = x.AgenciesId,
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = ((users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName));
            result.ForEach(item => item.AgenciesName = agencies.FirstOrDefault(x => x.Id == item.AgenciesId)?.Name);
            return result;
        }
        public List<SafeBoxViewModel> GetViewModel(int agenciesId)
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var agencies = _context.Agenciess.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.SafeBoxs.Where(x => x.Status == true && x.Deleted == false && x.AgenciesId == agenciesId).Select(x => new SafeBoxViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Treasurer = x.Treasurer,
                Mobile = x.Mobile,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                UserId = x.UserId,
                AgenciesId = x.AgenciesId,
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = ((users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName));
            result.ForEach(item => item.AgenciesName = agencies.FirstOrDefault(x => x.Id == item.AgenciesId)?.Name);
            return result;
        }
    }
}