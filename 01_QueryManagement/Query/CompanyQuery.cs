using _01_QueryManagement.Contracts.AgenciesInfo;
using _01_QueryManagement.Contracts.CompanyInfo;
using Infrastructure;

namespace _01_QueryManagement.Query
{
    public class CompanyQuery : ICompanyQueryModel
    {
        private readonly BE_Context _context;
        public CompanyQuery(BE_Context context)
        {
            _context = context;
        }
        public CompanyQueryModel GetCompaneis()
        {
            var company = _context.Companies.Select(x => new CompanyQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Address = x.Address,
                Logo = x.Logo,
                Mobile = x.Mobile,
                Responsible = x.Responsible
            }).FirstOrDefault();
            return company;
        }
    }
}