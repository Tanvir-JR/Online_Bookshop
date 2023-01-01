using DAL.EF;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class TokenRepo : IRepo<Token, string, Token>
    {
        BookshopEntities db;
        public TokenRepo()
        {
            db = new BookshopEntities();
        }
        public Token Add(Token obj)
        {
            db.Tokens.Add(obj);
            if (db.SaveChanges() > 0) return obj;
            return null;
        }

        public bool Delete(string id)
        {
            var user = db.Tokens.Find(id);
            db.Tokens.Remove(user);
            return db.SaveChanges() > 0;
        }

        public List<Token> Get()
        {
            return db.Tokens.ToList();
        }

        public Token Get(string id)
        {
            return db.Tokens.Find(db.Tokens.Find(id));
        }

        public bool Update(Token obj)
        {
            var ext = db.Tokens.Find(obj.id);
            db.Entry(ext).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
    }
}
