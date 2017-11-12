
using ex1.Domain.Relationships;
using System.Collections.Generic;

namespace ex1.Domain
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? SupplierID { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public short? UnitsOnOrder { get; set; }
        public short? ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }
        //public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public Supplier Supplier { get; set; }
    }
}
