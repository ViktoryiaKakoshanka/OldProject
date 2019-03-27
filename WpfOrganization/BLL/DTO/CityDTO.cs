using System.Collections.Generic;

namespace WpfOrganization.BLL.DTO
{
    public class CityDTO
    {
        public int Id { get; set; }
        public string ShortNameOfCityType { get; set; }
        public string CityName { get; set; }

        public virtual ICollection<StreetDTO> Streets { get; set; }
        public virtual ICollection<SubscriberDTO> Subscribers { get; set; }
    }
}
