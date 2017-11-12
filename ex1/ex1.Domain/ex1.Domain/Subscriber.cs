
using System;

namespace ex1.Domain
{
    public class Subscriber
    {
        public int SubscriberID { get; set; }
        public int CustomerId { get; set; }
        public String PhoneNumber { get; set; }
        public bool Subscribed { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
