using Common.DTOs.AddressDto;
using Common.DTOs.JobDto;
using Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {

        private readonly IJobService _addressService;

        //Ctor

        public JobController(IJobService addressService)
        {
            _addressService = addressService;
        }

        //Create

        [HttpPost]
        [Route("Create")]

        public async Task<IActionResult> PostAddress(JobCreate entity)
        {
            var id = await _addressService.JobCreateAsync(entity);

            return Ok(id);
        }


        //GetId

        [HttpGet]
        [Route("GetId/{id}")]
        public async Task<IActionResult> GetAddressId(int id)
        {

            _addressService.JobGetIdAsync(id);

            return Ok();
        }

        //GetAll

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAddresses()
        {
            _addressService.JobGetAllAsync();
            return Ok();
        }

        //Update

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> UpdateAddress(JobUpdate addressUpdate)
        {
            _addressService.JobUpdate(addressUpdate);

            return Ok();
        }


        //Delete

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteAddress(JobDelete addressDelete)
        {
            _addressService.JobDelete(addressDelete);
            return Ok();
        }

    }
}
