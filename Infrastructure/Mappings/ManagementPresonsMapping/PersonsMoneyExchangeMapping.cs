using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domin.ManagementPresonsDomin.PersonsMoneyExchangeDomin;

namespace Infrastructure.Mappings.ManagementPresonsMapping
{
    public class PersonsMoneyExchangeMapping : IEntityTypeConfiguration<PersonsMoneyExchange>
    {
        public void Configure(EntityTypeBuilder<PersonsMoneyExchange> builder)
        {
            builder.ToTable("Tbl_PersonsMoneyExchanges");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Date);
            builder.Property(x => x.MoneyId_One);
            builder.Property(x => x.MoneyId_Two);
            builder.Property(x => x.Amount_One);
            builder.Property(x => x.Amount_Two);
            builder.Property(x => x.Price);
            builder.Property(x => x.Type);
            builder.Property(x => x.PersonsId);
            builder.Property(x => x.SaveDate);
            builder.Property(x => x.Status);
            builder.Property(x => x.Deleted);
            builder.Property(x => x.UserId);
            builder.Property(x => x.AgenciesId);

            builder.HasOne(x => x.Persons).WithMany(x => x.PersonsMoneyExchanges).HasForeignKey(x => x.PersonsId);
            builder.HasOne(x => x.Agenciess).WithMany(x => x.PersonsMoneyExchanges).HasForeignKey(x => x.AgenciesId);
        }
    }
}