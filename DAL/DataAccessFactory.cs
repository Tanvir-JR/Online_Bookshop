using DAL.EF;
using DAL.Interfaces;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<User, int, bool> UserDataAccess()
        {
            return new UserRepo();
        }
        public static IRepo<Role, int, bool> RoleDataAccess()
        {
            return new RoleRepo();
        }
        public static IRepo<Token, string, Token> TokenDataAccess()
        {
            return new TokenRepo();
        }
        public static IRepo<Book, int, bool> BookDataAccess()
        {
            return new BookRepo();
        }
        public static IRepo<BookStore, int, bool> BookStoreDataAccess()
        {
            return new BookStoreRepo(); 
        }
        public static IRepo<Buy, int, bool> BuyDataAccess()
        {
            return new BuyRepo();
        }
        public static IRepo<Language, int, bool> LanguageDataAccess()
        {
            return new LanguageRepo();
        }
        public static IRepo<Report, int, bool> ReportDataAccess()
        {
            return new ReportRepo();
        }
        public static IRepo<Payment, int, bool> PaymentDataAccess()
        {
            return new PaymentRepo();
        }

        public static IRepo<Category, int, Category> CategoryDataAccess()
        {
            return new CategoryRepo();
        }
        public static IAuth AuthDataAccess()
        {
            return new UserRepo();
        }

        
    }
}
