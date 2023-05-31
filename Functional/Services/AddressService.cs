using AutoMapper;
using Common.DTOs.AddressDto;
using Common.Interfaces;
using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional.Services
{
    public class AddressService : IAddressService
    {
        private IGenericRepository<Address> _addressRepo;
        private IMapper _mapper;

        public AddressService(IGenericRepository<Address> addressRepo, IMapper mapper)
        {
        
            _addressRepo = addressRepo;

            this._mapper = mapper;


        }


        public async Task<int> CreateAddress(AddressCreate addressCreate)
        {
            
            var entity = _mapper.Map<Address>(addressCreate);

            await _addressRepo.AddAsync(entity);

            await _addressRepo.SaveChangesAsync();

            return entity.Id;

        }

        public async Task DeleteAddress(AddressDelete addressDelete)
        {

            var entity = await _addressRepo.GetByIdAsync(addressDelete.Id);

            _addressRepo.DeleteAsync(entity);

            await _addressRepo.SaveChangesAsync();


        }

        public async Task<List<AddressGet>> GetAddresses()
        {

            var list = await _addressRepo.GetAsync(null, null);

            var newList = _mapper.Map<List<AddressGet>>(list);

            return newList;

        }

        public async Task<AddressGet> GetAddressId(int id)
        {
            
            var entity = await _addressRepo.GetByIdAsync(id);

            var mapper = _mapper.Map<AddressGet>(entity);

            return mapper;

        }

        public async Task UpdateAddress(AddressUpdate addressUpdate)
        {

            var updater = _mapper.Map<Address>(addressUpdate);

             _addressRepo.UpdateAsync(updater);

            await _addressRepo.SaveChangesAsync();


        }
    }
}
