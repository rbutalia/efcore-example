﻿
using System;
using System.Collections.Generic;

namespace ex1.Domain
{
    public class MenuItem
    {
        public MenuItem()
        {
            this.OrderDetails = new List<OrderDetail>();
        }
        public int MenuItemID { get; set; }
        public int MenuID { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public virtual Menu Menu { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}