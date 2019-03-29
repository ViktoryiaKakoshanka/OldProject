using System.Collections.Generic;
using WpfOrganization.BLL.DTO;
using WpfOrganization.BLL.Infrastructure;
using WpfOrganization.BLL.Interfaces;
using WpfOrganization.Model;
using WpfOrganization.GenericData;

namespace WpfOrganization.ViewModel
{
    public class OrderOnCableTVViewModel
    {
        public IList<Subscriber> Subscribers { get; private set; }
        public IList<UndelegatedOrderOnCableTV> UndelegatedOrdersOnCableTV { get; private set; }
        public IList<City> Cities { get; private set; }
        
        public OrderOnCableTVViewModel() : this(new Facade())
        {
        }

        public OrderOnCableTVViewModel(IFacade facade)
        {
            Subscribers = new List<Subscriber>();
            UndelegatedOrdersOnCableTV = new List<UndelegatedOrderOnCableTV>();
            Cities = new List<City>();

            var dtoData = facade.GetDTODataForGenerateOrders();
            FillSubscribers(dtoData.SubscribersDTO);
            FillUnallocatedOrders(dtoData.OrdersOnCableTVDTO);
            FillCities(dtoData.CitiesDTO);
        }

        void FillSubscribers(IEnumerable<SubscriberDTO> subscribersDTO)
        {
            foreach (var item in subscribersDTO)
            {
                var a = new Subscriber(item);
                Subscribers.Add(a);
            }
        }

        void FillUnallocatedOrders(IEnumerable<OrderOnCableTVDTO> ordersDTO)
        {
            foreach(var item in ordersDTO)
            {
                UndelegatedOrdersOnCableTV.Add(new UndelegatedOrderOnCableTV(item));
            }
        }

        void FillCities(IEnumerable<CityDTO> citiesDTO)
        {
            foreach (var item in citiesDTO)
            {
                Cities.Add(new City(item));
            }
        }
    }
}