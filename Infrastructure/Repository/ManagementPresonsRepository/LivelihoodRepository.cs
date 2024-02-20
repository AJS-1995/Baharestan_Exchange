using _0_Framework.Application;
using _0_Framework.Infrastructure;
using Contracts.ManagementPresonsContracts.LivelihoodContracts;
using Domin.ManagementPresonsDomin.LivelihoodDomin;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.ManagementPresonsRepository
{
    public class LivelihoodRepository : RepositoryBase<int, Livelihood>, ILivelihoodRepository
    {
        private readonly BE_Context _context;
        public LivelihoodRepository(BE_Context context) : base(context)
        {
            _context = context;
        }
        public LivelihoodEdit GetDetails(int id)
        {
            var result = _context.Livelihoods.Select(x => new LivelihoodEdit
            {
                Id = x.Id,
                Amount = x.Amount,
                Cancel = x.Cancel,
                EDate = x.EDate,
                MoneyId = x.MoneyId,
                PersonsId = x.PersonsId,
                SDate = x.SDate,
                AgenciesId = x.AgenciesId,
                PersonName = x.Persons.Name
            }).FirstOrDefault(x => x.Id == id);
            return result;
        }
        public List<LivelihoodViewModel> GetInActive()
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var query = _context.Livelihoods.Where(x => x.Status == false)
                .Include(x => x.Persons).Include(x => x.Agenciess).Include(x => x.Moneys)
                .Select(x => new LivelihoodViewModel
                {
                    Id = x.Id,
                    Amount = x.Amount,
                    Cancel = x.Cancel,
                    EDate = x.EDate,
                    MoneyId = x.MoneyId,
                    PersonsId = x.PersonsId,
                    SDate = x.SDate,
                    AgenciesId = x.AgenciesId,
                    SaveDate = x.SaveDate,
                    Deleted = x.Deleted,
                    Status = x.Status,
                    UserId = x.UserId,
                    PresonsName = x.Persons.Name,
                    AgenciesName = x.Agenciess.Name,
                    MoneyName = x.Moneys.Symbol
                });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            return result;
        }
        public List<LivelihoodViewModel> GetInActive(int agenciesId)
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var query = _context.Livelihoods.Where(x => x.Status == false && x.AgenciesId == agenciesId)
                .Include(x => x.Persons).Include(x => x.Agenciess).Include(x => x.Moneys)
                .Select(x => new LivelihoodViewModel
                {
                    Id = x.Id,
                    Amount = x.Amount,
                    Cancel = x.Cancel,
                    EDate = x.EDate,
                    MoneyId = x.MoneyId,
                    PersonsId = x.PersonsId,
                    SDate = x.SDate,
                    AgenciesId = x.AgenciesId,
                    SaveDate = x.SaveDate,
                    Deleted = x.Deleted,
                    Status = x.Status,
                    UserId = x.UserId,
                    PresonsName = x.Persons.Name,
                    AgenciesName = x.Agenciess.Name,
                    MoneyName = x.Moneys.Symbol
                });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            return result;
        }
        public List<LivelihoodViewModel> GetRemove()
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var query = _context.Livelihoods.Where(x => x.Deleted == true)
                .Include(x => x.Persons).Include(x => x.Agenciess).Include(x => x.Moneys)
                .Select(x => new LivelihoodViewModel
                {
                    Id = x.Id,
                    Amount = x.Amount,
                    Cancel = x.Cancel,
                    EDate = x.EDate,
                    MoneyId = x.MoneyId,
                    PersonsId = x.PersonsId,
                    SDate = x.SDate,
                    AgenciesId = x.AgenciesId,
                    SaveDate = x.SaveDate,
                    Deleted = x.Deleted,
                    Status = x.Status,
                    UserId = x.UserId,
                    PresonsName = x.Persons.Name,
                    AgenciesName = x.Agenciess.Name,
                    MoneyName = x.Moneys.Symbol
                });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            return result;
        }
        public List<LivelihoodViewModel> GetRemove(int agenciesId)
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var query = _context.Livelihoods.Where(x => x.Deleted == true && x.AgenciesId == agenciesId)
                .Include(x => x.Persons).Include(x => x.Agenciess).Include(x => x.Moneys)
                .Select(x => new LivelihoodViewModel
                {
                    Id = x.Id,
                    Amount = x.Amount,
                    Cancel = x.Cancel,
                    EDate = x.EDate,
                    MoneyId = x.MoneyId,
                    PersonsId = x.PersonsId,
                    SDate = x.SDate,
                    AgenciesId = x.AgenciesId,
                    SaveDate = x.SaveDate,
                    Deleted = x.Deleted,
                    Status = x.Status,
                    UserId = x.UserId,
                    PresonsName = x.Persons.Name,
                    AgenciesName = x.Agenciess.Name,
                    MoneyName = x.Moneys.Symbol
                });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            return result;
        }
        public List<LivelihoodViewModel> GetViewModel()
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var query = _context.Livelihoods.Where(x => x.Status == true && x.Deleted == false)
                .Include(x => x.Persons).Include(x => x.Agenciess).Include(x => x.Moneys)
                .Select(x => new LivelihoodViewModel
                {
                    Id = x.Id,
                    Amount = x.Amount,
                    Cancel = x.Cancel,
                    EDate = x.EDate,
                    MoneyId = x.MoneyId,
                    PersonsId = x.PersonsId,
                    SDate = x.SDate,
                    AgenciesId = x.AgenciesId,
                    SaveDate = x.SaveDate,
                    Deleted = x.Deleted,
                    Status = x.Status,
                    UserId = x.UserId,
                    PresonsName = x.Persons.Name,
                    AgenciesName = x.Agenciess.Name,
                    MoneyName = x.Moneys.Symbol
                });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            return result;
        }
        public List<LivelihoodViewModel> GetViewModel(int agenciesId)
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var query = _context.Livelihoods.Where(x => x.Status == true && x.Deleted == false && x.AgenciesId == agenciesId)
                .Include(x => x.Persons).Include(x => x.Agenciess).Include(x => x.Moneys)
                .Select(x => new LivelihoodViewModel
                {
                    Id = x.Id,
                    Amount = x.Amount,
                    Cancel = x.Cancel,
                    EDate = x.EDate,
                    MoneyId = x.MoneyId,
                    PersonsId = x.PersonsId,
                    SDate = x.SDate,
                    AgenciesId = x.AgenciesId,
                    SaveDate = x.SaveDate,
                    Deleted = x.Deleted,
                    Status = x.Status,
                    UserId = x.UserId,
                    PresonsName = x.Persons.Name,
                    AgenciesName = x.Agenciess.Name,
                    MoneyName = x.Moneys.Symbol
                });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            return result;
        }
    }
}