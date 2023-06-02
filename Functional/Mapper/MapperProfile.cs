using AutoMapper;
using Common.DTOs;
using Common.DTOs.AddressDto;
using Common.DTOs.EmployeeDto;
using Common.DTOs.JobDto;
using Common.DTOs.TeamDto;
using Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional.Mapper;

public class MapperProfile : Profile
{


    public MapperProfile()
    {

        //Address

        CreateMap<AddressCreate, Address>().ForMember(e => e.Id, f => f.Ignore());

        CreateMap<AddressUpdate, Address>();

        CreateMap<Address, AddressGet>();

        //Job

        CreateMap<JobCreate, Job>().ForMember(e => e.Id, f => f.Ignore());

        CreateMap<JobUpdate, Job>();

        CreateMap<Job, JobGet>();

        //Employee

        CreateMap<EmployeeCreate, Employee>().ForMember(e => e.Id, e => e.Ignore()).ForMember(e => e.Teams, e=>e.Ignore());
        CreateMap<EmployeeUpdate, Employee>().ForMember(e => e.Address, f => f.Ignore()).ForMember(e => e.Job, f => f.Ignore()).ForMember(e => e.Teams, f => f.Ignore());
        CreateMap<Employee, EmployeeGet>();
        CreateMap<Employee, EmployeeGetSimple>();



        //Team

        CreateMap<TeamCreate, Team>().ForMember(e => e.Id, e => e.Ignore()).ForMember(e => e.Employees, e => e.Ignore());
        CreateMap<TeamUpdate, Team>().ForMember(e=> e.Employees, e => e.Ignore());
        CreateMap<Team, TeamGet>();


    }



}
