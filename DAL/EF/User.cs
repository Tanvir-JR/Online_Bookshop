//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DAL.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.BookStores = new HashSet<BookStore>();
            this.Tokens = new HashSet<Token>();
        }
    
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public int roleId { get; set; }
        public string address { get; set; }
    
        public virtual ICollection<BookStore> BookStores { get; set; }
        public virtual Report Report { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Token> Tokens { get; set; }
    }
}