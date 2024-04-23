using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using UserManager.Model;

namespace UserManager.DataAccess.Configurators;
internal class UserTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User", "dbo");
        builder.Property(e => e.Name)
            .HasColumnType("nvarchar(50)");
        builder.Property(e => e.BirthDate)
            .HasColumnType("date");
        builder.Property(e => e.Version)
        .IsRequired()
        .IsRowVersion()
        .IsConcurrencyToken();
    }
}
