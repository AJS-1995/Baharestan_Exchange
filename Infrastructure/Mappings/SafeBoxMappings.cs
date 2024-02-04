using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domin.SafeBoxDomin;

namespace Infrastructure.Mappings
{
    public class SafeBoxMappings : IEntityTypeConfiguration<SafeBox>
    {
        public void Configure(EntityTypeBuilder<SafeBox> builder)
        {
            builder.ToTable("Tbl_SafeBoxs");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Treasurer).HasMaxLength(500);
            builder.Property(x => x.Mobile).HasMaxLength(50);
            builder.Property(x => x.SaveDate).HasMaxLength(25);
            builder.Property(x => x.Status);
            builder.Property(x => x.Deleted);
            builder.Property(x => x.UserId);
            builder.Property(x => x.AgenciesId);

            builder.HasMany(x => x.PersonsReceipts).WithOne(x => x.SafeBoxs).HasForeignKey(x => x.SafeBoxId);
        }
    }
}
