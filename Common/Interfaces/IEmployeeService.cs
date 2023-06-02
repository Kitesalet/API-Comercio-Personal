using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTOs.EmployeeDto;

namespace Common.Interfaces;

public interface IEmployeeService
{

    public Task<int> CreateEmployeeAsync(EmployeeCreate employeeCreate);

    public Task UpdateEmployeeAsync(EmployeeUpdate employeeUpdate);

    public Task DeleteEmployee(EmployeeDelete employeeDelete);

    public Task<EmployeeGet> GetEmployeeByIdAsync(int employeeId);

    public Task<List<EmployeeGetSimple>> GetEmployeeFiltered(EmployeeFilters employeeFIlters);


}
