using AutoMapper;
using Common.DTOs.AddressDto;
using Common.DTOs.JobDto;
using Common.Interfaces;
using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional.Services
{
    internal class JobService : IJobService
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Job> _jobRepo;

        public JobService(IMapper mapper, IGenericRepository<Job> jobRepo)
        {

            _mapper = mapper;
            _jobRepo = jobRepo;

        }


        public async Task<int> JobCreateAsync(JobCreate jobCreate)
        {
            
            var entity = _mapper.Map<Job>(jobCreate);

            await _jobRepo.AddAsync(entity);

            await _jobRepo.SaveChangesAsync();

            return entity.Id;

        }

        public async Task JobDelete(JobDelete jobDelete)
        {
            var entity = await _jobRepo.GetByIdAsync(jobDelete.Id);

            _jobRepo.DeleteAsync(entity);

            await _jobRepo.SaveChangesAsync();


        }

        public async Task<List<JobGet>> JobGetAllAsync()
        {

            var entityList = await _jobRepo.GetAsync(null,null);

            return _mapper.Map<List<JobGet>>(entityList);


        }

        public async Task<JobGet> JobGetIdAsync(int id)
        {
            
            var entity = await _jobRepo.GetByIdAsync(id);

            return _mapper.Map<JobGet>(entity);

        }

        public async Task JobUpdate(JobUpdate jobUpdate)
        {
            var entity = await _jobRepo.GetByIdAsync(jobUpdate.Id);

            _jobRepo.UpdateAsync(entity);

            await _jobRepo.SaveChangesAsync();
        }
    }
}
