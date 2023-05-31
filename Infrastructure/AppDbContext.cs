using Common.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure;

public class AppDbContext : IdentityDbContext<IdentityUser, IdentityRole,string>
{

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {



    }

    public DbSet<Employee> Employees { get; set; }

    public DbSet<Job> Jobs { get; set; }    

    public DbSet<Address> Addresses { get; set; }

    public DbSet<Team> Teams { get; set; }  

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseSqlServer("server = DESKTOP-DAJFN0S; database = abombadoDb; Integrated Security = true; TrustServerCertificate = true");

        base.OnConfiguring(optionsBuilder);
    }

   

}
