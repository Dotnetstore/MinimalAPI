using System.ComponentModel.DataAnnotations;
using Dotnetstore.Organization.Models;

namespace Dotnetstore.Organization.Employees;

public sealed class Employee : BaseAuditableEntity
{
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; } = null!;
    
    public decimal Salary { get; set; }
    
    [Required]
    [StringLength(100, MinimumLength = 5)]
    public string Address { get; set; } = null!;
    
    [Required]
    [StringLength(30, MinimumLength = 1)]
    public string City { get; set; } = null!;
    
    [StringLength(100, MinimumLength = 0)]
    public string? Region { get; set; }
    
    [Required]
    [StringLength(10, MinimumLength = 4)]
    public string PostalCode { get; set; } = null!;
    
    [Required]
    [StringLength(30, MinimumLength = 3)]
    public string Country { get; set; } = null!;
    
    [Required]
    [StringLength(30, MinimumLength = 5)]
    public string Phone { get; set; } = null!;
}