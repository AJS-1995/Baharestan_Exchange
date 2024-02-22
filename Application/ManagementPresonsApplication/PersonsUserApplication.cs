using _0_Framework.Application;
using _0_Framework.Application.Auth;
using _0_Framework.Application.Password;
using _0_Framework.Application.PersonsAuth;
using Contracts.ManagementPresonsContracts.PersonsUsers;
using Domin.ManagementPresonsDomin.PersonsUsers;
using Domin.PersonsUsersDomin;
using Domin.UsersDomin;

namespace Application.ManagementPresonsApplication
{
    public class PersonsUserApplication : IPersonsUserApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IPersonsUserRepository _PersonsUserRepository;
        private readonly IPersonsAuthHelper _authHelper;
        public PersonsUserApplication(IPersonsUserRepository accountRepository, IPasswordHasher passwordHasher,
            IFileUploader fileUploader, IPersonsAuthHelper authHelper)
        {
            _authHelper = authHelper;
            _fileUploader = fileUploader;
            _passwordHasher = passwordHasher;
            _PersonsUserRepository = accountRepository;
        }
        public OperationResult ChangePassword(PersonsUserChangePassword command)
        {
            var operation = new OperationResult();
            var PersonsUser = _PersonsUserRepository.Get(command.Id);
            if (PersonsUser == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (command.Password != command.RePassword)
                return operation.Failed(ApplicationMessages.PasswordsNotMatch);

            var password = _passwordHasher.Hash(command.Password);
            PersonsUser.ChangePassword(password);
            _PersonsUserRepository.SaveChanges();
            return operation.Succedded();
        }
        public PersonsUserViewModel GetPersonsUserBy(int id)
        {
            var account = _PersonsUserRepository.Get(id);
            return new PersonsUserViewModel()
            {
                UserName = account.UserName,
                PersonsName = account.Persons?.Name
            };
        }
        public OperationResult Create(PersonsUserCreate command)
        {
            var operation = new OperationResult();
            if (_PersonsUserRepository.Exists(x => x.UserName == command.UserName || x.PersonsId == command.PersonsId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var password = _passwordHasher.Hash(command.Password);
            var userid = _authHelper.CurrentUserId();
            var agenciesId = _authHelper.CurrentAgenciesId();
            if (agenciesId == 0)
            {
                agenciesId = command.AgenciesId;
            }

            string? slug = command.UserName?.Slugify();

            var logoPath = "PersonsUsers";
            var logoname = slug;
            var picturePath = _fileUploader.Upload(command.ProfilePhoto, logoPath, logoname);
            if (picturePath == "no")
                return operation.Failed(ApplicationMessages.PhotoFormat);

            var account = new PersonsUser(command.UserName, password, command.PersonsId, picturePath, userid, agenciesId);
            _PersonsUserRepository.Create(account);
            _PersonsUserRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Edit(PersonsUserEdit command)
        {
            var operation = new OperationResult();
            var account = _PersonsUserRepository.Get(command.Id);
            if (account == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_PersonsUserRepository.Exists(x =>
                (x.UserName == command.UserName || x.PersonsId == command.PersonsId) && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            if (command.ProfilePhoto != null || account.ProfilePhoto != "")
            {
                string? path = account.ProfilePhoto;
                _fileUploader.Delete(path);
            }

            string? slug = command.UserName?.Slugify();

            var logoPath = "PersonsUsers";
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

            account.Edit(command.UserName, command.PersonsId, picturePath, userid, agenciesId);
            _PersonsUserRepository.SaveChanges();
            return operation.Succedded();
        }
        public PersonsUserEdit GetDetails(int id)
        {
            return _PersonsUserRepository.GetDetails(id);
        }
        public OperationResult Login(PersonsUserLogin command)
        {
            var operation = new OperationResult();
            var PersonsUser = _PersonsUserRepository.GetBy(command.UserName);
            if (PersonsUser == null)
                return operation.Failed(ApplicationMessages.WrongUserPass);

            var result = _passwordHasher.Check(PersonsUser.Password, command.Password);
            if (!result.Verified)
                return operation.Failed(ApplicationMessages.WrongUserPass);

            if (PersonsUser.Status != true || PersonsUser.Deleted != false)
                return operation.Failed(ApplicationMessages.AccessNot);

            var permissions = new List<int> { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150 };

            var authViewModel = new PersonsAuthViewModel(PersonsUser.Id, PersonsUser.PersonsId, PersonsUser.UserName, PersonsUser.AgenciesId,3, permissions);

            _authHelper.Signin(authViewModel);
            return operation.Succedded();
        }
        public OperationResult Logout()
        {
            var operation = new OperationResult();
            _authHelper.SignOut();
            return operation.Succedded();
        }
        public OperationResult Delete(int id)
        {
            var operation = new OperationResult();
            var result = _PersonsUserRepository.Get(id);
            if (result.ProfilePhoto != null || result.ProfilePhoto != "")
            {
                string? path = result.ProfilePhoto;
                _fileUploader.Delete(path);
            }
            _PersonsUserRepository.Delete(result);
            _PersonsUserRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult InActive(int id)
        {
            var operation = new OperationResult();
            var result = _PersonsUserRepository.Get(id);
            result.InActive();
            _PersonsUserRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Active(int id)
        {
            var operation = new OperationResult();
            var result = _PersonsUserRepository.Get(id);
            result.Active();
            _PersonsUserRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Remove(int id)
        {
            var operation = new OperationResult();
            var result = _PersonsUserRepository.Get(id);
            result.Remove();
            _PersonsUserRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Reset(int id)
        {
            var operation = new OperationResult();
            var result = _PersonsUserRepository.Get(id);
            result.Reset();
            _PersonsUserRepository.SaveChanges();
            return operation.Succedded();
        }
        public List<PersonsUserViewModel> GetViewModel()
        {
            return _PersonsUserRepository.GetViewModel();
        }
        public List<PersonsUserViewModel> GetInActive()
        {
            return _PersonsUserRepository.GetInActive();
        }
        public List<PersonsUserViewModel> GetRemove()
        {
            return _PersonsUserRepository.GetRemove();
        }
        public List<PersonsUserViewModel> GetViewModel(int agenciesId)
        {
            return _PersonsUserRepository.GetViewModel(agenciesId);
        }
        public List<PersonsUserViewModel> GetInActive(int agenciesId)
        {
            return _PersonsUserRepository.GetInActive(agenciesId);
        }
        public List<PersonsUserViewModel> GetRemove(int agenciesId)
        {
            return _PersonsUserRepository.GetRemove(agenciesId);
        }
    }
}