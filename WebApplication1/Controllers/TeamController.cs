using Common.DTOs.EmployeeDto;
using Common.DTOs.TeamDto;
using Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

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

        int id = await _service.CreateTeamAsync(entity);

        return Ok(id);

    }

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAll()
    {

        var entity = await _service.GetTeamsAsync();

        return Ok(entity);

    }

    [HttpGet]
    [Route("Get/{id}")]
    public async Task<IActionResult> GetId(int id)
    {

        var enty = await _service.GetTeamIdAsync(id);

        return Ok(enty);

    }

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> Update(TeamUpdate filter)
    {

        await _service.UpdateTeam(filter);

        return Ok();

    }

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> Delete(TeamDelete filter)
    {

        await _service.DeleteTeam(filter);

        return Ok();

    }






}
