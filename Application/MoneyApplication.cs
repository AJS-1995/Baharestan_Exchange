using _0_Framework.Application.Auth;
using _0_Framework.Application;
using Contracts.MoneyContracts;
using Domin.MoneyDomin;
using Contracts.ExchangeRateContracts;
using _0_Framework.Application.PersonsAuth;

namespace Application
{
    public class MoneyApplication : IMoneyApplication
    {
        private readonly IMoneyRepository _moneyRepository;
        private readonly IAuthHelper _authHelper;
        public MoneyApplication(IMoneyRepository moneyRepository, IAuthHelper authHelper)
        {
            _moneyRepository = moneyRepository;
            _authHelper = authHelper;
        }
        public OperationResult Active(int id)
        {
            var operation = new OperationResult();
            var result = _moneyRepository.Get(id);
            result.Active();
            _moneyRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Create(MoneyCreate command)
        {
            var operation = new OperationResult();
            if (_moneyRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var userid = _authHelper.CurrentUserId();
            var agenciesId = _authHelper.CurrentAgenciesId();

            var result = new Money(command.Name, command.Country, command.Symbol, userid, agenciesId);
            _moneyRepository.Create(result);
            _moneyRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Delete(int id)
        {
            var operation = new OperationResult();
            var result = _moneyRepository.Get(id);
            _moneyRepository.Delete(result);
            _moneyRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Edit(MoneyEdit command)
        {
            var operation = new OperationResult();
            var result = _moneyRepository.Get(command.Id);
            if (result == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_moneyRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var userid = _authHelper.CurrentUserId();
            var agenciesId = _authHelper.CurrentAgenciesId();

            result.Edit(command.Name, command.Country, command.Symbol, userid, agenciesId);
            _moneyRepository.SaveChanges();
            return operation.Succedded();
        }
        public MoneyEdit GetDetails(int id)
        {
            return _moneyRepository.GetDetails(id);
        }
        public List<MoneyViewModel> GetInActive()
        {
            return _moneyRepository.GetInActive();
        }
        public List<MoneyViewModel> GetRemove()
        {
            return _moneyRepository.GetRemove();
        }
        public List<MoneyViewModel> GetViewModel()
        {
            return _moneyRepository.GetViewModel();
        }
        public OperationResult InActive(int id)
        {
            var operation = new OperationResult();
            var result = _moneyRepository.Get(id);
            result.InActive();
            _moneyRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Remove(int id)
        {
            var operation = new OperationResult();
            var result = _moneyRepository.Get(id);
            result.Remove();
            _moneyRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Reset(int id)
        {
            var operation = new OperationResult();
            var result = _moneyRepository.Get(id);
            result.Reset();
            _moneyRepository.SaveChanges();
            return operation.Succedded();
        }
    }
}