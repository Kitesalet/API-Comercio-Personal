using Common.DTOs;
using Common.DTOs.TeamDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface ITeamService
    {

        public Task<int> AddTeamAsync(TeamCreate teamAdd);

        public Task<TeamGet> GetTeamByIdAsync(int id);

        public Task<List<TeamGet>> GetTeamListAsync(TeamFiltered filter);

        public Task UpdateTeam(TeamUpdate teamUpdate);

        public Task DeleteTeam(TeamDelete teamDelete);


    }
}
