using AutoMapper;
using Common.DTOs.EmployeeDto;
using Common.Interfaces;
using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Functional.Services;

public class EmployeeService : IEmployeeService
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Employee> _employeeRepo;
    private readonly IGenericRepository<Address> _addressRepo;
    private readonly IGenericRepository<Job> _jobRepo;

    public EmployeeService(IMapper mapper, IGenericRepository<Employee> employeeRepo, IGenericRepository<Address> addressRepo, IGenericRepository<Job> jobRepo)
    {

        _mapper = mapper;
        _employeeRepo = employeeRepo;
        _addressRepo = addressRepo;
        _jobRepo = jobRepo;

    }

    public async Task<int> CreateEmployeeAsync(EmployeeCreate employeeCreate)
    {

        var job = await _jobRepo.GetByIdAsync(employeeCreate.JobId);
        var address = await _addressRepo.GetByIdAsync(employeeCreate.AddressId);

        var employee = _mapper.Map<Employee>(employeeCreate);

        employee.Address = address;
        employee.Job = job;

        await _employeeRepo.AddAsync(employee);

        await _employeeRepo.SaveChangesAsync();

        return employee.Id;

    }

    public async Task DeleteEmployee(EmployeeDelete employeeDelete)
    {
        var entity = await _employeeRepo.GetByIdAsync(employeeDelete.Id);

        _employeeRepo.DeleteAsync(entity);

        await _employeeRepo.SaveChangesAsync();

    }

    public async Task<EmployeeGet> GetEmployeeByIdAsync(int id)
    {
        
        var entity = await _employeeRepo.GetByIdAsync(id, e => e.Address, entity => entity.Job, entity => entity.Teams);

        var entityDto = _mapper.Map<EmployeeGet>(entity);

        return entityDto;

    }

    public async Task<List<EmployeeList>> GetEmployeesFiltered(EmployeeFiltered employeeFiltered)
    {



        Expression<Func<Employee, bool>>[] filtros = new Expression<Func<Employee, bool>>[]
        {
            employee => employeeFiltered.FirstName == null ? true : employee.FirstName.StartsWith(employeeFiltered.FirstName),
            employee => employeeFiltered.LastName == null ? true : employee.LastName.StartsWith(employeeFiltered.LastName),
            employee => employeeFiltered.Job == null ? true : employee.Job.Name.StartsWith(employeeFiltered.Job),
            employee => employeeFiltered.Address == null ? true: employee.Address.Street.StartsWith(employeeFiltered.Address)

        };

        var list = await _employeeRepo.GetFilteredAsync(filtros, employeeFiltered.skip, employeeFiltered.take, e=> e.Teams, e => e.Address, e => e.Job);

        return _mapper.Map<List<EmployeeList>>(list);

    }

    public async Task UpdateEmployee(EmployeeUpdate employeeUpdate)
    {

        var job = await _jobRepo.GetByIdAsync(employeeUpdate.JobId);
        var address = await _addressRepo.GetByIdAsync(employeeUpdate.AddressId);

        var entity = _mapper.Map<Employee>(employeeUpdate);

        entity.Address = address;
        entity.Job = job;

         _employeeRepo.UpdateAsync(entity);

        _employeeRepo.SaveChangesAsync();

    }
}
