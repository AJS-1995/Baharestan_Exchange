using _0_Framework.Application;
using _0_Framework.Application.Auth;
using Contracts.UsersContracts.RoleContracts;
using Domin.UsersDomin;

namespace Application.UsersApplication
{
    public class RoleApplication : IRoleApplication
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IAuthHelper _authHelper;
        public RoleApplication(IRoleRepository roleRepository, IAuthHelper authHelper)
        {
            _roleRepository = roleRepository;
            _authHelper = authHelper;
        }
        public OperationResult Create(RoleCreate command)
        {
            var operation = new OperationResult();
            var role = _roleRepository.GetViewModel();
            if (role.Count == 0)
            {
                var Admin = new Role("Admin", "مدیر سیستم", 1);
                _roleRepository.Create(Admin);
                _roleRepository.SaveChanges();

                var Accountant = new Role("Accountant", "حسابدار", 1);
                _roleRepository.Create(Accountant);
                _roleRepository.SaveChanges();

                var Viewer = new Role("Viewer", "بیننده", 1);
                _roleRepository.Create(Viewer);
                _roleRepository.SaveChanges();
            }
            else
            {
                if (_roleRepository.Exists(x => x.Name == command.Name))
                    return operation.Failed(ApplicationMessages.DuplicatedRecord);

                var user_id = _authHelper.CurrentUserId();
                var roles = new Role(command.Name, command.NamePersian, user_id);
                _roleRepository.Create(roles);
                _roleRepository.SaveChanges();
            }
            return operation.Succedded();
        }
        public OperationResult Edit(RoleEdit command)
        {
            var operation = new OperationResult();
            var role = _roleRepository.Get(command.Id);
            if (role == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_roleRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var user_id = _authHelper.CurrentUserId();
            role.Edit(command.Name, command.NamePersian, user_id);
            _roleRepository.SaveChanges();
            return operation.Succedded();
        }
        public RoleEdit GetDetails(int id)
        {
            return _roleRepository.GetDetails(id);
        }
        public List<RoleViewModel> GetViewModel()
        {
            return _roleRepository.GetViewModel();
        }
        public OperationResult InActive(int id)
        {
            var operation = new OperationResult();
            var result = _roleRepository.Get(id);
            result.InActive();
            _roleRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Active(int id)
        {
            var operation = new OperationResult();
            var result = _roleRepository.Get(id);
            result.Active();
            _roleRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Remove(int id)
        {
            var operation = new OperationResult();
            var result = _roleRepository.Get(id);
            result.Remove();
            _roleRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Reset(int id)
        {
            var operation = new OperationResult();
            var result = _roleRepository.Get(id);
            result.Reset();
            _roleRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Delete(int id)
        {
            var operation = new OperationResult();
            var result = _roleRepository.Get(id);
            _roleRepository.Delete(result);
            _roleRepository.SaveChanges();
            return operation.Succedded();
        }
    }
}