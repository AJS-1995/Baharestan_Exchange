using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domin.ManagementPresonsDomin.PersonsReceiptDomin;

namespace Infrastructure.Mappings.ManagementPresonsMapping
{
    public class PersonsReceiptMapping : IEntityTypeConfiguration<PersonsReceipt>
    {
        public void Configure(EntityTypeBuilder<PersonsReceipt> builder)
        {
            builder.ToTable("Tbl_PersonsReceipts");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Date).HasMaxLength(50);
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.By);
            builder.Property(x => x.ReceiptNumber);
            builder.Property(x => x.Type);
            builder.Property(x => x.Amount);
            builder.Property(x => x.SafeBoxId);
            builder.Property(x => x.MoneyId);
            builder.Property(x => x.PersonId);
            builder.Property(x => x.SaveDate).HasMaxLength(25);
            builder.Property(x => x.Status);
            builder.Property(x => x.Deleted);
            builder.Property(x => x.UserId);
            builder.Property(x => x.AgenciesId);
            builder.Property(x => x.Fingerprint).HasMaxLength(500);
            builder.Property(x => x.Picture).HasMaxLength(500);

            builder.HasOne(x => x.Persons).WithMany(x => x.PersonsReceipts).HasForeignKey(x => x.PersonId);
            builder.HasOne(x => x.Moneys).WithMany(x => x.PersonsReceipts).HasForeignKey(x => x.MoneyId);
            builder.HasOne(x => x.Agenciess).WithMany(x => x.PersonsReceipts).HasForeignKey(x => x.AgenciesId);
            builder.HasOne(x => x.SafeBoxs).WithMany(x => x.PersonsReceipts).HasForeignKey(x => x.SafeBoxId);
        }
    }
}