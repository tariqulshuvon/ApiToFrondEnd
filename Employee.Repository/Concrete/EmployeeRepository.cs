using AutoMapper;
using Employee.Infrastructure.Persistence;
using Employee.Model;
using Employee.Repository.Interface;
using Employee.Service.Model;

namespace Employee.Repository.Concrete;

public class EmployeeRepository : RepositoryBase<Employees, VMEmployee, int>, IEmployeeRepository
{
    public EmployeeRepository(EmployeeDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
    {
    }
}
