using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class BookStoreRepo : IRepo <BookStore, int, bool>
    {
        BookshopEntities db;
        public BookStoreRepo()
        {
            db = new BookshopEntities();   
        }
        public bool Add(BookStore obj)
        {
            db.BookStores.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var bookstore = db.BookStores.Find(id);
            db.BookStores.Remove(bookstore);
            return db.SaveChanges() > 0;
        }

        public List<BookStore> Get()
        {
            return db.BookStores.ToList();
        }

        public BookStore Get(int id)
        {
            return db.BookStores.Find(id);
        }


        public bool Update(BookStore obj)
        {
            var ext = db.BookStores.Find(obj.id);
            db.Entry(ext).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }


    }
}
