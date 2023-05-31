using Common.Model;

namespace Common.DTOs.EmployeeDto;

public class EmployeeCreate
{

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int AddressId { get; set; }

    public int JobId { get; set; }

    //public List<int> TeamsId { get; set; }



}