using System;

namespace WpfOrganization.BLL.DTO
{
    public class SubscriberRelationshipDTO
    {
        public int Id { get; set; }
        public DateTime RelationshipDate { get; set; }

        public int SubscriberId { get; set; }

        public int RelationshipTypeId { get; set; }
    }
}
