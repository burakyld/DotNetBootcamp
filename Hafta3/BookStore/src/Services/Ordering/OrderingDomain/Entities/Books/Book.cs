using OrderingDomain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderingDomain.Entities.Books
{
    public class Book : EntityBase
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public int Page { get; set; }

        public string Author { get; set; }

        public decimal Price { get; set; }

    }
}
