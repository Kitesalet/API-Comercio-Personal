using AutoMapper;
using Common.DTOs;
using Common.DTOs.TeamDto;
using Common.Interfaces;
using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Functional.Services;

public class TeamService : ITeamService
{
    private IMapper _mapper;
    private IGenericRepository<Team> _teamRepo;
    private IGenericRepository<Employee> _employeeRepo;

    public TeamService(IMapper mapper, IGenericRepository<Team> teamRepo, IGenericRepository<Employee> employeeRepo)
    {

        _mapper = mapper;
        _teamRepo = teamRepo;
        _employeeRepo = employeeRepo;


    }


    public async Task<int> AddTeamAsync(TeamCreate teamAdd)
    {
       
        var entity = _mapper.Map<Team>(teamAdd);

        Expression<Func<Employee, bool>>[] employeeFilter = new Expression<Func<Employee, bool>>[] {e => teamAdd.Employees.Contains(e.Id)};

        var listEmployee = await _employeeRepo.GetFilteredAsync(employeeFilter, null, null);

        entity.Employees = listEmployee;

        await _teamRepo.AddAsync(entity);

        await _teamRepo.SaveChangesAsync();

        return entity.Id;


    }

    public async Task DeleteTeam(TeamDelete teamDelete)
    {

        var entity = await _teamRepo.GetByIdAsync(teamDelete.Id);

        _teamRepo.DeleteAsync(entity);

        await _teamRepo.SaveChangesAsync();



    }

    public async Task<TeamGet> GetTeamByIdAsync(int id)
    {
        
        var entity = await _teamRepo.GetByIdAsync(id, e => e.Employees);

        var teamMapped = _mapper.Map<TeamGet>(entity);

        return teamMapped;

    }

    public async Task<List<TeamGet>> GetTeamListAsync(TeamFiltered filter)
    {

        Expression<Func<Team, bool>>[] filtros = new Expression<Func<Team, bool>>[]
        {
           team => filter.Name == null ? true : team.Name.StartsWith(filter.Name)
        };

        var entity = await _teamRepo.GetFilteredAsync(filtros, null, null, e => e.Employees);

        return _mapper.Map<List<TeamGet>>(entity);  

    }

    public async Task UpdateTeam(TeamUpdate teamUpdate)
    {
        
        var entity = await _teamRepo.GetByIdAsync(teamUpdate.Id, e => e.Employees);

        Expression<Func<Employee, bool>>[] filter = new Expression<Func<Employee, bool>>[]
        { 
            emp => teamUpdate.Employees.Contains(emp.Id)
        };

        entity.Employees = await _employeeRepo.GetFilteredAsync(filter, null, null);

        //Esta es una forma para tambien mapear

        _mapper.Map(teamUpdate, entity);

        _teamRepo.UpdateAsync(entity);

        await _teamRepo.SaveChangesAsync();

    }
}
