using _0_Framework.Infrastructure;
using Contracts.ManagementPresonsContracts.LivelihoodMonthContracts;
using Domin.ManagementPresonsDomin.LivelihoodMonthDomin;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.ManagementPresonsRepository
{
    public class LivelihoodMonthRepository : RepositoryBase<long, LivelihoodMonth>, ILivelihoodMonthRepository
    {
        private readonly BE_Context _context;
        public LivelihoodMonthRepository(BE_Context context) : base(context)
        {
            _context = context;
        }
        public LivelihoodMonthEdit GetDetails(long id)
        {
            var result = _context.LivelihoodMonths.Select(x => new LivelihoodMonthEdit
            {
                Id = x.Id,
                LivelihoodId = x.LivelihoodId,
                Month = x.Month,
                Year = x.Year,
                AgenciesId = x.AgenciesId,
                PersonsId = x.PersonsId,
                Amount = x.Amount,
                MoneyId = x.MoneyId,
            }).FirstOrDefault(x => x.Id == id);
            return result;
        }
        public List<LivelihoodMonthViewModel> GetInActive()
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var query = _context.LivelihoodMonths.Where(x => x.Status == false)
                .Include(x => x.Livelihood).Include(x => x.Agenciess)
                .Select(x => new LivelihoodMonthViewModel
                {
                    Id = x.Id,
                    LivelihoodId = x.LivelihoodId,
                    Month = x.Month,
                    Year= x.Year,
                    PersonsId = x.PersonsId,
                    Amount = x.Amount,
                    MoneyId = x.MoneyId,
                    AgenciesId = x.AgenciesId,
                    SaveDate = x.SaveDate,
                    Deleted = x.Deleted,
                    Status = x.Status,
                    UserId = x.UserId,
                    PresonsName = x.Livelihood.Persons.Name,
                    AgenciesName = x.Agenciess.Name,
                    MoneyName = x.Livelihood.Moneys.Symbol
                });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            return result;
        }
        public List<LivelihoodMonthViewModel> GetInActive(int agenciesId)
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var query = _context.LivelihoodMonths.Where(x => x.Status == false && x.AgenciesId == agenciesId)
                .Include(x => x.Livelihood).Include(x => x.Agenciess)
                .Select(x => new LivelihoodMonthViewModel
                {
                    Id = x.Id,
                    LivelihoodId = x.LivelihoodId,
                    Month = x.Month,
                    Year = x.Year,
                    PersonsId = x.PersonsId,
                    Amount = x.Amount,
                    MoneyId = x.MoneyId,
                    AgenciesId = x.AgenciesId,
                    SaveDate = x.SaveDate,
                    Deleted = x.Deleted,
                    Status = x.Status,
                    UserId = x.UserId,
                    PresonsName = x.Livelihood.Persons.Name,
                    AgenciesName = x.Agenciess.Name,
                    MoneyName = x.Livelihood.Moneys.Symbol
                });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            return result;
        }
        public List<LivelihoodMonthViewModel> GetRemove()
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var query = _context.LivelihoodMonths.Where(x => x.Deleted == true)
                .Include(x => x.Livelihood).Include(x => x.Agenciess)
                .Select(x => new LivelihoodMonthViewModel
                {
                    Id = x.Id,
                    LivelihoodId = x.LivelihoodId,
                    Month = x.Month,
                    Year = x.Year,
                    PersonsId = x.PersonsId,
                    Amount = x.Amount,
                    MoneyId = x.MoneyId,
                    AgenciesId = x.AgenciesId,
                    SaveDate = x.SaveDate,
                    Deleted = x.Deleted,
                    Status = x.Status,
                    UserId = x.UserId,
                    PresonsName = x.Livelihood.Persons.Name,
                    AgenciesName = x.Agenciess.Name,
                    MoneyName = x.Livelihood.Moneys.Symbol
                });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            return result;
        }
        public List<LivelihoodMonthViewModel> GetRemove(int agenciesId)
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var query = _context.LivelihoodMonths.Where(x => x.Deleted == true && x.AgenciesId == agenciesId)
                .Include(x => x.Livelihood).Include(x => x.Agenciess)
                .Select(x => new LivelihoodMonthViewModel
                {
                    Id = x.Id,
                    LivelihoodId = x.LivelihoodId,
                    Month = x.Month,
                    Year = x.Year,
                    PersonsId = x.PersonsId,
                    Amount = x.Amount,
                    MoneyId = x.MoneyId,
                    AgenciesId = x.AgenciesId,
                    SaveDate = x.SaveDate,
                    Deleted = x.Deleted,
                    Status = x.Status,
                    UserId = x.UserId,
                    PresonsName = x.Livelihood.Persons.Name,
                    AgenciesName = x.Agenciess.Name,
                    MoneyName = x.Livelihood.Moneys.Symbol
                });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            return result;
        }
        public List<LivelihoodMonthViewModel> GetViewModel()
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var query = _context.LivelihoodMonths.Where(x => x.Status == true && x.Deleted == false)
                .Include(x => x.Livelihood).Include(x => x.Agenciess)
                .Select(x => new LivelihoodMonthViewModel
                {
                    Id = x.Id,
                    LivelihoodId = x.LivelihoodId,
                    Month = x.Month,
                    Year = x.Year,
                    PersonsId = x.PersonsId,
                    Amount = x.Amount,
                    MoneyId = x.MoneyId,
                    AgenciesId = x.AgenciesId,
                    SaveDate = x.SaveDate,
                    Deleted = x.Deleted,
                    Status = x.Status,
                    UserId = x.UserId,
                    PresonsName = x.Livelihood.Persons.Name,
                    AgenciesName = x.Agenciess.Name,
                    MoneyName = x.Livelihood.Moneys.Symbol
                });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            return result;
        }
        public List<LivelihoodMonthViewModel> GetViewModel(int agenciesId)
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var query = _context.LivelihoodMonths.Where(x => x.Status == true && x.Deleted == false && x.AgenciesId == agenciesId)
                .Include(x => x.Livelihood).Include(x => x.Agenciess)
                .Select(x => new LivelihoodMonthViewModel
                {
                    Id = x.Id,
                    LivelihoodId = x.LivelihoodId,
                    Month = x.Month,
                    Year = x.Year,
                    PersonsId = x.PersonsId,
                    Amount = x.Amount,
                    MoneyId = x.MoneyId,
                    AgenciesId = x.AgenciesId,
                    SaveDate = x.SaveDate,
                    Deleted = x.Deleted,
                    Status = x.Status,
                    UserId = x.UserId,
                    PresonsName = x.Livelihood.Persons.Name,
                    AgenciesName = x.Agenciess.Name,
                    MoneyName = x.Livelihood.Moneys.Symbol
                });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            return result;
        }
    }
}