using Domain.Entities;

namespace Application.Interfaces
{
    public interface IActivityService
    {
        public Activity Add(Activity activity);

        public Activity Get(int id);

        public ICollection<Activity> GetAll();

        public Activity Update(Activity activity);

        public void Delete(int id);
    }
}
