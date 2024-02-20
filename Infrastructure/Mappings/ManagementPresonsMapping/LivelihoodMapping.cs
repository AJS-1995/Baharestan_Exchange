using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domin.ManagementPresonsDomin.LivelihoodDomin;

namespace Infrastructure.Mappings.ManagementPresonsMapping
{
    public class LivelihoodMapping : IEntityTypeConfiguration<Livelihood>
    {
        public void Configure(EntityTypeBuilder<Livelihood> builder)
        {
            builder.ToTable("Tbl_Livelihoods");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.SDate).HasMaxLength(25);
            builder.Property(x => x.EDate).HasMaxLength(25);
            builder.Property(x => x.PersonsId);
            builder.Property(x => x.Amount);
            builder.Property(x => x.Cancel);
            builder.Property(x => x.MoneyId);
            builder.Property(x => x.SaveDate).HasMaxLength(25);
            builder.Property(x => x.Status);
            builder.Property(x => x.Deleted);
            builder.Property(x => x.UserId);
            builder.Property(x => x.AgenciesId);

            builder.HasOne(x => x.Persons).WithMany(x => x.Livelihoods).HasForeignKey(x => x.PersonsId);
            builder.HasOne(x => x.Moneys).WithMany(x => x.Livelihoods).HasForeignKey(x => x.MoneyId);
            builder.HasOne(x => x.Agenciess).WithMany(x => x.Livelihoods).HasForeignKey(x => x.AgenciesId);
        }
    }
}