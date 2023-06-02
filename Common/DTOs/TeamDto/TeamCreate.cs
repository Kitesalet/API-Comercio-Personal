using Common.Model;

namespace Common.DTOs.TeamDto;

public class TeamCreate
{


    public string Name { get; set; }

    public List<int> Employees { get; set; }

}