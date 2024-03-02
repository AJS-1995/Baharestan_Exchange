using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domin.ManagementPresonsDomin.LivelihoodMonthDomin;

namespace Infrastructure.Mappings.ManagementPresonsMapping
{
    public class LivelihoodMonthMapping : IEntityTypeConfiguration<LivelihoodMonth>
    {
        public void Configure(EntityTypeBuilder<LivelihoodMonth> builder)
        {
            builder.ToTable("Tbl_LivelihoodMonths");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Year).HasMaxLength(5);
            builder.Property(x => x.Month).HasMaxLength(2);
            builder.Property(x => x.LivelihoodId);
            builder.Property(x => x.PersonsId);
            builder.Property(x => x.Amount);
            builder.Property(x => x.MoneyId);
            builder.Property(x => x.SaveDate).HasMaxLength(25);
            builder.Property(x => x.Status);
            builder.Property(x => x.Deleted);
            builder.Property(x => x.UserId);
            builder.Property(x => x.AgenciesId);

            builder.HasOne(x => x.Livelihood).WithMany(x => x.LivelihoodMonths).HasForeignKey(x => x.LivelihoodId);
            builder.HasOne(x => x.Agenciess).WithMany(x => x.LivelihoodMonths).HasForeignKey(x => x.AgenciesId);
        }
    }
}