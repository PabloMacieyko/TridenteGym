
namespace Domain.Entities; 
public class Activity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int CupoMax { get; set; }
    public int CupoDisp {  get; set; }
}
