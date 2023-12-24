using _0_Framework.Domain;
using Contracts.CompanyContracts;

namespace Domin.CompanyDomin
{
    public interface ICompanyRepository : IRepository<int, Company>
    {
        CompanyEdit GetDetails(int id);
        List<CompanyViewModel> GetViewModel();
    }
}