using _0_Framework.Infrastructure;
using Contracts.ExpenseContracts;
using Domin.ExpenseDomin;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ExpenseRepository : RepositoryBase<long, Expense>, IExpenseRepository
    {
        private readonly BE_Context _context;
        public ExpenseRepository(BE_Context context) : base(context)
        {
            _context = context;
        }
        public ExpenseEdit GetDetails(long id)
        {
            var Expense = _context.Expensess.Select(x => new ExpenseEdit
            {
                Id = x.Id,
                Description = x.Description,
                Amount = x.Amount,
                Collection_Id = x.Collection_Id,
                Date = x.Date,
                MoneyId = x.Money_Id,
                N_Invoice = x.N_Invoice,
                PersonnelId = x.Personnel_Id,
                SafeBoxId = x.SafeBox_Id,
                AgenciesId = x.AgenciesId,
            }).FirstOrDefault(x => x.Id == id);
            return Expense;
        }
        public List<ExpenseViewModel> GetInActive()
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var personnel = _context.Personnels.Select(x => new { x.Id, x.FullName }).ToList();
            var moneys = _context.Moneies.Select(x => new { x.Id, x.Symbol }).ToList();
            var safeBox = _context.SafeBoxs.Select(x => new { x.Id, x.Name }).ToList();
            var agencies = _context.Agenciess.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.Expensess.Where(x => x.Status == false).Include(x => x.Collection).Select(x => new ExpenseViewModel
            {
                Id = x.Id,
                Description = x.Description,
                Amount = x.Amount,
                CollectionId = x.Collection_Id,
                Date = x.Date,
                MoneyId = x.Money_Id,
                N_Invoice = x.N_Invoice,
                PersonnelId = x.Personnel_Id,
                Ph_Invoice = x.Ph_Invoice,
                SafeBoxId = x.SafeBox_Id,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                UserId = x.UserId,
                AgenciesId = x.AgenciesId,
                CollectionName = x.Collection.Name
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            result.ForEach(item => item.PersonnelName = personnel.FirstOrDefault(x => x.Id == item.PersonnelId)?.FullName);
            result.ForEach(item => item.MoneyName = moneys.FirstOrDefault(x => x.Id == item.MoneyId)?.Symbol);
            result.ForEach(item => item.SafeBoxName = safeBox.FirstOrDefault(x => x.Id == item.SafeBoxId)?.Name);
            result.ForEach(item => item.NameAgencies = agencies.FirstOrDefault(x => x.Id == item.AgenciesId)?.Name);
            return result;
        }
        public List<ExpenseViewModel> GetInActive(int agenciesId)
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var personnel = _context.Personnels.Select(x => new { x.Id, x.FullName }).ToList();
            var moneys = _context.Moneies.Select(x => new { x.Id, x.Symbol }).ToList();
            var safeBox = _context.SafeBoxs.Select(x => new { x.Id, x.Name }).ToList();
            var agencies = _context.Agenciess.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.Expensess.Where(x => x.Status == false && x.AgenciesId == agenciesId).Include(x => x.Collection).Select(x => new ExpenseViewModel
            {
                Id = x.Id,
                Description = x.Description,
                Amount = x.Amount,
                CollectionId = x.Collection_Id,
                Date = x.Date,
                MoneyId = x.Money_Id,
                N_Invoice = x.N_Invoice,
                PersonnelId = x.Personnel_Id,
                Ph_Invoice = x.Ph_Invoice,
                SafeBoxId = x.SafeBox_Id,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                UserId = x.UserId,
                AgenciesId = x.AgenciesId,
                CollectionName = x.Collection.Name
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            result.ForEach(item => item.PersonnelName = personnel.FirstOrDefault(x => x.Id == item.PersonnelId)?.FullName);
            result.ForEach(item => item.MoneyName = moneys.FirstOrDefault(x => x.Id == item.MoneyId)?.Symbol);
            result.ForEach(item => item.SafeBoxName = safeBox.FirstOrDefault(x => x.Id == item.SafeBoxId)?.Name);
            result.ForEach(item => item.NameAgencies = agencies.FirstOrDefault(x => x.Id == item.AgenciesId)?.Name);
            return result;
        }
        public List<ExpenseViewModel> GetRemove()
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var personnel = _context.Personnels.Select(x => new { x.Id, x.FullName }).ToList();
            var moneys = _context.Moneies.Select(x => new { x.Id, x.Symbol }).ToList();
            var safeBox = _context.SafeBoxs.Select(x => new { x.Id, x.Name }).ToList();
            var agencies = _context.Agenciess.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.Expensess.Where(x => x.Deleted == true).Include(x => x.Collection).Select(x => new ExpenseViewModel
            {
                Id = x.Id,
                Description = x.Description,
                Amount = x.Amount,
                CollectionId = x.Collection_Id,
                Date = x.Date,
                MoneyId = x.Money_Id,
                N_Invoice = x.N_Invoice,
                PersonnelId = x.Personnel_Id,
                Ph_Invoice = x.Ph_Invoice,
                SafeBoxId = x.SafeBox_Id,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                UserId = x.UserId,
                AgenciesId = x.AgenciesId,
                CollectionName = x.Collection.Name
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            result.ForEach(item => item.PersonnelName = personnel.FirstOrDefault(x => x.Id == item.PersonnelId)?.FullName);
            result.ForEach(item => item.MoneyName = moneys.FirstOrDefault(x => x.Id == item.MoneyId)?.Symbol);
            result.ForEach(item => item.SafeBoxName = safeBox.FirstOrDefault(x => x.Id == item.SafeBoxId)?.Name);
            result.ForEach(item => item.NameAgencies = agencies.FirstOrDefault(x => x.Id == item.AgenciesId)?.Name);
            return result;
        }
        public List<ExpenseViewModel> GetRemove(int agenciesId)
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var personnel = _context.Personnels.Select(x => new { x.Id, x.FullName }).ToList();
            var moneys = _context.Moneies.Select(x => new { x.Id, x.Symbol }).ToList();
            var safeBox = _context.SafeBoxs.Select(x => new { x.Id, x.Name }).ToList();
            var agencies = _context.Agenciess.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.Expensess.Where(x => x.Deleted == true && x.AgenciesId == agenciesId).Include(x => x.Collection).Select(x => new ExpenseViewModel
            {
                Id = x.Id,
                Description = x.Description,
                Amount = x.Amount,
                CollectionId = x.Collection_Id,
                Date = x.Date,
                MoneyId = x.Money_Id,
                N_Invoice = x.N_Invoice,
                PersonnelId = x.Personnel_Id,
                Ph_Invoice = x.Ph_Invoice,
                SafeBoxId = x.SafeBox_Id,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                UserId = x.UserId,
                AgenciesId = x.AgenciesId,
                CollectionName = x.Collection.Name
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            result.ForEach(item => item.PersonnelName = personnel.FirstOrDefault(x => x.Id == item.PersonnelId)?.FullName);
            result.ForEach(item => item.MoneyName = moneys.FirstOrDefault(x => x.Id == item.MoneyId)?.Symbol);
            result.ForEach(item => item.SafeBoxName = safeBox.FirstOrDefault(x => x.Id == item.SafeBoxId)?.Name);
            result.ForEach(item => item.NameAgencies = agencies.FirstOrDefault(x => x.Id == item.AgenciesId)?.Name);
            return result;
        }
        public List<ExpenseViewModel> GetViewModel()
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var personnel = _context.Personnels.Select(x => new { x.Id, x.FullName }).ToList();
            var moneys = _context.Moneies.Select(x => new { x.Id, x.Symbol }).ToList();
            var safeBox = _context.SafeBoxs.Select(x => new { x.Id, x.Name }).ToList();
            var agencies = _context.Agenciess.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.Expensess.Where(x => x.Status == true && x.Deleted == false).Include(x => x.Collection).Select(x => new ExpenseViewModel
            {
                Id = x.Id,
                Description = x.Description,
                Amount = x.Amount,
                CollectionId = x.Collection_Id,
                Date = x.Date,
                MoneyId = x.Money_Id,
                N_Invoice = x.N_Invoice,
                PersonnelId = x.Personnel_Id,
                Ph_Invoice = x.Ph_Invoice,
                SafeBoxId = x.SafeBox_Id,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                UserId = x.UserId,
                AgenciesId = x.AgenciesId,
                CollectionName = x.Collection.Name
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            result.ForEach(item => item.PersonnelName = personnel.FirstOrDefault(x => x.Id == item.PersonnelId)?.FullName);
            result.ForEach(item => item.MoneyName = moneys.FirstOrDefault(x => x.Id == item.MoneyId)?.Symbol);
            result.ForEach(item => item.SafeBoxName = safeBox.FirstOrDefault(x => x.Id == item.SafeBoxId)?.Name);
            result.ForEach(item => item.NameAgencies = agencies.FirstOrDefault(x => x.Id == item.AgenciesId)?.Name);
            return result;
        }
        public List<ExpenseViewModel> GetViewModel(int agenciesId)
        {
            var users = _context.Users.Select(x => new { x.Id, x.FullName, x.UserName }).ToList();
            var personnel = _context.Personnels.Select(x => new { x.Id, x.FullName }).ToList();
            var moneys = _context.Moneies.Select(x => new { x.Id, x.Symbol }).ToList();
            var safeBox = _context.SafeBoxs.Select(x => new { x.Id, x.Name }).ToList();
            var agencies = _context.Agenciess.Select(x => new { x.Id, x.Name }).ToList();
            var query = _context.Expensess.Where(x => x.Status == true && x.Deleted == false && x.AgenciesId == agenciesId).Include(x => x.Collection).Select(x => new ExpenseViewModel
            {
                Id = x.Id,
                Description = x.Description,
                Amount = x.Amount,
                CollectionId = x.Collection_Id,
                Date = x.Date,
                MoneyId = x.Money_Id,
                N_Invoice = x.N_Invoice,
                PersonnelId = x.Personnel_Id,
                Ph_Invoice = x.Ph_Invoice,
                SafeBoxId = x.SafeBox_Id,
                SaveDate = x.SaveDate,
                Deleted = x.Deleted,
                Status = x.Status,
                UserId = x.UserId,
                AgenciesId = x.AgenciesId,
                CollectionName = x.Collection.Name
            });
            var result = query.OrderByDescending(x => x.Id).ToList();
            result.ForEach(item => item.UserName = (users.FirstOrDefault(x => x.Id == item.UserId)?.FullName) + " - " + users.FirstOrDefault(x => x.Id == item.UserId)?.UserName);
            result.ForEach(item => item.PersonnelName = personnel.FirstOrDefault(x => x.Id == item.PersonnelId)?.FullName);
            result.ForEach(item => item.MoneyName = moneys.FirstOrDefault(x => x.Id == item.MoneyId)?.Symbol);
            result.ForEach(item => item.SafeBoxName = safeBox.FirstOrDefault(x => x.Id == item.SafeBoxId)?.Name);
            result.ForEach(item => item.NameAgencies = agencies.FirstOrDefault(x => x.Id == item.AgenciesId)?.Name);
            return result;
        }
    }
}