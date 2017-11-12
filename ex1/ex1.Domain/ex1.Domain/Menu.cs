
using System;
using System.Collections.Generic;

namespace ex1.Domain
{
    public class Menu
    {
        public Menu()
        {
            this.MenuItems = new List<MenuItem>();
        }
        public int MenuID { get; set; }
        public string MenuName { get; set; }
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<MenuItem> MenuItems { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
