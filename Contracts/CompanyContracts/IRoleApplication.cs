using _0_Framework.Application;

namespace Contracts.CompanyContracts
{
    public interface ICompanyApplication
    {
        OperationResult Create(CompanyCreate command);
        OperationResult Edit(CompanyEdit command);
        List<CompanyViewModel> GetViewModel();
        CompanyEdit GetDetails(int id);
    }
}