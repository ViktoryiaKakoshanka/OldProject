using System;
using CabelVestaTV.Core.GenericData;

namespace CabelVestaTV.Core.Models
{
    public class OrderOnCableTV
    {
        public int Id { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime EstimatedCompletionDate { get; set; }
        public DateTime ExecutionDate { get; set; }
        public DateTime CallbackDate { get; set; }
        public OrderStatus Status { get; set; }
        
        public Subscriber Subscriber { get; set; }
        public string UserLocation { get; set; }
        public string PhoneNumber { get; set; }
        public string Remark { get; set; }

        public CableTVProblem Problem { get; set; }
        public string NonStandardProblem { get; set; }

        public Master Master { get; set; }

        public bool IsCollectiveOrder { get; set; }

    }
}
