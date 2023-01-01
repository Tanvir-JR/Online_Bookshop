using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class BookRepo: IRepo<Book, int, bool>
    {
        
        BookshopEntities db;
        public BookRepo()
        {
            db = new BookshopEntities();
        }

        public bool Add(Book obj)
        {
            db.Books.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var book = db.Books.Find(id);
            db.Books.Remove(book);
            return db.SaveChanges() > 0;
        }

        public List<Book> Get()
        {
            var data= db.Books.ToList();
            return data;
        }

        public Book Get(int id)
        {
            return db.Books.Find(id);
        }
        public bool Update(Book obj)
        {
            var ext = db.Books.Find(obj.id);
            db.Entry(ext).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
