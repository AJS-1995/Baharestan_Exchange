using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domin.DailyRateDomin;

namespace Infrastructure.Mappings
{
    public class DailyRateMapping : IEntityTypeConfiguration<DailyRate>
    {
        public void Configure(EntityTypeBuilder<DailyRate> builder)
        {
            builder.ToTable("Tbl_DailyRates");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Amount).IsRequired();
            builder.Property(x => x.MainMoneyId).IsRequired();
            builder.Property(x => x.PriceBey).IsRequired();
            builder.Property(x => x.PriceSell).IsRequired();
            builder.Property(x => x.SecondaryMoneyId).IsRequired();
            builder.Property(x => x.DateDay).HasMaxLength(25);
            builder.Property(x => x.SaveDate).HasMaxLength(25);
            builder.Property(x => x.Status);
            builder.Property(x => x.Deleted);
            builder.Property(x => x.UserId);
            builder.Property(x => x.AgenciesId);
        }
    }
}