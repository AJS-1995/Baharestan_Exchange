using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domin.ExpenseDomin;

namespace Infrastructure.Mappings
{
    public class ExpenseMapping : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.ToTable("Tbl_Expenses");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Collection_Id);
            builder.Property(x => x.N_Invoice).HasMaxLength(100);
            builder.Property(x => x.Amount);
            builder.Property(x => x.Date).HasMaxLength(50);
            builder.Property(x => x.Ph_Invoice).HasMaxLength(500);
            builder.Property(x => x.Personnel_Id);
            builder.Property(x => x.SafeBox_Id);
            builder.Property(x => x.Money_Id);
            builder.Property(x => x.SaveDate).HasMaxLength(25);
            builder.Property(x => x.Status);
            builder.Property(x => x.Deleted);
            builder.Property(x => x.UserId);
            builder.Property(x => x.AgenciesId);

            builder.HasOne(x => x.Collection).WithMany(x => x.Expenses).HasForeignKey(x => x.Collection_Id);
        }
    }
}
