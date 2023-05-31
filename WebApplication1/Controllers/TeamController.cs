using Common.DTOs.TeamDto;
using Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService _service;

        public TeamController(ITeamService teamService)
        {
        
            _service = teamService;
        
        }


        [HttpPost]
        [Route("Create")]

        public async Task<IActionResult> Post(TeamCreate entity)
        {

            var response = await _service.AddTeamAsync(entity);

            return Ok(response);

        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllFiltered([FromQuery] TeamFiltered filter)
        {

            var response = await _service.GetTeamListAsync(filter);

            return Ok(response);

        }

        [HttpGet]
        [Route("GetId/{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var response = await _service.GetTeamByIdAsync(id);

            return Ok(response);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(TeamUpdate entity)
        {
             await _service.UpdateTeam(entity);

            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(TeamDelete entity)
        {
            await _service.DeleteTeam(entity);

            return Ok();
        }


    }
}
