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

namespace Functional.Services
{
    internal class EmployeeService : IEmployeeService
    {
        private readonly IGenericRepository<Employee> _repo;
        private IMapper _mapper;
        private readonly IGenericRepository<Job> _jobRepo;
        private readonly IGenericRepository<Address> _addressRepo;
        private readonly IGenericRepository<Team> _teamRepo;

        public EmployeeService(IMapper mapper, IGenericRepository<Team> teamRepo, IGenericRepository<Employee> employeeRepo, IGenericRepository<Address> addressRepo, IGenericRepository<Job> jobRepo)
        {
            
            _repo = employeeRepo;

            _mapper = mapper;

            _jobRepo = jobRepo;

            _addressRepo = addressRepo;

            _teamRepo = teamRepo;

        }

        public async Task<int> CreateEmployeeAsync(EmployeeCreate employeeCreate)
        {          

            var entity = _mapper.Map<Employee>(employeeCreate);

            Job job = await _jobRepo.GetByIdAsync(employeeCreate.JobId);

            Address address = await _addressRepo.GetByIdAsync(employeeCreate.AddressId);


            await _repo.AddAsync(entity);

            await _repo.SaveChangesAsync();

            return entity.Id;


        }

        public async Task DeleteEmployee(EmployeeDelete employeeDelete)
        {
            var oldEntity = await _repo.GetByIdAsync(employeeDelete.Id);

            var entity = _mapper.Map<Employee>(oldEntity);

            _repo.DeleteAsync(entity);

            await _repo.SaveChangesAsync();

        }

        public async Task<EmployeeGet> GetEmployeeByIdAsync(int employeeId)
        {

            var employee = await _repo.GetByIdAsync(employeeId, e => e.Address, e => e.Address);

            
            return _mapper.Map<EmployeeGet>(employee);



        }

        public async Task<List<EmployeeGetSimple>> GetEmployeeFiltered(EmployeeFilters employeeFilters)
        {

            Expression<Func<Employee, bool>>[] filters = new Expression<Func<Employee, bool>>[]
            {
                employee => employeeFilters.Job == null ? true : employee.Job.Name.StartsWith(employeeFilters.Job),
                employee => employeeFilters.Address == null ? true : employee.Address.Street.Contains(employeeFilters.Address),
                employee => employeeFilters.FirstName == null ? true : employee.FirstName.StartsWith(employeeFilters.FirstName),
                e => employeeFilters.LastName == null ? true : e.LastName.StartsWith(employeeFilters.LastName),
            };

            var entities = await _repo.GetFilteredAsync(filters,null,null);

            return _mapper.Map<List<EmployeeGetSimple>>(entities);


        }

        public async Task UpdateEmployeeAsync(EmployeeUpdate employeeUpdate)
        {

            var entity = await _repo.GetByIdAsync(employeeUpdate.Id, e => e.Teams, e => e.Address, e => e.Job);

            var job = await _jobRepo.GetByIdAsync(employeeUpdate.JobId);

            var address = await _addressRepo.GetByIdAsync(employeeUpdate.AddressId);

            entity.Job = job;

            entity.Address = address;

            _repo.UpdateAsync(entity);

            await _repo.SaveChangesAsync();




        }
    }
}
