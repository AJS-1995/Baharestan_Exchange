using _01_QueryManagement.Contracts.AccountingsContracts;
using _01_QueryManagement.Contracts.AccountingsContracts.PersonsModels;
using _01_QueryManagement.Contracts.AgenciesInfo;
using _01_QueryManagement.Contracts.CompanyInfo;
using _01_QueryManagement.Contracts.Permissions.General;
using _01_QueryManagement.Contracts.Permissions.User;
using _01_QueryManagement.Contracts.Users;
using _01_QueryManagement.Query;
using _01_QueryManagement.Query.AccountingsQuery;
using _01_QueryManagement.Query.Permissions;
using Microsoft.Extensions.DependencyInjection;

namespace _01_QueryManagement
{
    public class QueryManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IUserQueryModel, UserQuery>();
            services.AddTransient<ICompanyQueryModel, CompanyQuery>();
            services.AddTransient<IAgenciesQueryModel, AgenciesQuery>();
            services.AddTransient<IUserPermissionQueryModel, UserPermissionQuery>();
            services.AddTransient<IGeneralPermissionQueryModel, GeneralPermissionQuery>();
            services.AddTransient<IPersonsModels, PersonsQuery>();
        }
    }
}