using _0_Framework.Application.Auth;
using _0_Framework.Application;
using Domin.ManagementPresonsDomin.PersonsMoneyExchangeDomin;
using Contracts.ManagementPresonsContracts.PersonsMoneyExchangeContracts;
using _0_Framework.Application.PersonsAuth;

namespace Application.ManagementPresonsApplication
{
    public class PersonsMoneyExchangeApplication : IPersonsMoneyExchangeApplication
    {
        private readonly IPersonsMoneyExchangeRepository _personsMoneyExchangeRepository;
        private readonly IAuthHelper _authHelper;
        public PersonsMoneyExchangeApplication(IPersonsMoneyExchangeRepository PersonsMoneyExchangeRepository, IAuthHelper authHelper)
        {
            _personsMoneyExchangeRepository = PersonsMoneyExchangeRepository;
            _authHelper = authHelper;
        }
        public OperationResult Active(long id)
        {
            var operation = new OperationResult();
            var result = _personsMoneyExchangeRepository.Get(id);
            result.Active();
            _personsMoneyExchangeRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Create(PersonsMoneyExchangeCreate command)
        {
            var operation = new OperationResult();

            var userid = _authHelper.CurrentUserId();
            var agenciesId = _authHelper.CurrentAgenciesId();
            if (agenciesId == 0)
            {
                agenciesId = command.AgenciesId;
            }

            var result = new PersonsMoneyExchange(command.Date, command.MoneyId_One, command.Amount_One, command.Price,
                command.Type, command.MoneyId_Two, command.Amount_Two, command.PersonsId, userid, agenciesId);
            _personsMoneyExchangeRepository.Create(result);
            _personsMoneyExchangeRepository.SaveChanges();
            operation.Id = result.Id;
            return operation.Succedded();
        }
        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            var result = _personsMoneyExchangeRepository.Get(id);
            _personsMoneyExchangeRepository.Delete(result);
            _personsMoneyExchangeRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Edit(PersonsMoneyExchangeEdit command)
        {
            var operation = new OperationResult();
            var result = _personsMoneyExchangeRepository.Get(command.Id);
            if (result == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            var userid = _authHelper.CurrentUserId();
            var agenciesId = _authHelper.CurrentAgenciesId();
            if (agenciesId == 0)
            {
                agenciesId = command.AgenciesId;
            }

            result.Edit(command.Date, command.MoneyId_One, command.Amount_One, command.Price,
                command.Type, command.MoneyId_Two, command.Amount_Two, command.PersonsId, userid, agenciesId);
            _personsMoneyExchangeRepository.SaveChanges();
            operation.Id = result.Id;
            return operation.Succedded();
        }
        public PersonsMoneyExchangeEdit GetDetails(long id)
        {
            return _personsMoneyExchangeRepository.GetDetails(id);
        }
        public List<PersonsMoneyExchangeViewModel> GetInActive()
        {
            return _personsMoneyExchangeRepository.GetInActive();
        }
        public List<PersonsMoneyExchangeViewModel> GetInActive(int agenciesId)
        {
            return _personsMoneyExchangeRepository.GetInActive(agenciesId);
        }
        public List<PersonsMoneyExchangeViewModel> GetRemove()
        {
            return _personsMoneyExchangeRepository.GetRemove();
        }
        public List<PersonsMoneyExchangeViewModel> GetRemove(int agenciesId)
        {
            return _personsMoneyExchangeRepository.GetRemove(agenciesId);
        }
        public List<PersonsMoneyExchangeViewModel> GetViewModel()
        {
            return _personsMoneyExchangeRepository.GetViewModel();
        }
        public List<PersonsMoneyExchangeViewModel> GetViewModel(int agenciesId)
        {
            return _personsMoneyExchangeRepository.GetViewModel(agenciesId);
        }
        public OperationResult InActive(long id)
        {
            var operation = new OperationResult();
            var result = _personsMoneyExchangeRepository.Get(id);
            result.InActive();
            _personsMoneyExchangeRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var result = _personsMoneyExchangeRepository.Get(id);
            result.Remove();
            _personsMoneyExchangeRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Reset(long id)
        {
            var operation = new OperationResult();
            var result = _personsMoneyExchangeRepository.Get(id);
            result.Reset();
            _personsMoneyExchangeRepository.SaveChanges();
            return operation.Succedded();
        }
    }
}