using System;
using WpfOrganization.BLL.DTO;
using WpfOrganization.BLL.Interfaces;
using WpfOrganization.BLL.Services;

namespace WpfOrganization.BLL.Infrastructure
{
    public class Facade : IFacade
    {
        private readonly IOrderService _orderService;
        private ISubscriberService _subscriberService;
        private ICityService _cityService;

        public Facade() : this(new SubscriberService(), new OrderOnCableTVService(), new CityService())
        {
        }

        public Facade(ISubscriberService subscriberService, IOrderService orderService, ICityService cityService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _subscriberService = subscriberService ?? throw new ArgumentNullException(nameof(subscriberService));
            _cityService = cityService ?? throw new ArgumentNullException(nameof(cityService));
        }

        public DTOForGenerateOrdersOnCableTV GetDTODataForGenerateOrders()
        {
            var DTO = new DTOForGenerateOrdersOnCableTV();
            var a = _subscriberService.GetSubscribers();
            //DTO.SubscribersDTO = ;
                //CitiesDTO = _cityService.GetCities(),
                //OrdersOnCableTVDTO = _orderService.GetUndelegatedOrdersOnCableTV()

            return DTO;
        }
    }
}
