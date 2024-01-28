using _0_Framework.Application.Auth;
using _0_Framework.Application;
using Contracts.PersonsReceiptContracts;
using Domin.PersonsReceiptDomin;

namespace Application
{
    public class PersonsReceiptApplication : IPersonsReceiptApplication
    {
        private readonly IPersonsReceiptRepository _personsReceiptRepository;
        private readonly IAuthHelper _authHelper;
        public PersonsReceiptApplication(IPersonsReceiptRepository PersonsReceiptRepository, IAuthHelper authHelper)
        {
            _personsReceiptRepository = PersonsReceiptRepository;
            _authHelper = authHelper;
        }
        public OperationResult Active(long id)
        {
            var operation = new OperationResult();
            var result = _personsReceiptRepository.Get(id);
            result.Active();
            _personsReceiptRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Create(PersonsReceiptCreate command)
        {
            var operation = new OperationResult();

            var userid = _authHelper.CurrentUserId();
            var agenciesId = _authHelper.CurrentAgenciesId();
            if (agenciesId == 0)
            {
                agenciesId = command.AgenciesId;
            }

            if (_personsReceiptRepository.Exists(x => x.Date == command.Date && x.Description == command.Description && x.AgenciesId == command.AgenciesId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var result = new PersonsReceipt(command.Date, command.Description, command.By, command.ReceiptNumber,
                command.Type, command.Amount, command.SafeBoxId, command.MoneyId, command.PersonId, userid, agenciesId);
            _personsReceiptRepository.Create(result);
            _personsReceiptRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            var result = _personsReceiptRepository.Get(id);
            _personsReceiptRepository.Delete(result);
            _personsReceiptRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Edit(PersonsReceiptEdit command)
        {
            var operation = new OperationResult();
            var result = _personsReceiptRepository.Get(command.Id);
            if (result == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            var userid = _authHelper.CurrentUserId();
            var agenciesId = _authHelper.CurrentAgenciesId();
            if (agenciesId == 0)
            {
                agenciesId = command.AgenciesId;
            }

            if (_personsReceiptRepository.Exists(x => x.Date == command.Date && x.Description == command.Description && x.AgenciesId == command.AgenciesId && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            result.Edit(command.Date, command.Description, command.By, command.ReceiptNumber,
                command.Type, command.Amount, command.SafeBoxId, command.MoneyId, command.PersonId, userid, agenciesId);
            _personsReceiptRepository.SaveChanges();
            return operation.Succedded();
        }
        public PersonsReceiptEdit GetDetails(long id)
        {
            return _personsReceiptRepository.GetDetails(id);
        }
        public List<PersonsReceiptViewModel> GetInActive()
        {
            return _personsReceiptRepository.GetInActive();
        }
        public List<PersonsReceiptViewModel> GetInActive(int agenciesId)
        {
            return _personsReceiptRepository.GetInActive(agenciesId);
        }
        public List<PersonsReceiptViewModel> GetRemove()
        {
            return _personsReceiptRepository.GetRemove();
        }
        public List<PersonsReceiptViewModel> GetRemove(int agenciesId)
        {
            return _personsReceiptRepository.GetRemove(agenciesId);
        }
        public List<PersonsReceiptViewModel> GetViewModel()
        {
            return _personsReceiptRepository.GetViewModel();
        }
        public List<PersonsReceiptViewModel> GetViewModel(int agenciesId)
        {
            return _personsReceiptRepository.GetViewModel(agenciesId);
        }
        public OperationResult InActive(long id)
        {
            var operation = new OperationResult();
            var result = _personsReceiptRepository.Get(id);
            result.InActive();
            _personsReceiptRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var result = _personsReceiptRepository.Get(id);
            result.Remove();
            _personsReceiptRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Reset(long id)
        {
            var operation = new OperationResult();
            var result = _personsReceiptRepository.Get(id);
            result.Reset();
            _personsReceiptRepository.SaveChanges();
            return operation.Succedded();
        }
    }
}