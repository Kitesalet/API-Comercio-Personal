using Common.Model;

namespace Common.DTOs.EmployeeDto;

public class EmployeeFilters
{

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Address { get; set; }

    public string? Job { get; set; }

    public List<int>? Teams { get; set; }

}