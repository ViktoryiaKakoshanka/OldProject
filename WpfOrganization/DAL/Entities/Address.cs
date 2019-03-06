using System.ComponentModel.DataAnnotations.Schema;

namespace WpfOrganization.DAL.Entities
{
    [ComplexType]
    public class Address
    {
        public int? CityId { get; set; }
        public City City { get; set; }

        public int? StreetId { get; set; }
        public Street Street { get; set; }

        public string StreetNumber { get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }
    }
}
