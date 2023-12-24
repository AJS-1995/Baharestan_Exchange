using _0_Framework.Infrastructure;
using Contracts.MoneyContracts;
using Domin.MoneyDomin;

namespace Infrastructure.Repository
{
    public class MoneyRepository : RepositoryBase<int, Money>, IMoneyRepository
    {
        private readonly BE_Context _context;
        public MoneyRepository(BE_Context context) : base(context)
        {
            _context = context;
        }
        public MoneyEdit GetDetails(int id)
        {
            var Money = _context.Moneies.Select(x => new MoneyEdit
            {
                Id = x.Id,
                Name = x.Name,
                Country = x.Country,
                Symbol = x.Symbol,
            }).FirstOrDefault(x => x.Id == id);
            return Money;
        }
        public List<MoneyViewModel> GetInActive()
        {
            return _context.Moneies.Where(x => x.Status == false).Select(x => new MoneyViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Country = x.Country,
                Symbol = x.Symbol,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                User_Id = x.UserId,
            }).OrderBy(x => x.Id).ToList();
        }
        public List<MoneyViewModel> GetRemove()
        {
            return _context.Moneies.Where(x => x.Deleted == true).Select(x => new MoneyViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Country = x.Country,
                Symbol = x.Symbol,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                User_Id = x.UserId,
            }).OrderBy(x => x.Id).ToList();
        }
        public List<MoneyViewModel> GetViewModel()
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var query = _context.Moneies.Where(x => x.Status == true && x.Deleted == false).Select(x => new MoneyViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Country = x.Country,
                Symbol = x.Symbol,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                User_Id = x.UserId,
                NameSymblo = x.Name + " - " + x.Symbol,
            });
            var result = query.OrderBy(x => x.Id).ToList();
            result.ForEach(item => item.User_Name = (users.FirstOrDefault(x => x.Id == item.User_Id)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.User_Id)?.UserName);
            return result;
        }
        public List<MoneyViewModel> GetAll()
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var query = _context.Moneies.Where(x => x.Deleted == false).Select(x => new MoneyViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Country = x.Country,
                Symbol = x.Symbol,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                User_Id = x.UserId,
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.User_Name = (users.FirstOrDefault(x => x.Id == item.User_Id)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.User_Id)?.UserName);
            return result;
        }
    }
}