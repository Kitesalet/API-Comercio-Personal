using Common.Interfaces;
using Functional.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional.Mapper;

public class MapperServiceDI
{

    public static void RegisterService(IServiceCollection services)
    {

        //Inyeccion del mapper

        services.AddAutoMapper(typeof(MapperProfile));

        //añadir los scopes de los DTOs con las interfaces


        services.AddScoped<IAddressService,AddressService>();
        services.AddScoped<IJobService,JobService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<ITeamService,TeamService>();

    }


}
