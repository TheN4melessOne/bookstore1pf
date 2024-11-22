using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookstore1pf
{
    public class TableBook
    {
        public string title { get; set; }
        public string author { get; set; }
        public string publishingHouse { get; set; }
        public string description { get; set; }
        public string publicationDate { get; set; }

        public int id { get; set; }
        public string price { get; set; }

        public Books parentBook { get; set; }
    }
}
