using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfOrganization.DAL.Entities
{
    public class RepairAndRestructionRequest
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Master")]
        public int ResponsibleMasterId { get; set; }
        public Master ResponsibleMaster { get; set; }

        [ForeignKey("Master")]
        public int MasterPerformerId { get; set; }
        public Master MasterPerformer { get; set; }

        public int? CityId { get; set; }
        public City City { get; set; }

        public int? StreetId { get; set; }
        public Street Street { get; set; }

        public string StreetNumber { get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }

        public string Problem { get; set; }
        public string Remark { get; set; }

        public EecutionStatus EecutionStatus { get; set; }
        public DateTime DateOfExecution { get; set; }
        public DateTime DateOfCallback { get; set; }

        public DateTime DateOfCreation { get; set; }
        public DateTime EstimatedCompletionDate { get; set; }
    }
}
