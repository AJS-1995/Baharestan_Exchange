using _0_Framework.Application;
using _0_Framework.Application.Auth;
using _0_Framework.Application.Password;
using Contracts.UsersContracts.UsersContracts;
using Domin.UsersDomin;

namespace Application.UsersApplication
{
    public class UserApplication : IUserApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserRepository _userRepository;
        private readonly IAuthHelper _authHelper;
        private readonly IRoleRepository _roleRepository;
        public UserApplication(IUserRepository accountRepository, IPasswordHasher passwordHasher,
            IFileUploader fileUploader, IAuthHelper authHelper, IRoleRepository roleRepository)
        {
            _authHelper = authHelper;
            _roleRepository = roleRepository;
            _fileUploader = fileUploader;
            _passwordHasher = passwordHasher;
            _userRepository = accountRepository;
        }
        public OperationResult ChangePassword(UserChangePassword command)
        {
            var operation = new OperationResult();
            var user = _userRepository.Get(command.Id);
            if (user == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (command.Password != command.RePassword)
                return operation.Failed(ApplicationMessages.PasswordsNotMatch);

            if (command.SecurityCod != user.SecurityCod)
                return operation.Failed(ApplicationMessages.WrongSecurityCod);

            var password = _passwordHasher.Hash(command.Password);
            user.ChangePassword(password);
            _userRepository.SaveChanges();
            return operation.Succedded();
        }
        public UserViewModel GetUserBy(int id)
        {
            var account = _userRepository.Get(id);
            return new UserViewModel()
            {
                FullName = account.FullName,
                Mobile = account.Mobile
            };
        }
        public OperationResult Create(UserCreate command)
        {
            var operation = new OperationResult();
            var role = _roleRepository.GetViewModel();
            if (_userRepository.Exists(x => x.UserName == command.UserName || x.Mobile == command.Mobile))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var password = _passwordHasher.Hash(command.Password);
            var userid = _authHelper.CurrentUserId();
            var agenciesId = _authHelper.CurrentAgenciesId();
            if (agenciesId == 0)
            {
                agenciesId = command.AgenciesId;
            }

            string? slug = command.FullName.Slugify();

            var logoPath = "Users";
            var logoname = slug;
            var picturePath = _fileUploader.Upload(command.ProfilePhoto, logoPath, logoname);
            if (picturePath == "no")
                return operation.Failed(ApplicationMessages.PhotoFormat);

            var permissions = new List<Permission>();
            if (_userRepository.Get().Count != 0)
            {
                permissions = new List<Permission>();
            }
            else
            {
                command.Permissions.ForEach(code => permissions.Add(new Permission(code)));
            }
            var account = new User(command.FullName, command.UserName, password, command.Mobile, command.SecurityCod, command.RoleId, picturePath, permissions, userid, agenciesId);
            _userRepository.Create(account);
            _userRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Edit(UserEdit command)
        {
            var operation = new OperationResult();
            var account = _userRepository.Get(command.Id);
            if (account == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_userRepository.Exists(x =>
                (x.UserName == command.UserName || x.Mobile == command.Mobile) && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            if (command.ProfilePhoto != null || account.ProfilePhoto != "")
            {
                string? path = account.ProfilePhoto;
                _fileUploader.Delete(path);
            }

            string? slug = command.FullName.Slugify();

            var logoPath = "Users";
            var logoname = slug;
            var picturePath = _fileUploader.Upload(command.ProfilePhoto, logoPath, logoname);
            if (picturePath == "no")
                return operation.Failed(ApplicationMessages.PhotoFormat);

            var userid = _authHelper.CurrentUserId();
            var agenciesId = _authHelper.CurrentAgenciesId();
            if (agenciesId == 0)
            {
                agenciesId = command.AgenciesId;
            }

            account.Edit(command.FullName, command.UserName, command.Mobile, command.RoleId, picturePath, userid, agenciesId);
            _userRepository.SaveChanges();
            return operation.Succedded();
        }
        public UserEdit GetDetails(int id)
        {
            return _userRepository.GetDetails(id);
        }
        public OperationResult Login(UserLogin command)
        {
            var operation = new OperationResult();
            var user = _userRepository.GetBy(command.UserName);
            if (user == null)
                return operation.Failed(ApplicationMessages.WrongUserPass);

            var result = _passwordHasher.Check(user.Password, command.Password);
            if (!result.Verified)
                return operation.Failed(ApplicationMessages.WrongUserPass);

            if (user.Status != true || user.Deleted != false)
                return operation.Failed(ApplicationMessages.AccessNot);

            var permissions = _userRepository.Get(user.Id)
                .Permissions
                .Select(x => x.Code)
                .ToList();

            int cod = _roleRepository.Get(user.RoleId).Cod;

            var authViewModel = new AuthViewModel(user.Id, cod, user.FullName, user.UserName, user.Mobile, user.AgenciesId, permissions);

            _authHelper.Signin(authViewModel);
            return operation.Succedded();
        }
        public OperationResult Logout()
        {
            var operation = new OperationResult();
            _authHelper.SignOut();
            return operation.Succedded();
        }
        public List<UserViewModel> GetViewModel()
        {
            return _userRepository.GetViewModel();
        }
        public OperationResult Delete(int id)
        {
            var operation = new OperationResult();
            var result = _userRepository.Get(id);
            if (result.ProfilePhoto != null || result.ProfilePhoto != "")
            {
                string? path = result.ProfilePhoto;
                _fileUploader.Delete(path);
            }
            _userRepository.Delete(result);
            _userRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Edit(UserPermissionsCreate command)
        {
            var operation = new OperationResult();
            var user = _userRepository.Get(command.Id);
            if (user == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            var permissions = new List<Permission>();
            command.Permissions.ForEach(code => permissions.Add(new Permission(code)));

            user.Edit(permissions, command.Id);
            _userRepository.SaveChanges();
            return operation.Succedded();
        }
        public UserPermissionsCreate GetDetailsPer(int id)
        {
            return _userRepository.GetDetailsPer(id);
        }
        public OperationResult InActive(int id)
        {
            var operation = new OperationResult();
            var result = _userRepository.Get(id);
            result.InActive();
            _userRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Active(int id)
        {
            var operation = new OperationResult();
            var result = _userRepository.Get(id);
            result.Active();
            _userRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Remove(int id)
        {
            var operation = new OperationResult();
            var result = _userRepository.Get(id);
            result.Remove();
            _userRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Reset(int id)
        {
            var operation = new OperationResult();
            var result = _userRepository.Get(id);
            result.Reset();
            _userRepository.SaveChanges();
            return operation.Succedded();
        }
        public List<UserViewModel> GetInActive()
        {
            return _userRepository.GetInActive();
        }

        public List<UserViewModel> GetRemove()
        {
            return _userRepository.GetRemove();
        }
    }
}