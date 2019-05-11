namespace Project1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserAction
    {
        public int Id { get; set; }

        public DateTime DateOfAction { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
