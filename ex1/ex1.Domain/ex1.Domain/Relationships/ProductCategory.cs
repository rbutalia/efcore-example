using System;
using System.Collections.Generic;
using System.Text;

namespace ex1.Domain.Relationships
{
    public class ProductCategory
    {
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public Product Product { get; set; }
        public Category Category { get; set; }
    }
}
