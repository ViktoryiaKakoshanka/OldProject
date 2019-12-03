namespace CabelVestaTV.Core.Models
{
    public class Address
    {
        public City City { get; set; }
        public Street Street { get; set; }
        public string StreetNumber { get; set; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }
    }
}
