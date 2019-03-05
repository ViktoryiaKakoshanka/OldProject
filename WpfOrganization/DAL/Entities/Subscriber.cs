using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WpfOrganization.DAL.Entities
{
    public class Subscriber
    {
        [Key]
        public int NumberOfContract { get; set; }
        public DateTime ContractDate { get; set; }
        
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }

        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string SecondMobilePhone { get; set; }

        public int? RelationshipTypeId { get; set; }
        public virtual ICollection<RelationshipType> RelationshipTypes { get; set; }

        public int? CityId { get; set; }
        public City City { get; set; }

        public int? StreetId { get; set; }
        public Street Street { get; set; }

        public string StreetNumber { get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }
    }
}
