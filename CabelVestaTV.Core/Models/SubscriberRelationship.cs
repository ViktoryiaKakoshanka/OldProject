using System;

namespace CabelVestaTV.Core.Models
{
    public class SubscriberRelationship
    {
        public int Id { get; set; }
        public DateTime RelationshipDate { get; set; }

        public int SubscriberId { get; set; }

        public int RelationshipTypeId { get; set; }
    }
}