using System;
using WpfOrganization.GenericData;

namespace WpfOrganization.BLL.DTO
{
    public class SubscriberDTO
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

        public RelationshipType RelationshipType { get; set; }

        public int? CityId { get; set; }
        public CityDTO City { get; set; }

        public int? StreetId { get; set; }
        public StreetDTO Street { get; set; }

        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }
    }
}