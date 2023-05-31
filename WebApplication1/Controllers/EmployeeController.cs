using Common.DTOs.EmployeeDto;
using Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _service;

    public EmployeeController(IEmployeeService employeeService)
    {
        _service = employeeService;
    }


    [HttpPost]
    [Route("Create")]

    public async Task<IActionResult> Post(EmployeeCreate entity)
    {

       int x = await _service.CreateEmployeeAsync(entity);

        return Ok(x);
    }

    [HttpGet]
    [Route("Getall")]

    public async Task<IActionResult> GetAllFiltered([FromQuery]EmployeeFiltered entity)
    {

        var x = await _service.GetEmployeesFiltered(entity);

        return Ok(x);
    }

    [HttpGet]
    [Route("Get/{id}")]

    public async Task<IActionResult> GetId(int id)
    {

        var x = await _service.GetEmployeeByIdAsync(id);

        return Ok(x);
    }

    [HttpPost]
    [Route("Update")]
    public async Task<IActionResult> Update(EmployeeUpdate entity)
    {
        await _service.UpdateEmployee(entity);

        var x = await _service.GetEmployeeByIdAsync(entity.Id);

        return Ok(x);
    }

    [HttpDelete]
    [Route("Delete")]

    public async Task<IActionResult> Delete(EmployeeDelete entity)
    {
        await _service.DeleteEmployee(entity);

        return Ok("Se ha borrado la entidad");
    }

}
