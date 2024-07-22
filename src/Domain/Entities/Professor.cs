namespace Domain.Entities
{
    public class Professor : User
    {
        public ICollection<Activity> AssignedActivities { get; set; } = new List<Activity>();
    }
}