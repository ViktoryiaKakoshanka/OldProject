namespace Project1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            OrderRepairAndRestructions = new HashSet<OrderRepairAndRestruction>();
            UserActions = new HashSet<UserAction>();
        }

        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public bool LoggedIn { get; set; }

        public byte AdminRole { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderRepairAndRestruction> OrderRepairAndRestructions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserAction> UserActions { get; set; }
    }
}
