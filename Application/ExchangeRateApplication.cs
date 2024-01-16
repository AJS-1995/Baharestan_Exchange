using _0_Framework.Application.Auth;
using _0_Framework.Application;
using Contracts.ExchangeRateContracts;
using Domin.ExchangeRateDomin;
using Domin.AgenciesDomin;

namespace Application
{
    public class ExchangeRateApplication : IExchangeRateApplication
    {
        private readonly IExchangeRateRepository _exchangeRateRepository;
        private readonly IAuthHelper _authHelper;
        public ExchangeRateApplication(IExchangeRateRepository exchangeRateRepository, IAuthHelper authHelper)
        {
            _exchangeRateRepository = exchangeRateRepository;
            _authHelper = authHelper;
        }
        public OperationResult Active(long id)
        {
            var operation = new OperationResult();
            var result = _exchangeRateRepository.Get(id);
            result.Active();
            _exchangeRateRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Create(ExchangeRateCreate command)
        {
            var operation = new OperationResult();

            var userid = _authHelper.CurrentUserId();
            var agenciesId = _authHelper.CurrentAgenciesId();
            if (agenciesId == 0)
            {
                agenciesId = command.AgenciesId;
            }

            var result = new ExchangeRate(command.Amount, command.MainMoneyId, command.PriceBey, command.PriceSell, command.SecondaryMoneyId, command.DateDay, userid, agenciesId);
            _exchangeRateRepository.Create(result);
            _exchangeRateRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            var result = _exchangeRateRepository.Get(id);
            _exchangeRateRepository.Delete(result);
            _exchangeRateRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Edit(ExchangeRateEdit command)
        {
            var operation = new OperationResult();
            var result = _exchangeRateRepository.Get(command.Id);
            if (result == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            var userid = _authHelper.CurrentUserId();
            var agenciesId = _authHelper.CurrentAgenciesId();
            if (agenciesId == 0)
            {
                agenciesId = command.AgenciesId;
            }

            result.Edit(command.Amount, command.MainMoneyId, command.PriceBey, command.PriceSell, command.SecondaryMoneyId, command.DateDay, userid, agenciesId);
            _exchangeRateRepository.SaveChanges();
            return operation.Succedded();
        }
        public ExchangeRateEdit GetDetails(long id)
        {
            return _exchangeRateRepository.GetDetails(id);
        }
        public List<ExchangeRateViewModel> GetInActive()
        {
            return _exchangeRateRepository.GetInActive();
        }
        public List<ExchangeRateViewModel> GetInActive(int agenciesId)
        {
            return _exchangeRateRepository.GetInActive(agenciesId);
        }
        public List<ExchangeRateViewModel> GetRemove()
        {
            return _exchangeRateRepository.GetRemove();
        }
        public List<ExchangeRateViewModel> GetRemove(int agenciesId)
        {
            return _exchangeRateRepository.GetRemove(agenciesId);
        }
        public List<ExchangeRateViewModel> GetViewModel()
        {
            return _exchangeRateRepository.GetViewModel();
        }
        public List<ExchangeRateViewModel> GetViewModel(int agenciesId)
        {
            return _exchangeRateRepository.GetViewModel(agenciesId);
        }
        public OperationResult InActive(long id)
        {
            var operation = new OperationResult();
            var result = _exchangeRateRepository.Get(id);
            result.InActive();
            _exchangeRateRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var result = _exchangeRateRepository.Get(id);
            result.Remove();
            _exchangeRateRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Reset(long id)
        {
            var operation = new OperationResult();
            var result = _exchangeRateRepository.Get(id);
            result.Reset();
            _exchangeRateRepository.SaveChanges();
            return operation.Succedded();
        }
    }
}