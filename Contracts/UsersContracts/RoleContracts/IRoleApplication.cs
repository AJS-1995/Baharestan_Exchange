using _0_Framework.Application;

namespace Contracts.UsersContracts.RoleContracts
{
    public interface IRoleApplication
    {
        OperationResult Create(RoleCreate command);
        OperationResult Edit(RoleEdit command);
        List<RoleViewModel> GetViewModel();
        RoleEdit GetDetails(int id);
        OperationResult InActive(int id);
        OperationResult Active(int id);
        OperationResult Remove(int id);
        OperationResult Reset(int id);
        OperationResult Delete(int id);
    }
}