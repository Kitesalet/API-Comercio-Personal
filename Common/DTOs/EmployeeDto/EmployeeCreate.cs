using Common.Model;

namespace Common.DTOs.EmployeeDto
{
    public class EmployeeCreate
    {

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int AddressId { get; set; }
        public int JobId { get; set; }
        public List<int> Teams { get; set; }

    }
}