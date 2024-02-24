using _0_Framework.Application.Auth;
using _0_Framework.Application;
using Domin.ManagementPresonsDomin.PersonsDomin;
using Contracts.ManagementPresonsContracts.PersonsContracts;
using _0_Framework.Application.PersonsAuth;
using _0_Framework.Application.Password;

namespace Application.ManagementPresonsApplication
{
    public class PersonsApplication : IPersonsApplication
    {
        private readonly IPersonsRepository _personsRepository;
        private readonly IAuthHelper _authHelper;
        private readonly IFileUploader _fileUploader;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IPersonsAuthHelper _personsauthHelper;
        public PersonsApplication(IPersonsRepository personsRepository, IAuthHelper authHelper, IFileUploader fileUploader, IPasswordHasher passwordHasher, IPersonsAuthHelper personsauthHelper)
        {
            _personsRepository = personsRepository;
            _authHelper = authHelper;
            _fileUploader = fileUploader;
            _passwordHasher = passwordHasher;
            _personsauthHelper = personsauthHelper;
        }
        public OperationResult Active(int id)
        {
            var operation = new OperationResult();
            var result = _personsRepository.Get(id);
            result.Active();
            _personsRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult ChangePassword(PersonsChangePassword command)
        {
            var operation = new OperationResult();
            var persons = _personsRepository.Get(command.Id);
            if (persons == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (command.Password != command.RePassword)
                return operation.Failed(ApplicationMessages.PasswordsNotMatch);

            var password = _passwordHasher.Hash(command.Password);
            persons.ChangePassword(password);
            _personsRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Create(PersonsCreate command)
        {
            var operation = new OperationResult();

            var userid = _authHelper.CurrentUserId();
            var password = _passwordHasher.Hash(command.Password);
            var agenciesId = _authHelper.CurrentAgenciesId();
            if (agenciesId == 0)
            {
                agenciesId = command.AgenciesId;
            }

            if (_personsRepository.Exists(x => x.Name == command.Name && x.AgenciesId == agenciesId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            string? slug = command.Name.Slugify();

            var logoPath = "Persons";
            var logoname = slug;
            var picturePath = _fileUploader.Upload(command.ProfilePhoto, logoPath, logoname);
            if (picturePath == "no")
                return operation.Failed(ApplicationMessages.PhotoFormat);

            var result = new Persons(command.Name, command.Mobile, command.Address, command.Company, command.Guarantor, picturePath, command.Personnel, command.UserName, password, userid, agenciesId);
            _personsRepository.Create(result);
            _personsRepository.SaveChanges();
            operation.Id = result.Id;
            return operation.Succedded();
        }
        public OperationResult Delete(int id)
        {
            var operation = new OperationResult();
            var result = _personsRepository.Get(id);
            if (result.ProfilePhoto != null || result.ProfilePhoto != "")
            {
                string? path = result.ProfilePhoto;
                _fileUploader.Delete(path);
            }
            _personsRepository.Delete(result);
            _personsRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Edit(PersonsEdit command)
        {
            var operation = new OperationResult();

            var userid = _authHelper.CurrentUserId();
            var agenciesId = _authHelper.CurrentAgenciesId();
            if (agenciesId == 0)
            {
                agenciesId = command.AgenciesId;
            }

            var result = _personsRepository.Get(command.Id);
            if (result == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_personsRepository.Exists(x => x.Name == command.Name && x.AgenciesId == agenciesId && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            if (command.ProfilePhoto != null && result.ProfilePhoto != "")
            {
                string? path = result.ProfilePhoto;
                _fileUploader.Delete(path);
            }

            string? slug = command.Name.Slugify();

            var logoPath = "Persons";
            var logoname = slug;
            var picturePath = _fileUploader.Upload(command.ProfilePhoto, logoPath, logoname);
            if (picturePath == "no")
                return operation.Failed(ApplicationMessages.PhotoFormat);

            result.Edit(command.Name, command.Mobile, command.Address, command.Company, command.Guarantor, picturePath, command.Personnel, command.UserName, userid, agenciesId);
            _personsRepository.SaveChanges();
            operation.Id = result.Id;
            return operation.Succedded();
        }
        public PersonsEdit GetDetails(int id)
        {
            return _personsRepository.GetDetails(id);
        }
        public List<PersonsViewModel> GetInActive()
        {
            return _personsRepository.GetInActive();
        }
        public List<PersonsViewModel> GetInActive(int agenciesId)
        {
            return _personsRepository.GetInActive(agenciesId);
        }
        public List<PersonsViewModel> GetRemove()
        {
            return _personsRepository.GetRemove();
        }
        public List<PersonsViewModel> GetRemove(int agenciesId)
        {
            return _personsRepository.GetRemove(agenciesId);
        }
        public List<PersonsViewModel> GetViewModel()
        {
            return _personsRepository.GetViewModel();
        }
        public List<PersonsViewModel> GetViewModel(int agenciesId)
        {
            return _personsRepository.GetViewModel(agenciesId);
        }
        public OperationResult InActive(int id)
        {
            var operation = new OperationResult();
            var result = _personsRepository.Get(id);
            result.InActive();
            _personsRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Login(PersonsLogin command)
        {
            var operation = new OperationResult();
            var persons = _personsRepository.GetBy(command.UserName);
            if (persons == null)
                return operation.Failed(ApplicationMessages.WrongUserPass);

            var result = _passwordHasher.Check(persons.Password, command.Password);
            if (!result.Verified)
                return operation.Failed(ApplicationMessages.WrongUserPass);

            if (persons.Status != true || persons.Deleted != false)
                return operation.Failed(ApplicationMessages.AccessNot);

            var permissions = new List<int> { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150 };

            var authViewModel = new PersonsAuthViewModel(persons.Id, persons.UserName, persons.AgenciesId, 3, permissions);

            _personsauthHelper.Signin(authViewModel);
            return operation.Succedded();
        }
        public OperationResult Logout()
        {
            var operation = new OperationResult();
            _personsauthHelper.SignOut();
            return operation.Succedded();
        }
        public OperationResult Remove(int id)
        {
            var operation = new OperationResult();
            var result = _personsRepository.Get(id);
            result.Remove();
            _personsRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Reset(int id)
        {
            var operation = new OperationResult();
            var result = _personsRepository.Get(id);
            result.Reset();
            _personsRepository.SaveChanges();
            return operation.Succedded();
        }
    }
}