using Bulky.DataAccess.Repository.IRepository;
using Calendar.DataAccess.Data;
using Calendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
