using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class BookDTO
    {
        public int id { get; set; }
        public string name { get; set; }    
        public string author { get; set; }
        public int languageId { get; set; } 
        public int quantity { get; set; }
        public int amount { get; set; }
        public string bShopName { get; set; }   
        public string description { get; set; } 
    }
}
