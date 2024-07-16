using Bulky.DataAccess.Repository;
using Calendar.DataAccess.Repository.IRepository;
using Calendar.Models;
using Newtonsoft.Json.Linq;
using System.Linq.Expressions;

namespace Calendar.BLL
{
    public static class EventBLLHandler
    {
        public static IEnumerable<Event> GetEventList(IUnitOfWork unitOfWork)
        {
            return unitOfWork.Event.GetAll();
        }

        public static Event GetEvent(IUnitOfWork unitOfWork, Expression<Func<Event, bool>> filter, string? includeProperties = null)
        {
            return unitOfWork.Event.Get(filter, includeProperties);
        }

        public static void AddEvent(IUnitOfWork unitOfWork, Event value)
        {
            unitOfWork.Event.Add(value);
            unitOfWork.Save();
        }

        public static void UpdateEvent(IUnitOfWork unitOfWork, Event value)
        {
            unitOfWork.Event.Update(value);
            unitOfWork.Save();
        }

        public static void Delete(IUnitOfWork unitOfWork, Event value)
        {
            unitOfWork.Event.Remove(value);
            unitOfWork.Save();
        }

    }
}
