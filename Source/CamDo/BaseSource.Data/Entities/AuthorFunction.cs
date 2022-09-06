using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSource.Data.Entities
{
    public class AuthorFunction
    {
        public int Id { get; set; }
        public string FuncCode { get; set; }
        public string FuncName { get; set; }
        public int Level { get; set; }
        public int SubFunc { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
