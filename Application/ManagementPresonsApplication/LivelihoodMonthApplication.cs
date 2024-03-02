using _0_Framework.Application.Auth;
using _0_Framework.Application;
using Domin.ManagementPresonsDomin.LivelihoodMonthDomin;
using Contracts.ManagementPresonsContracts.LivelihoodMonthContracts;

namespace Application.ManagementPresonsApplication
{
    public class LivelihoodMonthApplication : ILivelihoodMonthApplication
    {
        private readonly ILivelihoodMonthRepository _livelihoodMonthRepository;
        private readonly IAuthHelper _authHelper;
        public LivelihoodMonthApplication(ILivelihoodMonthRepository LivelihoodMonthRepository, IAuthHelper authHelper)
        {
            _livelihoodMonthRepository = LivelihoodMonthRepository;
            _authHelper = authHelper;
        }
        public OperationResult Active(long id)
        {
            var operation = new OperationResult();
            var result = _livelihoodMonthRepository.Get(id);
            result.Active();
            _livelihoodMonthRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Create(LivelihoodMonthCreate command)
        {
            var operation = new OperationResult();

            var userid = _authHelper.CurrentUserId();
            var agenciesId = _authHelper.CurrentAgenciesId();
            if (agenciesId == 0)
            {
                agenciesId = command.AgenciesId;
            }

            if (_livelihoodMonthRepository.Exists(x => x.Year == command.Year && x.Month == command.Month && x.PersonsId == command.PersonsId && x.AgenciesId == command.AgenciesId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var result = new LivelihoodMonth(command.Year, command.Month, command.LivelihoodId, command.PersonsId, command.Amount, command.MoneyId, userid, agenciesId);
            _livelihoodMonthRepository.Create(result);
            _livelihoodMonthRepository.SaveChanges();
            operation.Id = result.Id;
            return operation.Succedded();
        }
        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            var result = _livelihoodMonthRepository.Get(id);
            _livelihoodMonthRepository.Delete(result);
            _livelihoodMonthRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Edit(LivelihoodMonthEdit command)
        {
            var operation = new OperationResult();
            var result = _livelihoodMonthRepository.Get(command.Id);
            if (result == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            var userid = _authHelper.CurrentUserId();
            var agenciesId = _authHelper.CurrentAgenciesId();
            if (agenciesId == 0)
            {
                agenciesId = command.AgenciesId;
            }

            if (_livelihoodMonthRepository.Exists(x => x.Year == command.Year && x.Month == command.Month && x.PersonsId == command.PersonsId && x.AgenciesId == command.AgenciesId && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            result.Edit(command.Year, command.Month, command.LivelihoodId, command.PersonsId, command.Amount, command.MoneyId, userid, agenciesId);
            _livelihoodMonthRepository.SaveChanges();
            operation.Id = result.Id;
            return operation.Succedded();
        }
        public LivelihoodMonthEdit GetDetails(long id)
        {
            return _livelihoodMonthRepository.GetDetails(id);
        }
        public List<LivelihoodMonthViewModel> GetInActive()
        {
            return _livelihoodMonthRepository.GetInActive();
        }
        public List<LivelihoodMonthViewModel> GetInActive(int agenciesId)
        {
            return _livelihoodMonthRepository.GetInActive(agenciesId);
        }
        public List<LivelihoodMonthViewModel> GetRemove()
        {
            return _livelihoodMonthRepository.GetRemove();
        }
        public List<LivelihoodMonthViewModel> GetRemove(int agenciesId)
        {
            return _livelihoodMonthRepository.GetRemove(agenciesId);
        }
        public List<LivelihoodMonthViewModel> GetViewModel()
        {
            return _livelihoodMonthRepository.GetViewModel();
        }
        public List<LivelihoodMonthViewModel> GetViewModel(int agenciesId)
        {
            return _livelihoodMonthRepository.GetViewModel(agenciesId);
        }
        public OperationResult InActive(long id)
        {
            var operation = new OperationResult();
            var result = _livelihoodMonthRepository.Get(id);
            result.InActive();
            _livelihoodMonthRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var result = _livelihoodMonthRepository.Get(id);
            result.Remove();
            _livelihoodMonthRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Reset(long id)
        {
            var operation = new OperationResult();
            var result = _livelihoodMonthRepository.Get(id);
            result.Reset();
            _livelihoodMonthRepository.SaveChanges();
            return operation.Succedded();
        }
    }
}