using ex1.Domain.Relationships;
using System;
using System.Collections.Generic;

namespace ex1.Domain
{
    public class Category
    {
        //public Category()
        //{
        //    this.ProductCategories = new List<Product>();
        //}

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public byte[] Picture { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
