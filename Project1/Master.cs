namespace Project1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Master
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Master()
        {
            OrderOnCableTVs = new HashSet<OrderOnCableTV>();
            OrderRepairAndRestructions = new HashSet<OrderRepairAndRestruction>();
            OrderRepairAndRestructions1 = new HashSet<OrderRepairAndRestruction>();
            Cities = new HashSet<City>();
        }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderOnCableTV> OrderOnCableTVs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderRepairAndRestruction> OrderRepairAndRestructions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderRepairAndRestruction> OrderRepairAndRestructions1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<City> Cities { get; set; }
    }
}
