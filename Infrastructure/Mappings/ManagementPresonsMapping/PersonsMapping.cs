using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domin.ManagementPresonsDomin.PersonsDomin;

namespace Infrastructure.Mappings.ManagementPresonsMapping
{
    public class PersonsMapping : IEntityTypeConfiguration<Persons>
    {
        public void Configure(EntityTypeBuilder<Persons> builder)
        {
            builder.ToTable("Tbl_Persons");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Mobile).HasMaxLength(50);
            builder.Property(x => x.Address).HasMaxLength(500);
            builder.Property(x => x.Company).HasMaxLength(100);
            builder.Property(x => x.Guarantor).HasMaxLength(100);
            builder.Property(x => x.GuarantorPhoto).HasMaxLength(500);
            builder.Property(x => x.SaveDate).HasMaxLength(25);
            builder.Property(x => x.Status);
            builder.Property(x => x.Deleted);
            builder.Property(x => x.UserId);
            builder.Property(x => x.AgenciesId);

            builder.HasMany(x => x.PersonsReceipts).WithOne(x => x.Persons).HasForeignKey(x => x.PersonId);
            builder.HasMany(x => x.PersonsMoneyExchanges).WithOne(x => x.Persons).HasForeignKey(x => x.PersonId);
            builder.HasOne(x => x.Agenciess).WithMany(x => x.Personss).HasForeignKey(x => x.AgenciesId);
        }
    }
}
