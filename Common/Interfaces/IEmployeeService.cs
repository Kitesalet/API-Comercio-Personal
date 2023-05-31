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

    public Task<EmployeeGet> GetEmployeeByIdAsync(int id);

    public Task<List<EmployeeList>> GetEmployeesFiltered(EmployeeFiltered employeeFiltered);

    public Task UpdateEmployee(EmployeeUpdate employeeUpdate);


    public Task DeleteEmployee(EmployeeDelete employeeDelete);

}
