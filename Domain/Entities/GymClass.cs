using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities; //preguntar que significa esto y porque algunos tienen llaves

public class GymClass
{
    // va con decoradores?
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public float Price { get; set; }

}
