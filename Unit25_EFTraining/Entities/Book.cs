using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit25_EFTraining.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public DateTime Created { get; set; }

        //внешний ключ 
        public int UserId { get; set; } = 0;
    }
}
