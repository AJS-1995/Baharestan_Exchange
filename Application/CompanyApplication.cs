using _0_Framework.Application;
using Contracts.CompanyContracts;
using Domin.CompanyDomin;

namespace Application
{
    public class CompanyApplication : ICompanyApplication
    {
        private readonly ICompanyRepository _CompanyRepository;
        private readonly IFileUploader _fileUploader;
        public CompanyApplication(ICompanyRepository CompanyRepository, IFileUploader fileUploader)
        {
            _CompanyRepository = CompanyRepository;
            _fileUploader = fileUploader;
        }
        public OperationResult Create(CompanyCreate command)
        {
            var operation = new OperationResult();
            var Company = _CompanyRepository.GetViewModel();
            if (Company.Count == 0)
            {
                var Admin = new Company("صرافی بهارستان", "مارکت ضیا دوکان ۱۷ هرات افغانستان", "+ (93) 79-6815655", "عبدالجبار سروری", "");
                _CompanyRepository.Create(Admin);
                _CompanyRepository.SaveChanges();
            }
            else
            {
                if (_CompanyRepository.Exists(x => x.Name == command.Name))
                    return operation.Failed(ApplicationMessages.DuplicatedRecord);


                string? slug = command.Name.Slugify();

                var logoPath = "Users";
                var logoname = slug;
                var picturePath = _fileUploader.Upload(command.Logo, logoPath, logoname);
                if (picturePath == "no")
                    return operation.Failed(ApplicationMessages.PhotoFormat);

                var Companys = new Company(command.Name, command.Address, command.Mobile, command.Responsible, picturePath);
                _CompanyRepository.Create(Companys);
                _CompanyRepository.SaveChanges();
            }
            return operation.Succedded();
        }
        public OperationResult Edit(CompanyEdit command)
        {
            var operation = new OperationResult();
            var Company = _CompanyRepository.Get(command.Id);
            if (Company == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_CompanyRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);


            string? slug = command.Name.Slugify();

            var logoPath = "Users";
            var logoname = slug;
            var picturePath = _fileUploader.Upload(command.Logo, logoPath, logoname);
            if (picturePath == "no")
                return operation.Failed(ApplicationMessages.PhotoFormat);

            Company.Edit(command.Name, command.Address, command.Mobile, command.Responsible, picturePath);
            _CompanyRepository.SaveChanges();
            return operation.Succedded();
        }
        public CompanyEdit GetDetails(int id)
        {
            return _CompanyRepository.GetDetails(id);
        }
        public List<CompanyViewModel> GetViewModel()
        {
            return _CompanyRepository.GetViewModel();
        }
    }
}