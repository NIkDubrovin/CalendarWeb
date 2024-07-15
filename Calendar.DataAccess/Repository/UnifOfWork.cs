using Bulky.DataAccess.Repository.IRepository;
using Calendar.DataAccess.Data;
using Calendar.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
	{
		private ApplicationDbContext _db;
		public  ICategoryRepository Category { get; private set; }
		public  IEventRepository    Event { get; private set; }

		public UnitOfWork(ApplicationDbContext db)
		{
			_db = db;
			Category = new CategoryRepository(_db);
            Event = new EventRepository(_db);  
		}

		public void Save()
		{
			_db.SaveChanges();
		}
	}
}
