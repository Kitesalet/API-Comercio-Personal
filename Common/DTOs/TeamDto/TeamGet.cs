using Common.DTOs.EmployeeDto;
using Common.Model;

namespace Common.DTOs.TeamDto;

public class TeamGet
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<EmployeeGet> Employees { get; set; }

}