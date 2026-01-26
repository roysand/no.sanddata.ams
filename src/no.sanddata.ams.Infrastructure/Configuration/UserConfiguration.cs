using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using no.sanddata.ams.Domain.Users;

namespace no.sanddata.ams.Infrastructure.Configuration;

[SuppressMessage("Performance", "CA1812:Avoid uninstantiated internal classes", Justification = "Instantiated by DI container")]
internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .ValueGeneratedNever();

        builder.Property(u => u.Email)
            .HasConversion(
                email => email.Value,
                value => new Domain.Users.Email(value))
            .IsRequired()
            .HasMaxLength(255);

        builder.HasIndex(u => u.Email)
            .IsUnique();

        builder.Property(u => u.FirstName)
            .HasConversion(
                firstName => firstName.Value,
                value => new FirstName(value))
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.LastName)
            .HasConversion(
                lastName => lastName.Value,
                value => new LastName(value))
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.PasswordHash)
            .HasConversion(
                passwordHash => passwordHash.Value,
                value => new PasswordHash(value))
            .IsRequired()
            .HasMaxLength(500);

        builder.Property(u => u.IsActive)
            .IsRequired()
            .HasDefaultValue(true);

        builder.Property(u => u.CreatedAtUtc)
            .IsRequired();

        builder.Property(u => u.ModifiedAtUtc)
            .IsRequired();
    }
}
