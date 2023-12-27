using _0_Framework.Application.Auth;
using _0_Framework.Application;
using Contracts.ExchangeRateContracts;
using Domin.ExchangeRateDomin;

namespace Application
{
    public class ExchangeRateApplication : IExchangeRateApplication
    {
        private readonly IExchangeRateRepository _exchangeRateRepository;
        private readonly IAuthHelper _authHelper;
        private readonly IFileUploader _fileUploader;
        public ExchangeRateApplication(IExchangeRateRepository exchangeRateRepository, IAuthHelper authHelper, IFileUploader fileUploader)
        {
            _exchangeRateRepository = exchangeRateRepository;
            _authHelper = authHelper;
            _fileUploader = fileUploader;
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

            if (_exchangeRateRepository.Exists(x => x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var userid = _authHelper.CurrentUserId();
            var agenciesId = _authHelper.CurrentAgenciesId();

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
        public List<ExchangeRateViewModel> GetRemove()
        {
            return _exchangeRateRepository.GetRemove();
        }
        public List<ExchangeRateViewModel> GetViewModel()
        {
            return _exchangeRateRepository.GetViewModel();
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