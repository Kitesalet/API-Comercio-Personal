using AutoMapper;
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

internal class TeamService : ITeamService
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<Team> _teamRepo;
    private readonly IGenericRepository<Employee> _employeeRepo;

    public TeamService(IMapper mapper, IGenericRepository<Team> teamRepo, IGenericRepository<Employee> employeesRepo)
    {

        _mapper = mapper;
        _teamRepo = teamRepo;
        _employeeRepo = employeesRepo;

    }

    public async Task<int> CreateTeamAsync(TeamCreate teamCreate)
    {

        var employees = await _employeeRepo.GetFilteredAsync(new Expression<Func<Employee, bool>>[] { e => teamCreate.Employees.Contains(e.Id) }, null, null);

        var mapped = _mapper.Map<Team>(teamCreate);

       mapped.Employees = employees;

       

       await _teamRepo.AddAsync(mapped);

       await _teamRepo.SaveChangesAsync();

       return mapped.Id;

    }

    public async Task DeleteTeam(TeamDelete teamDelete)
    {
        
        var team = await _teamRepo.GetByIdAsync(teamDelete.Id, e => e.Employees);

        _teamRepo.DeleteAsync(team);

        await _teamRepo.SaveChangesAsync();

    }

    public async Task<TeamGet> GetTeamIdAsync(int id)
    {
        
        var x = await _teamRepo.GetByIdAsync(id, e => e.Employees);

        return _mapper.Map<TeamGet>(x);

    }

    public async Task<List<TeamGet>> GetTeamsAsync()
    {

        var x = await _teamRepo.GetAsync(null,null, e => e.Employees);

        return _mapper.Map<List<TeamGet>>(x);


    }

    public async Task UpdateTeam(TeamUpdate teamUpdate)
    {

        var x = await _teamRepo.GetByIdAsync(teamUpdate.Id, e => e.Employees);

        var employees = await _employeeRepo.GetFilteredAsync(new Expression<Func<Employee, bool>>[] {}, null, null);

        _mapper.Map(teamUpdate, x);

        x.Employees = employees;

        _teamRepo.UpdateAsync(x);

        await _teamRepo.SaveChangesAsync();



    }
}
