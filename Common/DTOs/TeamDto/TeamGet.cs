using Common.DTOs.EmployeeDto;

namespace Common.DTOs;

public class TeamGet
{


public int Id { get; set; }

public string Name { get; set; }

public List<EmployeeList> Employees { get; set; }    


}