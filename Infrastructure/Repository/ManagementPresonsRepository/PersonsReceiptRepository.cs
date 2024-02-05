using _0_Framework.Infrastructure;
using Contracts.ManagementPresonsContracts.PersonsReceiptContracts;
using Domin.ManagementPresonsDomin.PersonsReceiptDomin;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.ManagementPresonsRepository
{
    public class PersonsReceiptRepository : RepositoryBase<long, PersonsReceipt>, IPersonsReceiptRepository
    {
        private readonly BE_Context _context;
        public PersonsReceiptRepository(BE_Context context) : base(context)
        {
            _context = context;
        }
        public PersonsReceiptEdit GetDetails(long id)
        {
            var result = _context.PersonsReceipt.Select(x => new PersonsReceiptEdit
            {
                Id = x.Id,
                Amount = x.Amount,
                By = x.By,
                Date = x.Date,
                Description = x.Description,
                MoneyId = x.MoneyId,
                PersonId = x.PersonId,
                ReceiptNumber = x.ReceiptNumber,
                SafeBoxId = x.SafeBoxId,
                Type = x.Type,
                AgenciesId = x.AgenciesId,
            }).FirstOrDefault(x => x.Id == id);
            return result;
        }
        public List<PersonsReceiptViewModel> GetInActive()
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var query = _context.PersonsReceipt.Where(x => x.Status == false)
                .Include(x => x.Persons).Include(x => x.Moneys).Include(x => x.Agenciess).Include(x => x.SafeBoxs)
                .Select(x => new PersonsReceiptViewModel
                {
                    Id = x.Id,
                    Amount = x.Amount,
                    By = x.By,
                    Date = x.Date,
                    Description = x.Description,
                    MoneyId = x.MoneyId,
                    PersonId = x.PersonId,
                    ReceiptNumber = x.ReceiptNumber,
                    SafeBoxId = x.SafeBoxId,
                    Type = x.Type,
                    SaveDate = x.SaveDate,
                    Deleted = x.Deleted,
                    Status = x.Status,
                    UserId = x.UserId,
                    AgenciesId = x.AgenciesId,
                    PersonName = x.Persons.Name,
                    MoneyName = x.Moneys.Symbol,
                    AgenciesName = x.Agenciess.Name,
                    SafeBoxName = x.SafeBoxs.Name,
                    Fingerprint = x.Fingerprint,
                    Picture = x.Picture,
                });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            return result;
        }
        public List<PersonsReceiptViewModel> GetInActive(int agenciesId)
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var query = _context.PersonsReceipt.Where(x => x.Status == false && x.AgenciesId == agenciesId)
                .Include(x => x.Persons).Include(x => x.Moneys).Include(x => x.Agenciess).Include(x => x.SafeBoxs)
                .Select(x => new PersonsReceiptViewModel
                {
                    Id = x.Id,
                    Amount = x.Amount,
                    By = x.By,
                    Date = x.Date,
                    Description = x.Description,
                    MoneyId = x.MoneyId,
                    PersonId = x.PersonId,
                    ReceiptNumber = x.ReceiptNumber,
                    SafeBoxId = x.SafeBoxId,
                    Type = x.Type,
                    SaveDate = x.SaveDate,
                    Deleted = x.Deleted,
                    Status = x.Status,
                    UserId = x.UserId,
                    AgenciesId = x.AgenciesId,
                    PersonName = x.Persons.Name,
                    MoneyName = x.Moneys.Name,
                    AgenciesName = x.Agenciess.Name,
                    SafeBoxName = x.SafeBoxs.Name,
                    Fingerprint = x.Fingerprint,
                    Picture = x.Picture,
                });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            return result;
        }
        public List<PersonsReceiptViewModel> GetRemove()
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var query = _context.PersonsReceipt.Where(x => x.Deleted == true)
                .Include(x => x.Persons).Include(x => x.Moneys).Include(x => x.Agenciess).Include(x => x.SafeBoxs)
                .Select(x => new PersonsReceiptViewModel
                {
                    Id = x.Id,
                    Amount = x.Amount,
                    By = x.By,
                    Date = x.Date,
                    Description = x.Description,
                    MoneyId = x.MoneyId,
                    PersonId = x.PersonId,
                    ReceiptNumber = x.ReceiptNumber,
                    SafeBoxId = x.SafeBoxId,
                    Type = x.Type,
                    SaveDate = x.SaveDate,
                    Deleted = x.Deleted,
                    Status = x.Status,
                    UserId = x.UserId,
                    AgenciesId = x.AgenciesId,
                    PersonName = x.Persons.Name,
                    MoneyName = x.Moneys.Name,
                    AgenciesName = x.Agenciess.Name,
                    SafeBoxName = x.SafeBoxs.Name,
                    Fingerprint = x.Fingerprint,
                    Picture = x.Picture,
                });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            return result;
        }
        public List<PersonsReceiptViewModel> GetRemove(int agenciesId)
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var query = _context.PersonsReceipt.Where(x => x.Deleted == true && x.AgenciesId == agenciesId)
                .Include(x => x.Persons).Include(x => x.Moneys).Include(x => x.Agenciess).Include(x => x.SafeBoxs)
                .Select(x => new PersonsReceiptViewModel
                {
                    Id = x.Id,
                    Amount = x.Amount,
                    By = x.By,
                    Date = x.Date,
                    Description = x.Description,
                    MoneyId = x.MoneyId,
                    PersonId = x.PersonId,
                    ReceiptNumber = x.ReceiptNumber,
                    SafeBoxId = x.SafeBoxId,
                    Type = x.Type,
                    SaveDate = x.SaveDate,
                    Deleted = x.Deleted,
                    Status = x.Status,
                    UserId = x.UserId,
                    AgenciesId = x.AgenciesId,
                    PersonName = x.Persons.Name,
                    MoneyName = x.Moneys.Name,
                    AgenciesName = x.Agenciess.Name,
                    SafeBoxName = x.SafeBoxs.Name,
                    Fingerprint = x.Fingerprint,
                    Picture = x.Picture,
                });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            return result;
        }
        public List<PersonsReceiptViewModel> GetViewModel()
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var query = _context.PersonsReceipt.Where(x => x.Status == true && x.Deleted == false)
                .Include(x => x.Persons).Include(x => x.Moneys).Include(x => x.Agenciess).Include(x => x.SafeBoxs)
                .Select(x => new PersonsReceiptViewModel
                {
                    Id = x.Id,
                    Amount = x.Amount,
                    By = x.By,
                    Date = x.Date,
                    Description = x.Description,
                    MoneyId = x.MoneyId,
                    PersonId = x.PersonId,
                    ReceiptNumber = x.ReceiptNumber,
                    SafeBoxId = x.SafeBoxId,
                    Type = x.Type,
                    SaveDate = x.SaveDate,
                    Deleted = x.Deleted,
                    Status = x.Status,
                    UserId = x.UserId,
                    AgenciesId = x.AgenciesId,
                    PersonName = x.Persons.Name,
                    MoneyName = x.Moneys.Name,
                    AgenciesName = x.Agenciess.Name,
                    SafeBoxName = x.SafeBoxs.Name,
                    Fingerprint = x.Fingerprint,
                    Picture = x.Picture,
                });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            return result;
        }
        public List<PersonsReceiptViewModel> GetViewModel(int agenciesId)
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var query = _context.PersonsReceipt.Where(x => x.Status == true && x.Deleted == false && x.AgenciesId == agenciesId)
                .Include(x => x.Persons).Include(x => x.Moneys).Include(x => x.Agenciess).Include(x => x.SafeBoxs)
                .Select(x => new PersonsReceiptViewModel
                {
                    Id = x.Id,
                    Amount = x.Amount,
                    By = x.By,
                    Date = x.Date,
                    Description = x.Description,
                    MoneyId = x.MoneyId,
                    PersonId = x.PersonId,
                    ReceiptNumber = x.ReceiptNumber,
                    SafeBoxId = x.SafeBoxId,
                    Type = x.Type,
                    SaveDate = x.SaveDate,
                    Deleted = x.Deleted,
                    Status = x.Status,
                    UserId = x.UserId,
                    AgenciesId = x.AgenciesId,
                    PersonName = x.Persons.Name,
                    MoneyName = x.Moneys.Name,
                    AgenciesName = x.Agenciess.Name,
                    SafeBoxName = x.SafeBoxs.Name,
                    Fingerprint = x.Fingerprint,
                    Picture = x.Picture,
                });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            return result;
        }
    }
}