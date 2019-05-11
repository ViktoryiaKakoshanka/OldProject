namespace Project1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SubscriberRelationship
    {
        public int Id { get; set; }

        public DateTime RelationshipDate { get; set; }

        public int SubscriberId { get; set; }

        public int RelationshipType { get; set; }

        public virtual Subscriber Subscriber { get; set; }
    }
}
