using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model;

public class Address : BaseEntity
{

    public string Street { get; set; }

    public string City { get; set; }    

    public string Zip { get; set; }

    public string? Phone { get; set; }




}
