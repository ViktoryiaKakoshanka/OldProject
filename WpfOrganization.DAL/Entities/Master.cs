using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfOrganization.DAL.Entities
{
    public class Master
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }

        public string WorkPhone { get; set; }
        public string SecondWorkPhone { get; set; }

        public string HomePhone { get; set; }
        public string SecondHomePhone { get; set; }

        public string MobilePhone { get; set; }
        public string SecondMobilePhone { get; set; }

        public bool Brigade { get; set; }

        public virtual ICollection<City> Cities { get; set; }
        public virtual ICollection<OrderOnCableTV> OrdersOnCableTv { get; set; }

        [InverseProperty("ResponsibleMaster")]
        public virtual ICollection<OrderRepairAndRestruction> OrdersRepairAndRestructionAccountableToMaster { get; set; }

        [InverseProperty("MasterPerformer")]
        public virtual ICollection<OrderRepairAndRestruction> ComplitedOrderRepairAndRestructionListByMaster { get; set; }

        public Master()
        {
            Cities = new List<City>();
            OrdersRepairAndRestructionAccountableToMaster = new List<OrderRepairAndRestruction>();
            ComplitedOrderRepairAndRestructionListByMaster = new List<OrderRepairAndRestruction>();
        }
    }
}
