using System.Collections.Generic;
using WpfOrganization.BLL.DTO;

namespace WpfOrganization.BLL.Interfaces
{
    public interface ISubscriberService
    {
        void CreateSubscriber(SubscriberDTO subscriberDTO);

        CityDTO GetCity(int idCity);
        IEnumerable<CityDTO> GetCities();

        StreetDTO GetStreet(int idProblem);
        IEnumerable<StreetDTO> GetStreets();

        IEnumerable<SubscriberDTO> GetSubscribers();

        void Dispose();
    }
}
