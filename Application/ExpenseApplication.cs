using _0_Framework.Application.Auth;
using _0_Framework.Application;
using Contracts.ExpenseContracts;
using Domin.ExpenseDomin;

namespace Application
{
    public class ExpenseApplication : IExpenseApplication
    {
        private readonly IExpenseRepository _ExpenseRepository;
        private readonly IAuthHelper _authHelper;
        private readonly IFileUploader _fileUploader;
        public ExpenseApplication(IExpenseRepository ExpenseRepository, IAuthHelper authHelper, IFileUploader fileUploader)
        {
            _ExpenseRepository = ExpenseRepository;
            _authHelper = authHelper;
            _fileUploader = fileUploader;
        }
        public OperationResult Active(long id)
        {
            var operation = new OperationResult();
            var result = _ExpenseRepository.Get(id);
            result.Active();
            _ExpenseRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Create(ExpenseCreate command)
        {
            var operation = new OperationResult();

            var userid = _authHelper.CurrentUserId();
            var agenciesId = _authHelper.CurrentAgenciesId();
            if (agenciesId == 0)
            {
                agenciesId = command.AgenciesId;
            }

            if (_ExpenseRepository.Exists(x => x.Description == command.Description && x.Date == command.Date && x.AgenciesId == agenciesId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            string? slug = command?.Description?.Slugify();
            var logoPath = "Expenses";
            var logoname = slug;
            var picturePath = _fileUploader.Upload(command.Ph_Invoice, logoPath, logoname);
            if (picturePath == "no")
                return operation.Failed(ApplicationMessages.PhotoFormat);

            var result = new Expense(command.Description, command.Collection_Id, command.N_Invoice, command.Amount, command.Date, picturePath, command.PersonnelId, command.SafeBoxId, command.MoneyId, userid, agenciesId);
            _ExpenseRepository.Create(result);
            _ExpenseRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            var result = _ExpenseRepository.Get(id);
            _ExpenseRepository.Delete(result);
            _ExpenseRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Edit(ExpenseEdit command)
        {
            var operation = new OperationResult();

            var userid = _authHelper.CurrentUserId();
            var agenciesId = _authHelper.CurrentAgenciesId();
            if (agenciesId == 0)
            {
                agenciesId = command.AgenciesId;
            }

            var result = _ExpenseRepository.Get(command.Id);
            if (result == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_ExpenseRepository.Exists(x => x.Description == command.Description && x.Date == command.Date && x.AgenciesId == agenciesId && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            if (command.Ph_Invoice != null && result.Ph_Invoice != "")
            {
                string? path = result.Ph_Invoice;
                _fileUploader.Delete(path);
            }
            string? slug = command?.Description?.Slugify();
            var logoPath = "Expenses";
            var logoname = slug;
            var picturePath = _fileUploader.Upload(command.Ph_Invoice, logoPath, logoname);
            if (picturePath == "no")
                return operation.Failed(ApplicationMessages.PhotoFormat);

            result.Edit(command.Description, command.Collection_Id, command.N_Invoice, command.Amount, command.Date, picturePath, command.PersonnelId, command.SafeBoxId, command.MoneyId, userid, agenciesId);
            _ExpenseRepository.SaveChanges();
            return operation.Succedded();
        }
        public ExpenseEdit GetDetails(long id)
        {
            return _ExpenseRepository.GetDetails(id);
        }
        public List<ExpenseViewModel> GetInActive()
        {
            return _ExpenseRepository.GetInActive();
        }
        public List<ExpenseViewModel> GetInActive(int agenciesId)
        {
            return _ExpenseRepository.GetInActive(agenciesId);
        }
        public List<ExpenseViewModel> GetRemove()
        {
            return _ExpenseRepository.GetRemove();
        }
        public List<ExpenseViewModel> GetRemove(int agenciesId)
        {
            return _ExpenseRepository.GetRemove(agenciesId);
        }
        public List<ExpenseViewModel> GetViewModel()
        {
            return _ExpenseRepository.GetViewModel();
        }
        public List<ExpenseViewModel> GetViewModel(int agenciesId)
        {
            return _ExpenseRepository.GetViewModel(agenciesId);
        }
        public OperationResult InActive(long id)
        {
            var operation = new OperationResult();
            var result = _ExpenseRepository.Get(id);
            result.InActive();
            _ExpenseRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var result = _ExpenseRepository.Get(id);
            result.Remove();
            _ExpenseRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Reset(long id)
        {
            var operation = new OperationResult();
            var result = _ExpenseRepository.Get(id);
            result.Reset();
            _ExpenseRepository.SaveChanges();
            return operation.Succedded();
        }
    }
}