namespace Dotnetstore.Organization.Employees;

internal interface IEmployeeRepository
{
    ValueTask<IEnumerable<Employee>> GetAllAsync(CancellationToken cancellationToken = default);
    
    ValueTask<Employee?> GetAsync(Guid id, CancellationToken cancellationToken = default);
    
    void Create(Employee employee);
    
    void Update(Employee employee);
    
    void Delete(Employee employee);
    
    ValueTask<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}