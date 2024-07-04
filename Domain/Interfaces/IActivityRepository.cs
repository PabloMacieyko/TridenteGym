using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IActivityRepository
    {
        public Activity Add(Activity activity);

        public Activity Get(int id);

        public ICollection<Activity> GetAll();

        public Activity Update(Activity activity);

        public void Delete(int id);
    }
}
