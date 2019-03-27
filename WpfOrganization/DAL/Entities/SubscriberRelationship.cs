using System;
using WpfOrganization.GenericData;

namespace WpfOrganization.DAL.Entities
{
    public class SubscriberRelationship
    {
        public int Id { get; set; }
        public DateTime RelationshipDate { get; set; }

        public int SubscriberId { get; set; }
        public Subscriber Subscriber { get; set; }

        public RelationshipType RelationshipType { get; set; }
    }
}
