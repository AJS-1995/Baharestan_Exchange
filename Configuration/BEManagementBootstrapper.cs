using _0_Framework.Infrastructure.Permission;
using Application;
using Application.UsersApplication;
using Configuration.Permissions.General;
using Configuration.Permissions.Users;
using Contracts.AgenciesContracts;
using Contracts.CompanyContracts;
using Contracts.DailyRateContracts;
using Contracts.ExchangeRateContracts;
using Contracts.ExpenseContracts;
using Contracts.MoneyContracts;
using Contracts.PersonnelContracts;
using Contracts.PersonsContracts;
using Contracts.PersonsReceiptContracts;
using Contracts.SafeBoxContracts;
using Contracts.UsersContracts.RoleContracts;
using Contracts.UsersContracts.UsersContracts;
using Domin.AgenciesDomin;
using Domin.CompanyDomin;
using Domin.DailyRateDomin;
using Domin.ExchangeRateDomin;
using Domin.ExpenseDomin;
using Domin.MoneyDomin;
using Domin.PersonnelDomin;
using Domin.PersonsDomin;
using Domin.PersonsReceiptDomin;
using Domin.SafeBoxDomin;
using Domin.UsersDomin;
using Infrastructure;
using Infrastructure.Repository;
using Infrastructure.Repository.UsersRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Configuration
{
    public class BEManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IUserApplication, UserApplication>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<IRoleApplication, RoleApplication>();
            services.AddTransient<IRoleRepository, RoleRepository>();

            services.AddTransient<ICompanyApplication, CompanyApplication>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();

            services.AddTransient<IAgenciesApplication, AgenciesApplication>();
            services.AddTransient<IAgenciesRepository, AgenciesRepository>();

            services.AddTransient<ICollectionApplication, CollectionApplication>();
            services.AddTransient<ICollectionRepository, CollectionRepository>();

            services.AddTransient<IExpenseApplication, ExpenseApplication>();
            services.AddTransient<IExpenseRepository, ExpenseRepository>();

            services.AddTransient<IMoneyApplication, MoneyApplication>();
            services.AddTransient<IMoneyRepository, MoneyRepository>();

            services.AddTransient<IPersonnelApplication, PersonnelApplication>();
            services.AddTransient<IPersonnelRepository, PersonnelRepository>();

            services.AddTransient<IPersonsApplication, PersonsApplication>();
            services.AddTransient<IPersonsRepository, PersonsRepository>();

            services.AddTransient<ISafeBoxApplication, SafeBoxApplication>();
            services.AddTransient<ISafeBoxRepository, SafeBoxRepository>();

            services.AddTransient<IExchangeRateApplication, ExchangeRateApplication>();
            services.AddTransient<IExchangeRateRepository, ExchangeRateRepository>();

            services.AddTransient<IDailyRateApplication, DailyRateApplication>();
            services.AddTransient<IDailyRateRepository, DailyRateRepository>();

            services.AddTransient<IPersonsReceiptApplication, PersonsReceiptApplication>();
            services.AddTransient<IPersonsReceiptRepository, PersonsReceiptRepository>();

            services.AddTransient<IPermissionExposer, UserPermissionExposer>();
            services.AddTransient<IPermissionExposer, GeneralPermissionExposer>();

            services.AddDbContext<BE_Context>(x => x.UseSqlServer(connectionString));
        }
    }
}