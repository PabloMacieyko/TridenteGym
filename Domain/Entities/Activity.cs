using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities; 
public class Activity
{
    public int Id { get; set; }

    [Column(TypeName = "nvarchar(100)")]
    public string Name { get; set; }

    [Column(TypeName = "nvarchar(4000)")]
    public string Description { get; set; }

    public double Price { get; set; }

}
