using _0_Framework.Application.Auth;
using _0_Framework.Application;
using Contracts.PersonnelContracts;
using Domin.PersonnelDomin;

namespace Application
{
    public class PersonnelApplication : IPersonnelApplication
    {
        private readonly IPersonnelRepository _personnelRepository;
        private readonly IAuthHelper _authHelper;
        private readonly IFileUploader _fileUploader;
        public PersonnelApplication(IPersonnelRepository personnelRepository, IAuthHelper authHelper, IFileUploader fileUploader)
        {
            _personnelRepository = personnelRepository;
            _authHelper = authHelper;
            _fileUploader = fileUploader;
        }
        public OperationResult Active(int id)
        {
            var operation = new OperationResult();
            var result = _personnelRepository.Get(id);
            result.Active();
            _personnelRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Create(PersonnelCreate command)
        {
            var operation = new OperationResult();
            if (_personnelRepository.Exists(x => x.FullName == command.FullName && x.Fathers_Name == command.Fathers_Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var userid = _authHelper.CurrentUserId();
            var agenciesId = _authHelper.CurrentAgenciesId();

            string? slugp = command.FullName?.Slugify();
            var logoPathp = "Personnel";
            var logonamep = slugp;
            var picturePathp = _fileUploader.Upload(command.Photo, logoPathp, logonamep);
            if (picturePathp == "no")
                return operation.Failed(ApplicationMessages.PhotoFormat);

            var result = new Personnel(command.FullName, command.Fathers_Name, command.Mobile, command.Address, command.Cart_Id, picturePathp, userid, agenciesId);
            _personnelRepository.Create(result);
            _personnelRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Delete(int id)
        {
            var operation = new OperationResult();
            var result = _personnelRepository.Get(id);
            if (result.Photo != null || result.Photo != "")
            {
                string? path = result.Photo;
                _fileUploader.Delete(path);
            }
            _personnelRepository.Delete(result);
            _personnelRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Edit(PersonnelEdit command)
        {
            var operation = new OperationResult();
            var result = _personnelRepository.Get(command.Id);
            if (result == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_personnelRepository.Exists(x => x.FullName == command.FullName && x.Fathers_Name == command.Fathers_Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var userid = _authHelper.CurrentUserId();
            var agenciesId = _authHelper.CurrentAgenciesId();

            if (command.Photo != null && result.Photo != "")
            {
                string? path = result.Photo;
                _fileUploader.Delete(path);
            }

            string? slugp = command.FullName?.Slugify();
            var logoPathp = "Personnel";
            var logonamep = slugp;
            var picturePathp = _fileUploader.Upload(command.Photo, logoPathp, logonamep);
            if (picturePathp == "no")
                return operation.Failed(ApplicationMessages.PhotoFormat);

            result.Edit(command.FullName, command.Fathers_Name, command.Mobile, command.Address, command.Cart_Id, picturePathp, userid, agenciesId);
            _personnelRepository.SaveChanges();
            return operation.Succedded();
        }
        public PersonnelEdit GetDetails(int id)
        {
            return _personnelRepository.GetDetails(id);
        }
        public List<PersonnelViewModel> GetInActive()
        {
            return _personnelRepository.GetInActive();
        }
        public List<PersonnelViewModel> GetRemove()
        {
            return _personnelRepository.GetRemove();
        }
        public List<PersonnelViewModel> GetViewModel()
        {
            return _personnelRepository.GetViewModel();
        }
        public OperationResult InActive(int id)
        {
            var operation = new OperationResult();
            var result = _personnelRepository.Get(id);
            result.InActive();
            _personnelRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Remove(int id)
        {
            var operation = new OperationResult();
            var result = _personnelRepository.Get(id);
            result.Remove();
            _personnelRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Reset(int id)
        {
            var operation = new OperationResult();
            var result = _personnelRepository.Get(id);
            result.Reset();
            _personnelRepository.SaveChanges();
            return operation.Succedded();
        }
    }
}