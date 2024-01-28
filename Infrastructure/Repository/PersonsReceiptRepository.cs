using _0_Framework.Infrastructure;
using Contracts.PersonsReceiptContracts;
using Domin.PersonsReceiptDomin;

namespace Infrastructure.Repository
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
            var persons = _context.Personss.Select(x => new { x.Id, x.Name }).ToList();
            var moneys = _context.Moneies.Select(x => new { x.Id, x.Symbol }).ToList();
            var safeBox = _context.SafeBoxs.Select(x => new { x.Id, x.Name }).ToList();
            var agencies = _context.Agenciess.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.PersonsReceipt.Where(x => x.Status == false).Select(x => new PersonsReceiptViewModel
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
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            result.ForEach(item => item.PersonName = persons.FirstOrDefault(x => x.Id == item.PersonId)?.Name);
            result.ForEach(item => item.MoneyName = moneys.FirstOrDefault(x => x.Id == item.MoneyId)?.Symbol);
            result.ForEach(item => item.SafeBoxName = safeBox.FirstOrDefault(x => x.Id == item.SafeBoxId)?.Name);
            result.ForEach(item => item.NameAgencies = agencies.FirstOrDefault(x => x.Id == item.AgenciesId)?.Name);
            return result;
        }
        public List<PersonsReceiptViewModel> GetInActive(int agenciesId)
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var persons = _context.Personss.Select(x => new { x.Id, x.Name }).ToList();
            var moneys = _context.Moneies.Select(x => new { x.Id, x.Symbol }).ToList();
            var safeBox = _context.SafeBoxs.Select(x => new { x.Id, x.Name }).ToList();
            var agencies = _context.Agenciess.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.PersonsReceipt.Where(x => x.Status == false && x.AgenciesId == agenciesId).Select(x => new PersonsReceiptViewModel
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
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            result.ForEach(item => item.PersonName = persons.FirstOrDefault(x => x.Id == item.PersonId)?.Name);
            result.ForEach(item => item.MoneyName = moneys.FirstOrDefault(x => x.Id == item.MoneyId)?.Symbol);
            result.ForEach(item => item.SafeBoxName = safeBox.FirstOrDefault(x => x.Id == item.SafeBoxId)?.Name);
            result.ForEach(item => item.NameAgencies = agencies.FirstOrDefault(x => x.Id == item.AgenciesId)?.Name);
            return result;
        }
        public List<PersonsReceiptViewModel> GetRemove()
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var persons = _context.Personss.Select(x => new { x.Id, x.Name }).ToList();
            var moneys = _context.Moneies.Select(x => new { x.Id, x.Symbol }).ToList();
            var safeBox = _context.SafeBoxs.Select(x => new { x.Id, x.Name }).ToList();
            var agencies = _context.Agenciess.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.PersonsReceipt.Where(x => x.Deleted == true).Select(x => new PersonsReceiptViewModel
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
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            result.ForEach(item => item.PersonName = persons.FirstOrDefault(x => x.Id == item.PersonId)?.Name);
            result.ForEach(item => item.MoneyName = moneys.FirstOrDefault(x => x.Id == item.MoneyId)?.Symbol);
            result.ForEach(item => item.SafeBoxName = safeBox.FirstOrDefault(x => x.Id == item.SafeBoxId)?.Name);
            result.ForEach(item => item.NameAgencies = agencies.FirstOrDefault(x => x.Id == item.AgenciesId)?.Name);
            return result;
        }
        public List<PersonsReceiptViewModel> GetRemove(int agenciesId)
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var persons = _context.Personss.Select(x => new { x.Id, x.Name }).ToList();
            var moneys = _context.Moneies.Select(x => new { x.Id, x.Symbol }).ToList();
            var safeBox = _context.SafeBoxs.Select(x => new { x.Id, x.Name }).ToList();
            var agencies = _context.Agenciess.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.PersonsReceipt.Where(x => x.Deleted == true && x.AgenciesId == agenciesId).Select(x => new PersonsReceiptViewModel
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
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            result.ForEach(item => item.PersonName = persons.FirstOrDefault(x => x.Id == item.PersonId)?.Name);
            result.ForEach(item => item.MoneyName = moneys.FirstOrDefault(x => x.Id == item.MoneyId)?.Symbol);
            result.ForEach(item => item.SafeBoxName = safeBox.FirstOrDefault(x => x.Id == item.SafeBoxId)?.Name);
            result.ForEach(item => item.NameAgencies = agencies.FirstOrDefault(x => x.Id == item.AgenciesId)?.Name);
            return result;
        }
        public List<PersonsReceiptViewModel> GetViewModel()
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var persons = _context.Personss.Select(x => new { x.Id, x.Name }).ToList();
            var moneys = _context.Moneies.Select(x => new { x.Id, x.Symbol }).ToList();
            var safeBox = _context.SafeBoxs.Select(x => new { x.Id, x.Name }).ToList();
            var agencies = _context.Agenciess.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.PersonsReceipt.Where(x => x.Status == true && x.Deleted == false).Select(x => new PersonsReceiptViewModel
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
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            result.ForEach(item => item.PersonName = persons.FirstOrDefault(x => x.Id == item.PersonId)?.Name);
            result.ForEach(item => item.MoneyName = moneys.FirstOrDefault(x => x.Id == item.MoneyId)?.Symbol);
            result.ForEach(item => item.SafeBoxName = safeBox.FirstOrDefault(x => x.Id == item.SafeBoxId)?.Name);
            result.ForEach(item => item.NameAgencies = agencies.FirstOrDefault(x => x.Id == item.AgenciesId)?.Name);
            return result;
        }
        public List<PersonsReceiptViewModel> GetViewModel(int agenciesId)
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var persons = _context.Personss.Select(x => new { x.Id, x.Name }).ToList();
            var moneys = _context.Moneies.Select(x => new { x.Id, x.Symbol }).ToList();
            var safeBox = _context.SafeBoxs.Select(x => new { x.Id, x.Name }).ToList();
            var agencies = _context.Agenciess.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.PersonsReceipt.Where(x => x.Status == true && x.Deleted == false && x.AgenciesId == agenciesId).Select(x => new PersonsReceiptViewModel
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
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            result.ForEach(item => item.PersonName = persons.FirstOrDefault(x => x.Id == item.PersonId)?.Name);
            result.ForEach(item => item.MoneyName = moneys.FirstOrDefault(x => x.Id == item.MoneyId)?.Symbol);
            result.ForEach(item => item.SafeBoxName = safeBox.FirstOrDefault(x => x.Id == item.SafeBoxId)?.Name);
            result.ForEach(item => item.NameAgencies = agencies.FirstOrDefault(x => x.Id == item.AgenciesId)?.Name);
            return result;
        }
    }
}