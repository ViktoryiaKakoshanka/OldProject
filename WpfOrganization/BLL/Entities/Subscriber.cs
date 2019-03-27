using System;
using System.Collections.Generic;
using WpfOrganization.GenericData;

namespace WpfOrganization.BLL.Entities
{
    class Subscriber
    {
        public int Id { get; set; }

        public int NumberOfContract { get; set; }
        public DateTime ContractDate { get; set; }

        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }

        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string SecondMobilePhone { get; set; }

        public virtual RelationshipType RelationshipType { get; set; }

        public int? CityId { get; set; }
        //public virtual City City { get; set; }

        public int? StreetId { get; set; }
       // public virtual Street Street { get; set; }

        public string StreetNumber { get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }

        //public virtual ICollection<SubscriberRelationship> RelationshipHistory { get; set; }
        //public virtual ICollection<OrderOnCableTV> OrderHistory { get; set; }


    }
}
