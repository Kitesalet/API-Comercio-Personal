using Common.DTOs.AddressDto;
using Common.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {


        private readonly IAddressService _addressService;

        //Ctor

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        //Create

        [HttpPost]
        [Route("Create")]

        public async Task<IActionResult> PostAddress(AddressCreate entity)
        {
           var id = await _addressService.CreateAddress(entity);

            return Ok(id);
        }


        //GetId

        [HttpGet]
        [Route("GetId/{id}")]
        public async Task<IActionResult> GetAddressId(int id)
        {
            await _addressService.GetAddressId(id);

            return null;
        }

        //GetAll

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAddresses()
        {
            var x = await _addressService.GetAddresses();

            return Ok(x);
        }

        //Update

        [HttpPut]
        [Route("Update")]
        public async Task UpdateAddress(AddressUpdate addressUpdate)
        {

            await _addressService.UpdateAddress(addressUpdate);

           
        }


        //Delete

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteAddress(AddressDelete addressDelete)
        {
            await _addressService.DeleteAddress(addressDelete);

            return Ok();
        }


    }

}
