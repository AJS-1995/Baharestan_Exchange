﻿using _0_Framework.Application.Auth;
using _0_Framework.Application;
using Contracts.SafeBoxContracts;
using Domin.SafeBoxDomin;

namespace Application
{
    public class SafeBoxApplication : ISafeBoxApplication
    {
        private readonly ISafeBoxRepository _SafeBoxRepository;
        private readonly IAuthHelper _authHelper;
        public SafeBoxApplication(ISafeBoxRepository safeBoxRepository, IAuthHelper authHelper)
        {
            _SafeBoxRepository = safeBoxRepository;
            _authHelper = authHelper;
        }
        public OperationResult Active(int id)
        {
            var operation = new OperationResult();
            var result = _SafeBoxRepository.Get(id);
            result.Active();
            _SafeBoxRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Create(SafeBoxCreate command)
        {
            var operation = new OperationResult();
            if (_SafeBoxRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var userid = _authHelper.CurrentUserId();
            var agenciesId = _authHelper.CurrentAgenciesId();

            var result = new SafeBox(command.Name, command.Treasurer, command.Mobile, userid, agenciesId);
            _SafeBoxRepository.Create(result);
            _SafeBoxRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Delete(int id)
        {
            var operation = new OperationResult();
            var result = _SafeBoxRepository.Get(id);
            _SafeBoxRepository.Delete(result);
            _SafeBoxRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Edit(SafeBoxEdit command)
        {
            var operation = new OperationResult();
            var result = _SafeBoxRepository.Get(command.Id);
            if (result == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_SafeBoxRepository.Exists(x => (x.Name == command.Name) && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var userid = _authHelper.CurrentUserId();
            var agenciesId = _authHelper.CurrentAgenciesId();

            result.Edit(command.Name, command.Treasurer, command.Mobile, userid, agenciesId);
            _SafeBoxRepository.SaveChanges();
            return operation.Succedded();
        }
        public SafeBoxEdit GetDetails(int id)
        {
            return _SafeBoxRepository.GetDetails(id);
        }
        public List<SafeBoxViewModel> GetInActive()
        {
            return _SafeBoxRepository.GetInActive();
        }
        public List<SafeBoxViewModel> GetRemove()
        {
            return _SafeBoxRepository.GetRemove();
        }
        public List<SafeBoxViewModel> GetViewModel()
        {
            return _SafeBoxRepository.GetViewModel();
        }
        public OperationResult InActive(int id)
        {
            var operation = new OperationResult();
            var result = _SafeBoxRepository.Get(id);
            result.InActive();
            _SafeBoxRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Remove(int id)
        {
            var operation = new OperationResult();
            var result = _SafeBoxRepository.Get(id);
            result.Remove();
            _SafeBoxRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Reset(int id)
        {
            var operation = new OperationResult();
            var result = _SafeBoxRepository.Get(id);
            result.Reset();
            _SafeBoxRepository.SaveChanges();
            return operation.Succedded();
        }
    }

}