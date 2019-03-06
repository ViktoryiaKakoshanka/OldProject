using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfOrganization.DAL.Entities
{
    public class OrderRepairAndRestruction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("ResponsibleMaster")]
        public int? ResponsibleMasterId { get; set; }
        public Master ResponsibleMaster { get; set; }

        [ForeignKey("MasterPerformer")]
        public int? MasterPerformerId { get; set; }
        public Master MasterPerformer { get; set; }

        public Address Address { get; set; }

        public string Problem { get; set; }
        public string Remark { get; set; }

        public ExecutionStatus EecutionStatus { get; set; }
        public DateTime DateOfExecution { get; set; }
        public DateTime DateOfCallback { get; set; }

        public DateTime DateOfCreation { get; set; }
        public DateTime EstimatedCompletionDate { get; set; }
    }
}
