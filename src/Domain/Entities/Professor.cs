namespace Domain.Entities
{
    public class Professor : User
    {
        // Propiedad de navegación para las actividades que enseña
        public ICollection<Activity> Activities { get; set; } = new List<Activity>();
    }
}