using Common.DTOs.TeamDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model;

public class Employee : BaseEntity
{

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public Address Address { get; set; }

    public Job Job { get; set; }    

    public List<TeamGet> Teams { get; set; }


}
