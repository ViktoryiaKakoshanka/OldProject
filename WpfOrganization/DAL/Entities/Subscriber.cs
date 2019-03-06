using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfOrganization.DAL.Entities
{
    public class Subscriber
    {
        public int Id { get; set; }
        
        [Index(IsUnique = true)]
        public int NumberOfContract { get; set; }
        public DateTime ContractDate { get; set; }

        public FullName FullName { get; set; }

        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string SecondMobilePhone { get; set; }

        public int? RelationshipTypeId { get; set; }
        public RelationshipType RelationshipType { get; set; }

        public Address Address { get; set; }

        public virtual ICollection<SubscriberRelationship> RelationshipHistory { get; set; }
    }
}