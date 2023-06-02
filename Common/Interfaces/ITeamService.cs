using Common.DTOs.TeamDto;
using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces;

public interface ITeamService
{

    public Task<int> CreateTeamAsync(TeamCreate teamCreate);

    public Task<TeamGet> GetTeamIdAsync(int id);

    public Task<List<TeamGet>> GetTeamsAsync();

    public Task DeleteTeam(TeamDelete teamDelete);

    public Task UpdateTeam(TeamUpdate teamUpdate);

}
