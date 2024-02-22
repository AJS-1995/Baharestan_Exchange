using _0_Framework.Application.Auth;
using _0_Framework.Application;
using Contracts.AgenciesContracts;
using Domin.AgenciesDomin;
using _0_Framework.Application.PersonsAuth;

namespace Application
{
    public class AgenciesApplication : IAgenciesApplication
    {
        private readonly IAgenciesRepository _AgenciesRepository;
        private readonly IAuthHelper _authHelper;
        public AgenciesApplication(IAgenciesRepository AgenciesRepository, IAuthHelper authHelper)
        {
            _AgenciesRepository = AgenciesRepository;
            _authHelper = authHelper;
        }
        public OperationResult Active(int id)
        {
            var operation = new OperationResult();
            var result = _AgenciesRepository.Get(id);
            result.Active();
            _AgenciesRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Create(AgenciesCreate command)
        {
            var operation = new OperationResult();
            if (_AgenciesRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var userid = _authHelper.CurrentUserId();

            var result = new Agencies(command.Name, command.Address, command.Mobile, command.Responsible, command.CompanyId, userid);
            _AgenciesRepository.Create(result);
            _AgenciesRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Delete(int id)
        {
            var operation = new OperationResult();
            var result = _AgenciesRepository.Get(id);
            _AgenciesRepository.Delete(result);
            _AgenciesRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Edit(AgenciesEdit command)
        {
            var operation = new OperationResult();
            var result = _AgenciesRepository.Get(command.Id);
            if (result == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_AgenciesRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var userid = _authHelper.CurrentUserId();

            result.Edit(command.Name, command.Address, command.Mobile, command.Responsible, command.CompanyId, userid);
            _AgenciesRepository.SaveChanges();
            return operation.Succedded();
        }
        public AgenciesEdit GetDetails(int id)
        {
            return _AgenciesRepository.GetDetails(id);
        }
        public List<AgenciesViewModel> GetInActive()
        {
            return _AgenciesRepository.GetInActive();
        }
        public List<AgenciesViewModel> GetRemove()
        {
            return _AgenciesRepository.GetRemove();
        }
        public List<AgenciesViewModel> GetViewModel()
        {
            return _AgenciesRepository.GetViewModel();
        }
        public OperationResult InActive(int id)
        {
            var operation = new OperationResult();
            var result = _AgenciesRepository.Get(id);
            result.InActive();
            _AgenciesRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Remove(int id)
        {
            var operation = new OperationResult();
            var result = _AgenciesRepository.Get(id);
            result.Remove();
            _AgenciesRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Reset(int id)
        {
            var operation = new OperationResult();
            var result = _AgenciesRepository.Get(id);
            result.Reset();
            _AgenciesRepository.SaveChanges();
            return operation.Succedded();
        }
    }
}