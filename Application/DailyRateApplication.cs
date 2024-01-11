﻿using _0_Framework.Application.Auth;
using _0_Framework.Application;
using Contracts.DailyRateContracts;
using Domin.DailyRateDomin;
using Domin.CompanyDomin;

namespace Application
{
    public class DailyRateApplication : IDailyRateApplication
    {
        private readonly IDailyRateRepository _dailyRateRepository;
        private readonly IAuthHelper _authHelper;
        public DailyRateApplication(IDailyRateRepository DailyRateRepository, IAuthHelper authHelper)
        {
            _dailyRateRepository = DailyRateRepository;
            _authHelper = authHelper;
        }
        public OperationResult Active(int id)
        {
            var operation = new OperationResult();
            var result = _dailyRateRepository.Get(id);
            result.Active();
            _dailyRateRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Create(DailyRateCreate command)
        {
            var operation = new OperationResult();

            if (_dailyRateRepository.Exists(x => x.MainMoneyId == command.MainMoneyId && x.SecondaryMoneyId == command.SecondaryMoneyId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var userid = _authHelper.CurrentUserId();
            var agenciesId = _authHelper.CurrentAgenciesId();

            var result = new DailyRate(command.Amount, command.MainMoneyId, command.PriceBey, command.PriceSell, command.SecondaryMoneyId, command.DateDay, userid, agenciesId);
            _dailyRateRepository.Create(result);
            _dailyRateRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Delete(int id)
        {
            var operation = new OperationResult();
            var result = _dailyRateRepository.Get(id);
            _dailyRateRepository.Delete(result);
            _dailyRateRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Edit(DailyRateEdit command)
        {
            var operation = new OperationResult();
            var result = _dailyRateRepository.Get(command.Id);
            if (result == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_dailyRateRepository.Exists(x => x.MainMoneyId == command.MainMoneyId && x.SecondaryMoneyId == command.SecondaryMoneyId && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var userid = _authHelper.CurrentUserId();
            var agenciesId = _authHelper.CurrentAgenciesId();

            result.Edit(command.Amount, command.MainMoneyId, command.PriceBey, command.PriceSell, command.SecondaryMoneyId, command.DateDay, userid, agenciesId);
            _dailyRateRepository.SaveChanges();
            return operation.Succedded();
        }
        public DailyRateEdit GetDetails(int id)
        {
            return _dailyRateRepository.GetDetails(id);
        }
        public List<DailyRateViewModel> GetInActive()
        {
            return _dailyRateRepository.GetInActive();
        }
        public List<DailyRateViewModel> GetRemove()
        {
            return _dailyRateRepository.GetRemove();
        }
        public List<DailyRateViewModel> GetViewModel()
        {
            return _dailyRateRepository.GetViewModel();
        }
        public OperationResult InActive(int id)
        {
            var operation = new OperationResult();
            var result = _dailyRateRepository.Get(id);
            result.InActive();
            _dailyRateRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Remove(int id)
        {
            var operation = new OperationResult();
            var result = _dailyRateRepository.Get(id);
            result.Remove();
            _dailyRateRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Reset(int id)
        {
            var operation = new OperationResult();
            var result = _dailyRateRepository.Get(id);
            result.Reset();
            _dailyRateRepository.SaveChanges();
            return operation.Succedded();
        }
    }
}