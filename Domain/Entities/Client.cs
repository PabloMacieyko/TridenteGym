
namespace Domain.Entities

{
    public class Client : User
    {
        public IList<Activity> Activities { get; set; } = [];
    }
}
