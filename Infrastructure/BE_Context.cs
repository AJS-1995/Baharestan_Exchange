using Domin.AgenciesDomin;
using Domin.CompanyDomin;
using Domin.ExchangeRateDomin;
using Domin.ExpenseDomin;
using Domin.MoneyDomin;
using Domin.PersonnelDomin;
using Domin.PersonsDomin;
using Domin.SafeBoxDomin;
using Domin.UsersDomin;
using Infrastructure.Mappings.UsersMapping;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class BE_Context : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Agencies> Agenciess { get; set; }
        public DbSet<Money> Moneies { get; set; }
        public DbSet<Persons> Personss { get; set; }
        public DbSet<Expense> Expensess { get; set; }
        public DbSet<Collection> Collectionss { get; set; }
        public DbSet<SafeBox> SafeBoxs { get; set; }
        public DbSet<Personnel> Personnels { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }

        public BE_Context(DbContextOptions<BE_Context> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
            var assembly = typeof(UserMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            modelBuilder.Entity<User>().HasIndex(u => u.Mobile).IsUnique();
            base.OnModelCreating(modelBuilder);
        }
        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 1,
                Name = "Admin",
                NamePersian = "مدیر سیستم",
                UserId = 1,
                Cod = 1,
            });
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 2,
                Name = "Accountant",
                NamePersian = "حسابدار",
                UserId = 1,
                Cod = 1,
            });
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 3,
                Name = "Viewer",
                NamePersian = "بیننده",
                UserId = 1,
                Cod = 1,
            });
            modelBuilder.Entity<Money>().HasData(new Money
            {
                Id = 1,
                Name = "افغانی",
                Country = "افغانستان",
                Symbol = "؋",
                UserId = 1,
            });
            modelBuilder.Entity<Money>().HasData(new Money
            {
                Id = 2,
                Name = "دلار",
                Country = "ایالات متحده امریکا",
                Symbol = "$",
                UserId = 1,
            });
            modelBuilder.Entity<Money>().HasData(new Money
            {
                Id = 3,
                Name = "تومان",
                Country = "ایران",
                Symbol = "IRR",
                UserId = 1,
            });
            modelBuilder.Entity<Money>().HasData(new Money
            {
                Id = 4,
                Name = "روپیه پاکستان",
                Country = "پاکستان",
                Symbol = "₨",
                UserId = 1,
            });
            modelBuilder.Entity<Money>().HasData(new Money
            {
                Id = 5,
                Name = "روپیه هندی",
                Country = "هندوستان",
                Symbol = "₹",
                UserId = 1,
            });
            modelBuilder.Entity<Money>().HasData(new Money
            {
                Id = 6,
                Name = "یورو",
                Country = "اروپا",
                Symbol = "€",
                UserId = 1,
            });
            modelBuilder.Entity<Money>().HasData(new Money
            {
                Id = 7,
                Name = "پوند",
                Country = "بریتانیا",
                Symbol = "£",
                UserId = 1,
            });
            modelBuilder.Entity<Money>().HasData(new Money
            {
                Id = 8,
                Name = "یوآن",
                Country = "چین",
                Symbol = "¥",
                UserId = 1,
            });
            modelBuilder.Entity<Money>().HasData(new Money
            {
                Id = 9,
                Name = "لیره",
                Country = "ترکیه",
                Symbol = "₺",
                UserId = 1,
            });
            modelBuilder.Entity<Money>().HasData(new Money
            {
                Id = 10,
                Name = "روبل",
                Country = "روسیه",
                Symbol = "₽",
                UserId = 1,
            });
        }
    }
}