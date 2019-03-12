using System;

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

        public int? RelationshipTypeId { get; set; }

        public int? CityId { get; set; }

        public int? StreetId { get; set; }

        public string StreetNumber { get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }
    }
}