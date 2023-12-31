﻿using _0_Framework.Application.Auth;
using _0_Framework.Application;
using Contracts.PersonsContracts;
using Domin.PersonsDomin;

namespace Application
{
    public class PersonsApplication : IPersonsApplication
    {
        private readonly IPersonsRepository _personsRepository;
        private readonly IAuthHelper _authHelper;
        private readonly IFileUploader _fileUploader;
        public PersonsApplication(IPersonsRepository personsRepository, IAuthHelper authHelper, IFileUploader fileUploader)
        {
            _personsRepository = personsRepository;
            _authHelper = authHelper;
            _fileUploader = fileUploader;
        }
        public OperationResult Active(int id)
        {
            var operation = new OperationResult();
            var result = _personsRepository.Get(id);
            result.Active();
            _personsRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Create(PersonsCreate command)
        {
            var operation = new OperationResult();
            if (_personsRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var userid = _authHelper.CurrentUserId();
            var agenciesId = _authHelper.CurrentAgenciesId();

            string? slug = command.Name.Slugify();

            var logoPath = "Persons";
            var logoname = slug;
            var picturePath = _fileUploader.Upload(command.GuarantorPhoto, logoPath, logoname);
            if (picturePath == "no")
                return operation.Failed(ApplicationMessages.PhotoFormat);

            var result = new Persons(command.Name, command.Mobile, command.Address, command.Company, command.Guarantor, picturePath, userid, agenciesId);
            _personsRepository.Create(result);
            _personsRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Delete(int id)
        {
            var operation = new OperationResult();
            var result = _personsRepository.Get(id);
            if (result.GuarantorPhoto != null || result.GuarantorPhoto != "")
            {
                string? path = result.GuarantorPhoto;
                _fileUploader.Delete(path);
            }
            _personsRepository.Delete(result);
            _personsRepository.SaveChanges();
            return operation.Succedded();
        }
        public OperationResult Edit(PersonsEdit command)
        {
            var operation = new OperationResult();
            var result = _personsRepository.Get(command.Id);
            if (result == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_personsRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var userid = _authHelper.CurrentUserId();
            var agenciesId = _authHelper.CurrentAgenciesId();

            if (command.GuarantorPhoto != null && result.GuarantorPhoto != "")
            {
                string? path = result.GuarantorPhoto;
                _fileUploader.Delete(path);
            }

            string? slug = command.Name.Slugify();

            var logoPath = "Persons";
            var logoname = slug;
            var picturePath = _fileUploader.Upload(command.GuarantorPhoto, logoPath, logoname);
            if (picturePath == "no")
                return operation.Failed(ApplicationMessages.PhotoFormat);

            result.Edit(command.Name, command.Mobile, command.Address, command.Company, command.Guarantor, picturePath, userid, agenciesId);
            _personsRepository.SaveChanges();
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
        public List<PersonsViewModel> GetRemove()
        {
            return _personsRepository.GetRemove();
        }
        public List<PersonsViewModel> GetViewModel()
        {
            return _personsRepository.GetViewModel();
        }
        public OperationResult InActive(int id)
        {
            var operation = new OperationResult();
            var result = _personsRepository.Get(id);
            result.InActive();
            _personsRepository.SaveChanges();
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