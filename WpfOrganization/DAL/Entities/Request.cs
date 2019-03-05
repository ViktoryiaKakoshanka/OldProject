using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfOrganization.DAL.Entities
{
    public class Request
    {
        public int Id { get; set; }

        [ForeignKey("Subscriber")]
        public int NumberOfContract { get; set; }
        public Subscriber Subscriber { get; set; }

        public string UserLocation { get; set; }
        public string PhoneNumber { get; set; }
        public string Remark { get; set; }

        public int? CableTVRepairProblemId { get; set; }
        public CableTVRepairProblem Problem { get; set; }
        public string NonStandardProblem { get; set; }

        public int? MasterId { get; set; }
        public Master Master { get; set; }

        public EecutionStatus EecutionStatus { get; set; }
        public DateTime DateOfExecution { get; set; }
        public DateTime DateOfCallback { get; set; }

        public bool IsCollectiveRequest { get; set; }

        public DateTime DateOfCreation { get; set; }
        public DateTime EstimatedCompletionDate { get; set; }
    }
}
