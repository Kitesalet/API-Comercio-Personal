using Common.DTOs.AddressDto;
using Common.DTOs.JobDto;
using Common.DTOs.TeamDto;
using Common.Model;

namespace Common.DTOs.EmployeeDto
{
    public class EmployeeGet
    {

        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public AddressGet Address { get; set; }

        public JobGet Job { get; set; }

        public List<TeamGet> Teams { get; set; }


    }
}