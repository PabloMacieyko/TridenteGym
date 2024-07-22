
using System.Diagnostics;

namespace Domain.Entities
{
    public class Client : User
    {
        public ICollection<Activity> EnrolledActivities { get; set; } = new List<Activity>();
    }
}
