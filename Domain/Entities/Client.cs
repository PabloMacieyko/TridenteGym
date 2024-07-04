
namespace Domain.Entities

{
    public class Client : User
    {
        public ICollection<Activity> Activities { get; set; } = new List<Activity>();

        public void EnrollActivity(Activity activity)
        {
            Activities.Add(activity);
        }
    }
}
