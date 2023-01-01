using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TokenDTO
    {
        public int id { get; set; }
        public string tkey { get; set; }
        public System.DateTime creationTime { get; set; }
        public Nullable<System.DateTime> expirationTime { get; set; }
        public int userId { get; set; }
    }
}
