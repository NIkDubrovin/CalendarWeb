using Calendar.DataAccess.Repository.IRepository;
using Calendar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.IRepository
{
    public interface IEventRepository : IRepository<Event>
    {
        void Update(Event _event);
    }
}
