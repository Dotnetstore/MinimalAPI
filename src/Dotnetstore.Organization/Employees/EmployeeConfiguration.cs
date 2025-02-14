using Dotnetstore.Organization.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dotnetstore.Organization.Employees;

internal sealed class EmployeeConfiguration : BaseAuditableEntityConfiguration<Employee>
{
    public override void Configure(EntityTypeBuilder<Employee> builder)
    {
        base.Configure(builder);

        builder
            .Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired()
            .IsUnicode();

        builder
            .Property(x => x.Salary)
            .IsRequired();
        
        builder
            .Property(x => x.Address)
            .HasMaxLength(100)
            .IsRequired()
            .IsUnicode();
        
        builder
            .Property(x => x.City)
            .HasMaxLength(30)
            .IsRequired()
            .IsUnicode();
        
        builder
            .Property(x => x.Region)
            .HasMaxLength(100)
            .IsUnicode();
        
        builder
            .Property(x => x.PostalCode)
            .HasMaxLength(10)
            .IsRequired()
            .IsUnicode();
        
        builder
            .Property(x => x.Country)
            .HasMaxLength(30)
            .IsRequired()
            .IsUnicode();
        
        builder
            .Property(x => x.Phone)
            .HasMaxLength(30)
            .IsRequired()
            .IsUnicode();

        builder
            .HasData(new Employee
            {
                Id = Guid.Parse("39B16AE6-683C-427E-9DB2-3EF22DB88B75"),
                Name = "Test Testsson",
                Salary = 50000,
                Address = "Testgatan 1",
                City = "Teststad",
                Region = "Testlän",
                PostalCode = "12345",
                Country = "Testland",
                Phone = "070-1234567"
            });
    }
}