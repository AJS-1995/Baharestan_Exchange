using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domin.ExchangeRateDomin;

namespace Infrastructure.Mappings
{
    public class ExchangeRateMapping : IEntityTypeConfiguration<ExchangeRate>
    {
        public void Configure(EntityTypeBuilder<ExchangeRate> builder)
        {
            builder.ToTable("Tbl_ExchangeRates");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.MainMoneyId).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.SecondaryMoneyId).IsRequired();
            builder.Property(x => x.SaveDate).HasMaxLength(25);
            builder.Property(x => x.Status);
            builder.Property(x => x.Deleted);
            builder.Property(x => x.UserId);
            builder.Property(x => x.AgenciesId);
        }
    }
}