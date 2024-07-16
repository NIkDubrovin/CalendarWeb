using Bulky.DataAccess.Repository.IRepository;
using Calendar.DataAccess.Data;
using Calendar.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        private ApplicationDbContext _db;
        public EventRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Event ev)
        {
            _db.Events.Update(ev);
        }

        public IEnumerable<Event> GetEvents()
        {
            return _db.Events.FromSql($"EXEC get_all_event_ordered_by_id").ToList();
        }
    }
}
