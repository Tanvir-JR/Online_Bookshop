using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class UserRepo : IRepo<User, int, bool>, IAuth
    {
        BookshopEntities db;
        public UserRepo()
        {
            db = new BookshopEntities();
        }
        public bool Add(User obj)
        {
            db.Users.Add(obj);
            return db.SaveChanges() > 0;
        }

        public User Authenticate(string username, string password)
        {
            var user = db.Users.FirstOrDefault(
               u =>
               u.username.Equals(username) &
               u.password.Equals(password)
               );
            return user;
        }

        public bool Delete(int id)
        {
            var user = db.Users.Find(id);
            db.Users.Remove(user);
            return db.SaveChanges() > 0;
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public bool Update(User obj)
        {
            /*var data = db.Users.FirstOrDefault(e => e.id == obj.id);
            data.username = obj.username;
            data.password = obj.password;
            data.address = obj.address;
            data.phone = obj.phone;
            data.email = obj.email;
            db.SaveChanges();
            return true;*/

            var ext = db.Users.Find(obj.id);
            db.Entry(ext).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;

        }
    }
}
