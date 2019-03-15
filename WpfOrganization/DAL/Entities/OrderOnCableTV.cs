using System;
using System.ComponentModel.DataAnnotations.Schema;
using WpfOrganization.BLL.DTO;
using WpfOrganization.GenericData;

namespace WpfOrganization.DAL.Entities
{
    public class OrderOnCableTV
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public int SubscriberId { get; set; }
        public virtual Subscriber Subscriber { get; set; }

        public string UserLocation { get; set; }
        public string PhoneNumber { get; set; }
        public string Remark { get; set; }

        public int? CableTVProblemId { get; set; }
        public virtual CableTVProblem Problem { get; set; }
        public string NonStandardProblem { get; set; }

        public int? MasterId { get; set; }
        public virtual Master Master { get; set; }

        public OrderStatus OrderStatus { get; set; }
        public DateTime? ExecutionDate { get; set; }
        public DateTime? CallbackDate { get; set; }

        public bool IsCollectiveOrder { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime EstimatedCompletionDate { get; set; }
    }
}
