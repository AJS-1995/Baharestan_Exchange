using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domin.AgenciesDomin;

namespace Infrastructure.Mappings
{
    public class AgenciesMapping : IEntityTypeConfiguration<Agencies>
    {
        public void Configure(EntityTypeBuilder<Agencies> builder)
        {
            builder.ToTable("Tbl_Agencies");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Mobile).HasMaxLength(50);
            builder.Property(x => x.Address).HasMaxLength(500);
            builder.Property(x => x.SaveDate).HasMaxLength(25);
            builder.Property(x => x.Status);
            builder.Property(x => x.Deleted);
            builder.Property(x => x.UserId);
            builder.Property(x => x.Responsible).HasMaxLength(100);
            builder.Property(x => x.CompanyId);
        }
    }
}
