using _0_Framework.Application.Auth;
using _0_Framework.Application;
using Domin.ManagementPresonsDomin.LivelihoodDomin;
using Contracts.ManagementPresonsContracts.LivelihoodContracts;

namespace Application.ManagementPresonsApplication
{
    public class LivelihoodApplication : ILivelihoodApplication
    {
        private readonly ILivelihoodRepository _LivelihoodRepository;
        private readonly IAuthHelper _authHelper;
        public LivelihoodApplication(ILivelihoodRepository LivelihoodRepository, IAuthHelper authHelper)
        {
            _LivelihoodRepository = LivelihoodRepository;
            _authHelper = authHelper;
        }
        public OperationResult Active(int id)
        {
            var operation = new OperationResult();
            var result = _LivelihoodRepository.Get(id);
            result.Active();
            _LivelihoodRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Create(LivelihoodCreate command)
        {
            var operation = new OperationResult();

            var userid = _authHelper.CurrentUserId();
            var agenciesId = _authHelper.CurrentAgenciesId();
            if (agenciesId == 0)
            {
                agenciesId = command.AgenciesId;
            }

            var livelihood = _LivelihoodRepository.GetViewModel().Where(x => x.PersonsId == command.PersonsId).ToList();
            if (livelihood.Count >= 0)
            {
                foreach (var item in livelihood)
                {
                    if(item.SDate != command.SDate)
                    {
                        var li = _LivelihoodRepository.Get(item.Id);
                        li.Edit(item.SDate, item.EDate, item.PersonsId, item.Amount, true, item.MoneyId, item.UserId, item.AgenciesId);
                        _LivelihoodRepository.SaveChanges();
                    }
                }
            }

            if (_LivelihoodRepository.Exists(x => x.SDate == command.SDate && x.Cancel == command.Cancel && x.PersonsId == command.PersonsId && x.AgenciesId == command.AgenciesId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var result = new Livelihood(command.SDate, command.EDate, command.PersonsId, command.Amount, command.Cancel, command.MoneyId, userid, agenciesId);
            _LivelihoodRepository.Create(result);
            _LivelihoodRepository.SaveChanges();
            operation.Id = result.Id;
            return operation.Succedded();
        }
        public OperationResult Delete(int id)
        {
            var operation = new OperationResult();
            var result = _LivelihoodRepository.Get(id);
            _LivelihoodRepository.Delete(result);
            _LivelihoodRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Edit(LivelihoodEdit command)
        {
            var operation = new OperationResult();
            var result = _LivelihoodRepository.Get(command.Id);
            if (result == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            var userid = _authHelper.CurrentUserId();
            var agenciesId = _authHelper.CurrentAgenciesId();
            if (agenciesId == 0)
            {
                agenciesId = command.AgenciesId;
            }

            if (_LivelihoodRepository.Exists(x => x.SDate == command.SDate && x.Cancel == command.Cancel && x.PersonsId == command.PersonsId && x.AgenciesId == command.AgenciesId && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            result.Edit(command.SDate, command.EDate, command.PersonsId, command.Amount, command.Cancel, command.MoneyId, userid, agenciesId);
            _LivelihoodRepository.SaveChanges();
            operation.Id = result.Id;
            return operation.Succedded();
        }
        public LivelihoodEdit GetDetails(int id)
        {
            return _LivelihoodRepository.GetDetails(id);
        }
        public List<LivelihoodViewModel> GetInActive()
        {
            return _LivelihoodRepository.GetInActive();
        }
        public List<LivelihoodViewModel> GetInActive(int agenciesId)
        {
            return _LivelihoodRepository.GetInActive(agenciesId);
        }
        public List<LivelihoodViewModel> GetRemove()
        {
            return _LivelihoodRepository.GetRemove();
        }
        public List<LivelihoodViewModel> GetRemove(int agenciesId)
        {
            return _LivelihoodRepository.GetRemove(agenciesId);
        }
        public List<LivelihoodViewModel> GetViewModel()
        {
            return _LivelihoodRepository.GetViewModel();
        }
        public List<LivelihoodViewModel> GetViewModel(int agenciesId)
        {
            return _LivelihoodRepository.GetViewModel(agenciesId);
        }
        public OperationResult InActive(int id)
        {
            var operation = new OperationResult();
            var result = _LivelihoodRepository.Get(id);
            result.InActive();
            _LivelihoodRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Remove(int id)
        {
            var operation = new OperationResult();
            var result = _LivelihoodRepository.Get(id);
            result.Remove();
            _LivelihoodRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Reset(int id)
        {
            var operation = new OperationResult();
            var result = _LivelihoodRepository.Get(id);
            result.Reset();
            _LivelihoodRepository.SaveChanges();
            return operation.Succedded();
        }
    }
}