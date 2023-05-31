using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DTOs.AddressDto;
using Common.DTOs.JobDto;

namespace Common.Interfaces;

public interface IJobService
{

    public Task<int> JobCreateAsync(JobCreate jobCreate);

    public Task<JobGet> JobGetIdAsync(int id);

    public Task<List<JobGet>> JobGetAllAsync();

    public Task JobUpdate(JobUpdate jobUpdate);

    public Task JobDelete(JobDelete jobDelete);
    Task CreateJob(AddressCreate entity);
}
