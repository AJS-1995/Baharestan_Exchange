using _01_QueryManagement.Contracts.AgenciesInfo;
using _01_QueryManagement.Contracts.CompanyInfo;
using _01_QueryManagement.Contracts.Users;

namespace _01_QueryManagement
{
    public class SidebarModel
    {
        public UserQueryModel? UsersQueryModel { get; set; }
        public CompanyQueryModel? CompaneisQueryModel { get; set; }
        public AgenciesQueryModel? AgenciessQueryModel { get; set; }
    }
}