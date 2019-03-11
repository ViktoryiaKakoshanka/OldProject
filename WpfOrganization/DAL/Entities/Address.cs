using System.ComponentModel.DataAnnotations.Schema;

namespace WpfOrganization.DAL.Entities
{
    [ComplexType]
    public class Address
    {
        public string StreetNumber { get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }
    }
}
