using Common.Model;

namespace Common.DTOs.TeamDto
{
    public class TeamCreate
    {

        public int Name { get; set; }
        public List<int> Employees { get; set; }

    }
}