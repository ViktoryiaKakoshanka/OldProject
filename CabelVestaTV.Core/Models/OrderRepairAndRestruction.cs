using System;
using CabelVestaTV.Core.GenericData;

namespace CabelVestaTV.Core.Models
{
    public class OrderRepairAndRestruction
    {
        public int Id { get; set; }

        public User User { get; set; }
        
        public Master ResponsibleMaster { get; set; }
        
        public Master MasterPerformer { get; set; }

        public Address Address { get; set; }

        public string Problem { get; set; }
        public string Remark { get; set; }

        public OrderStatus Status { get; set; }
        public DateTime ExecutionDate { get; set; }
        public DateTime CallbackDate { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime EstimatedCompletionDate { get; set; }
    }
}
