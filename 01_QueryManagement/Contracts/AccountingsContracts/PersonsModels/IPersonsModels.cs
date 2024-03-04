using _0_Framework.Application;

namespace _01_QueryManagement.Contracts.AccountingsContracts.PersonsModels
{
    public interface IPersonsModels
    {
        List<PersonsModels>? PersonsModelss();
        OperationResult LivelihoodMonthModelss();
        List<PersonsModels>? PersonsAccountingModelss(int agenciesId);
        List<PersonsModels>? PersonsAccountingModelss();
    }
}