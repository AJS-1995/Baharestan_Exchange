using _0_Framework.Application.Auth;
using _0_Framework.Application;
using Domin.ManagementPresonsDomin.PersonsReceiptDomin;
using Contracts.ManagementPresonsContracts.PersonsReceiptContracts;

namespace Application.ManagementPresonsApplication
{
    public class PersonsReceiptApplication : IPersonsReceiptApplication
    {
        private readonly IPersonsReceiptRepository _personsReceiptRepository;
        private readonly IAuthHelper _authHelper;
        private readonly IFileUploader _fileUploader;
        public PersonsReceiptApplication(IPersonsReceiptRepository PersonsReceiptRepository, IAuthHelper authHelper, IFileUploader fileUploader)
        {
            _personsReceiptRepository = PersonsReceiptRepository;
            _authHelper = authHelper;
            _fileUploader = fileUploader;
        }
        public OperationResult Active(long id)
        {
            var operation = new OperationResult();
            var result = _personsReceiptRepository.Get(id);
            result.Active();
            _personsReceiptRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Create(PersonsReceiptCreate command)
        {
            var operation = new OperationResult();

            var userid = _authHelper.CurrentUserId();
            var agenciesId = _authHelper.CurrentAgenciesId();
            if (agenciesId == 0)
            {
                agenciesId = command.AgenciesId;
            }

            if (_personsReceiptRepository.Exists(x => x.Date == command.Date && x.Description == command.Description && x.AgenciesId == command.AgenciesId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var logoPath = "PersonsReceipts";
            var Fingerprintname = DateTime.Now.ToFull() + " - " + "Fingerprint";
            var FingerprintPath = _fileUploader.Upload(command.Fingerprint, logoPath, Fingerprintname);
            if (FingerprintPath == "no")
                return operation.Failed(ApplicationMessages.PhotoFormat);

            var Picturename = DateTime.Now.ToFull() + " - " + "Picture"; ;
            var PicturePath = _fileUploader.Upload(command.Picture, logoPath, Picturename);
            if (PicturePath == "no")
                return operation.Failed(ApplicationMessages.PhotoFormat);

            var result = new PersonsReceipt(command.Date, command.Description, command.By, command.ReceiptNumber,
                command.Type, command.Amount, command.SafeBoxId, command.MoneyId, command.PersonId, FingerprintPath, PicturePath, userid, agenciesId);
            _personsReceiptRepository.Create(result);
            _personsReceiptRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Delete(long id)
        {
            var operation = new OperationResult();
            var result = _personsReceiptRepository.Get(id);
            if (result.Fingerprint != null || result.Fingerprint != "")
            {
                string? path = result.Fingerprint;
                _fileUploader.Delete(path);
            }
            if (result.Picture != null || result.Picture != "")
            {
                string? path = result.Picture;
                _fileUploader.Delete(path);
            }
            _personsReceiptRepository.Delete(result);
            _personsReceiptRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Edit(PersonsReceiptEdit command)
        {
            var operation = new OperationResult();
            var result = _personsReceiptRepository.Get(command.Id);
            if (result == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            var userid = _authHelper.CurrentUserId();
            var agenciesId = _authHelper.CurrentAgenciesId();
            if (agenciesId == 0)
            {
                agenciesId = command.AgenciesId;
            }

            if (_personsReceiptRepository.Exists(x => x.Date == command.Date && x.Description == command.Description && x.AgenciesId == command.AgenciesId && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            if (command.Fingerprint != null)
            {
                if (result.Fingerprint != "")
                {
                    string? path = result.Fingerprint;
                    _fileUploader.Delete(path);
                }
            }
            if (command.Picture != null)
            {
                if (result.Fingerprint != "")
                {
                    string? path = result.Picture;
                    _fileUploader.Delete(path);
                }
            }
            var logoPath = "PersonsReceipts";
            var FingerprintPath = command.Fingerprint?.ToString();
            var PicturePath = command.Picture?.ToString();
            if (command.Fingerprint != null)
            {
                var Fingerprintname = DateTime.Now.ToFull() + " - " + "Fingerprint";
                FingerprintPath = _fileUploader.Upload(command.Fingerprint, logoPath, Fingerprintname);
                if (FingerprintPath == "no")
                    return operation.Failed(ApplicationMessages.PhotoFormat);
            }
            if (command.Picture != null)
            {
                var Picturename = DateTime.Now.ToFull() + " - " + "Picture"; ;
                PicturePath = _fileUploader.Upload(command.Picture, logoPath, Picturename);
                if (PicturePath == "no")
                    return operation.Failed(ApplicationMessages.PhotoFormat);
            }

            result.Edit(command.Date, command.Description, command.By, command.ReceiptNumber,
                command.Type, command.Amount, command.SafeBoxId, command.MoneyId, command.PersonId, FingerprintPath, PicturePath, userid, agenciesId);
            _personsReceiptRepository.SaveChanges();
            return operation.Succedded();
        }
        public PersonsReceiptEdit GetDetails(long id)
        {
            return _personsReceiptRepository.GetDetails(id);
        }
        public List<PersonsReceiptViewModel> GetInActive()
        {
            return _personsReceiptRepository.GetInActive();
        }
        public List<PersonsReceiptViewModel> GetInActive(int agenciesId)
        {
            return _personsReceiptRepository.GetInActive(agenciesId);
        }
        public List<PersonsReceiptViewModel> GetRemove()
        {
            return _personsReceiptRepository.GetRemove();
        }
        public List<PersonsReceiptViewModel> GetRemove(int agenciesId)
        {
            return _personsReceiptRepository.GetRemove(agenciesId);
        }
        public List<PersonsReceiptViewModel> GetViewModel()
        {
            return _personsReceiptRepository.GetViewModel();
        }
        public List<PersonsReceiptViewModel> GetViewModel(int agenciesId)
        {
            return _personsReceiptRepository.GetViewModel(agenciesId);
        }
        public OperationResult InActive(long id)
        {
            var operation = new OperationResult();
            var result = _personsReceiptRepository.Get(id);
            result.InActive();
            _personsReceiptRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var result = _personsReceiptRepository.Get(id);
            result.Remove();
            _personsReceiptRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Reset(long id)
        {
            var operation = new OperationResult();
            var result = _personsReceiptRepository.Get(id);
            result.Reset();
            _personsReceiptRepository.SaveChanges();
            return operation.Succedded();
        }
    }
}