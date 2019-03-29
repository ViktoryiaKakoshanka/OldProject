using System.Collections.Generic;

namespace WpfOrganization.BLL.DTO
{
    public class DTOForGenerateOrdersOnCableTV
    {
        public IEnumerable<SubscriberDTO> SubscribersDTO { get; set; }
        public IEnumerable<OrderOnCableTVDTO> OrdersOnCableTVDTO { get; set; }
        public IEnumerable<CityDTO> CitiesDTO { get; set; }
        public IEnumerable<StreetDTO> StreetsDTO { get; set; }
    }
}
