using _0_Framework.Infrastructure;
using Contracts.ManagementPresonsContracts.PersonsMoneyExchangeContracts;
using Domin.ManagementPresonsDomin.PersonsMoneyExchangeDomin;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.ManagementPresonsRepository
{
    public class PersonsMoneyExchangeRepository : RepositoryBase<long, PersonsMoneyExchange>, IPersonsMoneyExchangeRepository
    {
        private readonly BE_Context _context;
        public PersonsMoneyExchangeRepository(BE_Context context) : base(context)
        {
            _context = context;
        }
        public PersonsMoneyExchangeEdit GetDetails(long id)
        {
            var result = _context.PersonsMoneyExchanges.Select(x => new PersonsMoneyExchangeEdit
            {
                Id = x.Id,
                Date = x.Date,
                MoneyId_One = x.MoneyId_One,
                MoneyId_Two = x.MoneyId_Two,
                Amount_One = x.Amount_One,
                Amount_Two = x.Amount_Two,
                Price = x.Price,
                PersonId = x.PersonId,
                Type = x.Type,
                AgenciesId = x.AgenciesId,
            }).FirstOrDefault(x => x.Id == id);
            return result;
        }
        public List<PersonsMoneyExchangeViewModel> GetInActive()
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var money = _context.Moneies.Select(x => new { x.Id, x.Name, x.Symbol }).ToList();
            var query = _context.PersonsMoneyExchanges.Where(x => x.Status == false)
                .Include(x => x.Persons).Include(x => x.Agenciess)
                .Select(x => new PersonsMoneyExchangeViewModel
                {
                    Id = x.Id,
                    Date = x.Date,
                    MoneyId_One = x.MoneyId_One,
                    MoneyId_Two = x.MoneyId_Two,
                    Amount_One = x.Amount_One,
                    Amount_Two = x.Amount_Two,
                    Price = x.Price,
                    PersonId = x.PersonId,
                    Type = x.Type,
                    AgenciesId = x.AgenciesId,
                    SaveDate = x.SaveDate,
                    Deleted = x.Deleted,
                    Status = x.Status,
                    UserId = x.UserId,
                    PersonName = x.Persons.Name,
                    AgenciesName = x.Agenciess.Name,
                });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            result.ForEach(item => item.MoneyName_One = (money.FirstOrDefault(x => x.Id == item.MoneyId_One)?.Symbol));
            result.ForEach(item => item.MoneyName_Two = (money.FirstOrDefault(x => x.Id == item.MoneyId_Two)?.Symbol));
            return result;
        }
        public List<PersonsMoneyExchangeViewModel> GetInActive(int agenciesId)
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var money = _context.Moneies.Select(x => new { x.Id, x.Name, x.Symbol }).ToList();
            var query = _context.PersonsMoneyExchanges.Where(x => x.Status == false && x.AgenciesId == agenciesId)
                .Include(x => x.Persons).Include(x => x.Agenciess)
                .Select(x => new PersonsMoneyExchangeViewModel
                {
                    Id = x.Id,
                    Date = x.Date,
                    MoneyId_One = x.MoneyId_One,
                    MoneyId_Two = x.MoneyId_Two,
                    Amount_One = x.Amount_One,
                    Amount_Two = x.Amount_Two,
                    Price = x.Price,
                    PersonId = x.PersonId,
                    Type = x.Type,
                    AgenciesId = x.AgenciesId,
                    SaveDate = x.SaveDate,
                    Deleted = x.Deleted,
                    Status = x.Status,
                    UserId = x.UserId,
                    PersonName = x.Persons.Name,
                    AgenciesName = x.Agenciess.Name,
                });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            result.ForEach(item => item.MoneyName_One = (money.FirstOrDefault(x => x.Id == item.MoneyId_One)?.Symbol));
            result.ForEach(item => item.MoneyName_Two = (money.FirstOrDefault(x => x.Id == item.MoneyId_Two)?.Symbol));
            return result;
        }
        public List<PersonsMoneyExchangeViewModel> GetRemove()
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var money = _context.Moneies.Select(x => new { x.Id, x.Name, x.Symbol }).ToList();
            var query = _context.PersonsMoneyExchanges.Where(x => x.Deleted == true)
                .Include(x => x.Persons).Include(x => x.Agenciess)
                .Select(x => new PersonsMoneyExchangeViewModel
                {
                    Id = x.Id,
                    Date = x.Date,
                    MoneyId_One = x.MoneyId_One,
                    MoneyId_Two = x.MoneyId_Two,
                    Amount_One = x.Amount_One,
                    Amount_Two = x.Amount_Two,
                    Price = x.Price,
                    PersonId = x.PersonId,
                    Type = x.Type,
                    AgenciesId = x.AgenciesId,
                    SaveDate = x.SaveDate,
                    Deleted = x.Deleted,
                    Status = x.Status,
                    UserId = x.UserId,
                    PersonName = x.Persons.Name,
                    AgenciesName = x.Agenciess.Name,
                });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            result.ForEach(item => item.MoneyName_One = (money.FirstOrDefault(x => x.Id == item.MoneyId_One)?.Symbol));
            result.ForEach(item => item.MoneyName_Two = (money.FirstOrDefault(x => x.Id == item.MoneyId_Two)?.Symbol));
            return result;
        }
        public List<PersonsMoneyExchangeViewModel> GetRemove(int agenciesId)
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var money = _context.Moneies.Select(x => new { x.Id, x.Name, x.Symbol }).ToList();
            var query = _context.PersonsMoneyExchanges.Where(x => x.Deleted == true && x.AgenciesId == agenciesId)
                .Include(x => x.Persons).Include(x => x.Agenciess)
                .Select(x => new PersonsMoneyExchangeViewModel
                {
                    Id = x.Id,
                    Date = x.Date,
                    MoneyId_One = x.MoneyId_One,
                    MoneyId_Two = x.MoneyId_Two,
                    Amount_One = x.Amount_One,
                    Amount_Two = x.Amount_Two,
                    Price = x.Price,
                    PersonId = x.PersonId,
                    Type = x.Type,
                    AgenciesId = x.AgenciesId,
                    SaveDate = x.SaveDate,
                    Deleted = x.Deleted,
                    Status = x.Status,
                    UserId = x.UserId,
                    PersonName = x.Persons.Name,
                    AgenciesName = x.Agenciess.Name,
                });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            result.ForEach(item => item.MoneyName_One = (money.FirstOrDefault(x => x.Id == item.MoneyId_One)?.Symbol));
            result.ForEach(item => item.MoneyName_Two = (money.FirstOrDefault(x => x.Id == item.MoneyId_Two)?.Symbol));
            return result;
        }
        public List<PersonsMoneyExchangeViewModel> GetViewModel()
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var money = _context.Moneies.Select(x => new { x.Id, x.Name, x.Symbol }).ToList();
            var query = _context.PersonsMoneyExchanges.Where(x => x.Status == true && x.Deleted == false)
                .Include(x => x.Persons).Include(x => x.Agenciess)
                .Select(x => new PersonsMoneyExchangeViewModel
                {
                    Id = x.Id,
                    Date = x.Date,
                    MoneyId_One = x.MoneyId_One,
                    MoneyId_Two = x.MoneyId_Two,
                    Amount_One = x.Amount_One,
                    Amount_Two = x.Amount_Two,
                    Price = x.Price,
                    PersonId = x.PersonId,
                    Type = x.Type,
                    AgenciesId = x.AgenciesId,
                    SaveDate = x.SaveDate,
                    Deleted = x.Deleted,
                    Status = x.Status,
                    UserId = x.UserId,
                    PersonName = x.Persons.Name,
                    AgenciesName = x.Agenciess.Name,
                });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            result.ForEach(item => item.MoneyName_One = (money.FirstOrDefault(x => x.Id == item.MoneyId_One)?.Symbol));
            result.ForEach(item => item.MoneyName_Two = (money.FirstOrDefault(x => x.Id == item.MoneyId_Two)?.Symbol));
            return result;
        }
        public List<PersonsMoneyExchangeViewModel> GetViewModel(int agenciesId)
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var money = _context.Moneies.Select(x => new { x.Id, x.Name, x.Symbol }).ToList();
            var query = _context.PersonsMoneyExchanges.Where(x => x.Status == true && x.Deleted == false && x.AgenciesId == agenciesId)
                .Include(x => x.Persons).Include(x => x.Agenciess)
                .Select(x => new PersonsMoneyExchangeViewModel
                {
                    Id = x.Id,
                    Date = x.Date,
                    MoneyId_One = x.MoneyId_One,
                    MoneyId_Two = x.MoneyId_Two,
                    Amount_One = x.Amount_One,
                    Amount_Two = x.Amount_Two,
                    Price = x.Price,
                    PersonId = x.PersonId,
                    Type = x.Type,
                    AgenciesId = x.AgenciesId,
                    SaveDate = x.SaveDate,
                    Deleted = x.Deleted,
                    Status = x.Status,
                    UserId = x.UserId,
                    PersonName = x.Persons.Name,
                    AgenciesName = x.Agenciess.Name,
                });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            result.ForEach(item => item.MoneyName_One = (money.FirstOrDefault(x => x.Id == item.MoneyId_One)?.Symbol));
            result.ForEach(item => item.MoneyName_Two = (money.FirstOrDefault(x => x.Id == item.MoneyId_Two)?.Symbol));
            return result;
        }
    }
}