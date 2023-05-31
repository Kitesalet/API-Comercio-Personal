using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTOs.AddressDto;

namespace Common.Interfaces;

public interface IAddressService
{

    //Create

    public Task<int> CreateAddress(AddressCreate addressCreate);

    //Retrieve Lista

    public Task<List<AddressGet>> GetAddresses();

    //Retrieve Id

    public Task<AddressGet> GetAddressId(int id);

    //Update

    public Task UpdateAddress(AddressUpdate addressUpdate);

    //Delete

    public Task DeleteAddress(AddressDelete addressDelete);

}
