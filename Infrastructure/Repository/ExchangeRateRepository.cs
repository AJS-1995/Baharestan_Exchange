using _0_Framework.Infrastructure;
using Contracts.ExchangeRateContracts;
using Domin.ExchangeRateDomin;

namespace Infrastructure.Repository
{
    public class ExchangeRateRepository : RepositoryBase<long, ExchangeRate>, IExchangeRateRepository
    {
        private readonly BE_Context _context;
        public ExchangeRateRepository(BE_Context context) : base(context)
        {
            _context = context;
        }
        public ExchangeRateEdit GetDetails(long id)
        {
            var ExchangeRate = _context.ExchangeRates.Select(x => new ExchangeRateEdit
            {
                Id = x.Id,
                Amount = x.Amount,
                MainMoneyId = x.MainMoneyId,
                Price = x.Price,
                SecondaryMoneyId = x.SecondaryMoneyId
            }).FirstOrDefault(x => x.Id == id);
            return ExchangeRate;
        }
        public List<ExchangeRateViewModel> GetInActive()
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var moneys = _context.Moneies.Select(x => new { x.Id, x.Symbol }).ToList();
            var query = _context.ExchangeRates.Where(x => x.Status == false).Select(x => new ExchangeRateViewModel
            {
                Id = x.Id,
                Amount = x.Amount,
                MainMoneyId = x.MainMoneyId,
                Price = x.Price,
                SecondaryMoneyId = x.SecondaryMoneyId,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                UserId = x.UserId,
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            result.ForEach(item => item.MainMoneyName = moneys.FirstOrDefault(x => x.Id == item.MainMoneyId)?.Symbol);
            result.ForEach(item => item.SecondaryMoneyName = moneys.FirstOrDefault(x => x.Id == item.SecondaryMoneyId)?.Symbol);
            return result;
        }
        public List<ExchangeRateViewModel> GetRemove()
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var moneys = _context.Moneies.Select(x => new { x.Id, x.Symbol }).ToList();
            var query = _context.ExchangeRates.Where(x => x.Deleted == true).Select(x => new ExchangeRateViewModel
            {
                Id = x.Id,
                Amount = x.Amount,
                MainMoneyId = x.MainMoneyId,
                Price = x.Price,
                SecondaryMoneyId = x.SecondaryMoneyId,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                UserId = x.UserId,
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            result.ForEach(item => item.MainMoneyName = moneys.FirstOrDefault(x => x.Id == item.MainMoneyId)?.Symbol);
            result.ForEach(item => item.SecondaryMoneyName = moneys.FirstOrDefault(x => x.Id == item.SecondaryMoneyId)?.Symbol);
            return result;
        }
        public List<ExchangeRateViewModel> GetViewModel()
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var moneys = _context.Moneies.Select(x => new { x.Id, x.Symbol }).ToList();
            var query = _context.ExchangeRates.Where(x => x.Status == true && x.Deleted == false).Select(x => new ExchangeRateViewModel
            {
                Id = x.Id,
                Amount = x.Amount,
                MainMoneyId = x.MainMoneyId,
                Price = x.Price,
                SecondaryMoneyId = x.SecondaryMoneyId,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                UserId = x.UserId,
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            result.ForEach(item => item.MainMoneyName = moneys.FirstOrDefault(x => x.Id == item.MainMoneyId)?.Symbol);
            result.ForEach(item => item.SecondaryMoneyName = moneys.FirstOrDefault(x => x.Id == item.SecondaryMoneyId)?.Symbol);
            return result;
        }
    }
}