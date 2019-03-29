using WpfOrganization.BLL.DTO;

namespace WpfOrganization.Model
{
    public class Subscriber
    {
        public int Id { get; set; }
        public int NumberOfContract { get; }
        public string Relationship { get; }
        public string Surname { get; }
        public string Name { get; }
        public string Patronymic { get; }
        public string City { get; }
        public string Street { get; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }

        public Subscriber(SubscriberDTO subscriberDTO)
        {
            Id = subscriberDTO.Id;
            NumberOfContract = subscriberDTO.NumberOfContract;
            Relationship = subscriberDTO.RelationshipType.ToString();
            Surname = subscriberDTO.Surname;
            Name = subscriberDTO.Name;
            Patronymic = subscriberDTO.Patronymic;
            City = subscriberDTO.City?.CityName;
            Street = subscriberDTO.Street.StreetName;
            HouseNumber = subscriberDTO.HouseNumber;
            ApartmentNumber = subscriberDTO.ApartmentNumber;
        }
    }
}
