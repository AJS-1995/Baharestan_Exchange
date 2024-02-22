using Domin.ManagementPresonsDomin.PersonsUsers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mappings.ManagementPresonsMapping
{
    public class PersonsUserMapping : IEntityTypeConfiguration<PersonsUser>
    {
        public void Configure(EntityTypeBuilder<PersonsUser> builder)
        {
            builder.ToTable("Tbl_PersonsUser");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.PersonsId);
            builder.Property(x => x.UserName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Password).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.ProfilePhoto).HasMaxLength(500).IsRequired();
            builder.Property(x => x.SaveDate).HasMaxLength(25);
            builder.Property(x => x.Status);
            builder.Property(x => x.Deleted);
            builder.Property(x => x.UserId);

            builder.HasOne(x => x.Persons).WithMany(x => x.PersonsUser).HasForeignKey(x => x.PersonsId);
        }
    }
}