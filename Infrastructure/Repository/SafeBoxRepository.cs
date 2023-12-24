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
            }).FirstOrDefault(x => x.Id == id);
            return SafeBox;
        }
        public List<SafeBoxViewModel> GetInActive()
        {
            return _context.SafeBoxs.Where(x => x.Status == false).Select(x => new SafeBoxViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Treasurer = x.Treasurer,
                Mobile = x.Mobile,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                UserId = x.UserId,
            }).OrderBy(x => x.Id).ToList();
        }
        public List<SafeBoxViewModel> GetRemove()
        {
            return _context.SafeBoxs.Where(x => x.Deleted == true).Select(x => new SafeBoxViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Treasurer = x.Treasurer,
                Mobile = x.Mobile,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                UserId = x.UserId,
            }).OrderBy(x => x.Id).ToList();
        }
        public List<SafeBoxViewModel> GetViewModel()
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
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
            });
            var result = query.OrderByDescending(x => x.Id).ToList();

            result.ForEach(item => item.UserName = ((users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName));

            return result;
        }
    }
}
