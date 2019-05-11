namespace Project1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Subscriber
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Subscriber()
        {
            OrderOnCableTVs = new HashSet<OrderOnCableTV>();
            SubscriberRelationships = new HashSet<SubscriberRelationship>();
        }

        public int Id { get; set; }

        public int NumberOfContract { get; set; }

        public DateTime ContractDate { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string Patronymic { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string SecondMobilePhone { get; set; }

        public int RelationshipType { get; set; }

        public int? CityId { get; set; }

        public int? StreetId { get; set; }

        public string HouseNumber { get; set; }

        public string ApartmentNumber { get; set; }

        public virtual City City { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderOnCableTV> OrderOnCableTVs { get; set; }

        public virtual Street Street { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SubscriberRelationship> SubscriberRelationships { get; set; }
    }
}
