using System;
using WpfOrganization.BLL.DTO;
using WpfOrganization.BLL.Interfaces;
using WpfOrganization.GenericData;

namespace WpfOrganization.BLL.Entities
{
    public class OrderOnCableTV //: IOrderService
    {
        public int Id { get; set; }

        public int SubscriberId { get; set; }
        public virtual Subscriber Subscriber { get; set; }

        public string UserLocation { get; set; }
        public string PhoneNumber { get; set; }
        public string Remark { get; set; }

        public int? CableTVProblemId { get; set; }
        //public virtual CableTVProblem Problem { get; set; }
        public string NonStandardProblem { get; set; }

        public int? MasterId { get; set; }
        //public virtual Master Master { get; set; }

        public OrderStatus OrderStatus { get; set; }
        public DateTime? ExecutionDate { get; set; }
        public DateTime? CallbackDate { get; set; }

        public bool IsCollectiveOrder { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime EstimatedCompletionDate { get; set; }
    }
}
