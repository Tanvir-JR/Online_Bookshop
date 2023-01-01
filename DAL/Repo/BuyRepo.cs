using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class BuyRepo : IRepo<Buy, int, bool>
    {
        BookshopEntities db;

        public BuyRepo()
        {
            db = new BookshopEntities();   
        }

        public bool Add(Buy obj)
        {
            db.Buys.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var buy = db.Buys.Find(id);
            db.Buys.Remove(buy);
            return db.SaveChanges() > 0;
        }

        public List<Buy> Get()
        {
            var data = db.Buys.ToList();
            return data;
        }

        public Buy Get(int id)
        {
            return db.Buys.Find(id);
        }

        public bool Update(Buy obj)
        {
            var ext = db.Buys.Find(obj.id);
            db.Entry(ext).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
