using Common.Model;

namespace Common.DTOs.EmployeeDto
{
    public class EmployeeUpdate
    {

        public int Id { get; set; } 
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int AddressId { get; set; }

        public int JobId { get; set; }

        public List<int> Teams { get; set; }


    }
}