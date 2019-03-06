using System;

namespace WpfOrganization.DAL.Entities
{
    public class SubscriberRelationship
    {
        public int Id { get; set; }
        public DateTime RelationshipDate { get; set; }

        public int SubscriberId { get; set; }
        public Subscriber Subscriber { get; set; }

        public int RelationshipId { get; set; }
        public RelationshipType RelationshipType { get; set; }
    }
}
