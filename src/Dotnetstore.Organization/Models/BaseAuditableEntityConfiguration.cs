using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dotnetstore.Organization.Models;

internal abstract class BaseAuditableEntityConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseAuditableEntity
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder
            .HasKey(e => e.Id);

        builder
            .HasIndex(x => x.Id)
            .IsUnique();

        builder
            .Property(x => x.Id)
            .ValueGeneratedNever()
            .IsRequired();
        
        builder
            .Property(x => x.CreatedAt)
            .IsRequired();
    }
}