using System;
using WpfOrganization.GenericData;

namespace WpfOrganization.BLL.DTO
{
    public class OrderRepairAndRestructionDTO
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int? ResponsibleMasterId { get; set; }

        public int? MasterPerformerId { get; set; }

        public int? CityId { get; set; }
        public int? StreetId { get; set; }
        public string StreetNumber { get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }

        public string Problem { get; set; }
        public string Remark { get; set; }

        public OrderStatus Status { get; set; }
        public DateTime DateOfExecution { get; set; }
        public DateTime DateOfCallback { get; set; }

        public DateTime DateOfCreation { get; set; }
        public DateTime EstimatedCompletionDate { get; set; }
    }
}
