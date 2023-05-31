using Common.DTOs.AddressDto;
using Common.DTOs.JobDto;

namespace Common.DTOs.EmployeeDto;

public class EmployeeFiltered
{


    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Address { get; set; }

    public string? Job { get; set; }

    public int? skip { get; set; }

    public int? take { get; set; }

}