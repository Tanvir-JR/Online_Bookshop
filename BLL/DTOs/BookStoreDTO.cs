using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class BookStoreDTO
    {
        public int Id { get; set; }
        public string bShopName { get; set;}   
        public string address { get; set;}   
        public int phone { get; set;}   
        public int userId { get; set; }   
    }
}
