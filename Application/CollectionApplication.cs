using _0_Framework.Application.Auth;
using _0_Framework.Application;
using Contracts.ExpenseContracts;
using Domin.ExpenseDomin;
using _0_Framework.Application.PersonsAuth;

namespace Application
{
    public class CollectionApplication : ICollectionApplication
    {
        private readonly ICollectionRepository _collectionRepository;
        private readonly IAuthHelper _authHelper;
        public CollectionApplication(ICollectionRepository collectionRepository, IAuthHelper authHelper)
        {
            _collectionRepository = collectionRepository;
            _authHelper = authHelper;
        }
        public OperationResult Active(int id)
        {
            var operation = new OperationResult();
            var result = _collectionRepository.Get(id);
            result.Active();
            _collectionRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Create(CollectionCreate command)
        {
            var operation = new OperationResult();
            if (_collectionRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var userid = _authHelper.CurrentUserId();
            var agenciesId = _authHelper.CurrentAgenciesId();

            var result = new Collection(command.Name, command.Description, userid, agenciesId);
            _collectionRepository.Create(result);
            _collectionRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Delete(int id)
        {
            var operation = new OperationResult();
            var result = _collectionRepository.Get(id);
            _collectionRepository.Delete(result);
            _collectionRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Edit(CollectionEdit command)
        {
            var operation = new OperationResult();
            var result = _collectionRepository.Get(command.Id);
            if (result == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_collectionRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var userid = _authHelper.CurrentUserId();
            var agenciesId = _authHelper.CurrentAgenciesId();

            result.Edit(command.Name, command.Description, userid, agenciesId);
            _collectionRepository.SaveChanges();
            return operation.Succedded();
        }
        public CollectionEdit GetDetails(int id)
        {
            return _collectionRepository.GetDetails(id);
        }
        public List<CollectionViewModel> GetInActive()
        {
            return _collectionRepository.GetInActive();
        }
        public List<CollectionViewModel> GetRemove()
        {
            return _collectionRepository.GetRemove();
        }
        public List<CollectionViewModel> GetViewModel()
        {
            return _collectionRepository.GetViewModel();
        }
        public OperationResult InActive(int id)
        {
            var operation = new OperationResult();
            var result = _collectionRepository.Get(id);
            result.InActive();
            _collectionRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Remove(int id)
        {
            var operation = new OperationResult();
            var result = _collectionRepository.Get(id);
            result.Remove();
            _collectionRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Reset(int id)
        {
            var operation = new OperationResult();
            var result = _collectionRepository.Get(id);
            result.Reset();
            _collectionRepository.SaveChanges();
            return operation.Succedded();
        }
    }
}