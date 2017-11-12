
using System;

namespace ex1.Domain
{
    public class WorkflowStep
    {
        public int WorkflowStepID { get; set; }
        public int CompanyID { get; set; }
        public string StepName { get; set; }
        public string Description { get; set; }
        public string RegularExpression { get; set; }
        public virtual Company Company { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
