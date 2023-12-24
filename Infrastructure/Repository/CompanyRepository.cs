using _0_Framework.Infrastructure;
using Contracts.CompanyContracts;
using Domin.CompanyDomin;

namespace Infrastructure.Repository
{
    public class CompanyRepository : RepositoryBase<int, Company>, ICompanyRepository
    {
        private readonly BE_Context _context;
        public CompanyRepository(BE_Context context) : base(context)
        {
            _context = context;
        }
        public CompanyEdit GetDetails(int id)
        {
            var Company = _context.Companies.Select(x => new CompanyEdit
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                Mobile = x.Mobile,
                Responsible = x.Responsible
            }).FirstOrDefault(x => x.Id == id);
            return Company;
        }
        public List<CompanyViewModel> GetViewModel()
        {
            return _context.Companies.Select(x => new CompanyViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                Mobile = x.Mobile,
                Responsible = x.Responsible,
                Logo = x.Logo
            }).OrderBy(x => x.Id).ToList();
        }
    }
}