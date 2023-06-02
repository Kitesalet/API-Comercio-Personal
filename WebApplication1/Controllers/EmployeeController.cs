using Common.DTOs.EmployeeDto;
using Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {


        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            
            _service = service;

        }


        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Post(EmployeeCreate entity)
        {

           int id = await _service.CreateEmployeeAsync(entity);

            return Ok(id);

        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll(EmployeeFilters filter)
        {

            var entity = await _service.GetEmployeeFiltered(filter);

            return Ok(entity);

        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> GetId(int id)
        {

            var enty = await _service.GetEmployeeByIdAsync(id);

            return Ok(enty);

        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(EmployeeUpdate filter)
        {

            await _service.UpdateEmployeeAsync(filter);

            return Ok();

        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(EmployeeDelete filter)
        {

            await _service.DeleteEmployee(filter);

            return Ok();

        }

    }
}
