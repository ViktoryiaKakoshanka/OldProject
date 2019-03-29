using System;
using WpfOrganization.GenericData;

namespace WpfOrganization.BLL.DTO
{
    public class OrderOnCableTVDTO
    {
        public int Id { get; set; }

        public int SubscriberId { get; set; }
        public SubscriberDTO Subscriber { get; set; }

        public string UserLocation { get; set; }
        public string PhoneNumber { get; set; }
        public string Remark { get; set; }

        public int? CableTVProblemId { get; set; }
        public CableTVProblemDTO Problem { get; set; }
        public string NonStandardProblem { get; set; }

        public int? MasterId { get; set; }
        public MasterDTO Master { get; set; }

        public OrderStatus Status { get; set; }
        public DateTime ExecutionDate { get; set; }
        public DateTime CallbackDate { get; set; }

        public bool IsCollectiveOrder { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime EstimatedCompletionDate { get; set; }
    }
}
