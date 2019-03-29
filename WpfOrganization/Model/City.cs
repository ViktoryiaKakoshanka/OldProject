using WpfOrganization.BLL.DTO;

namespace WpfOrganization.Model
{
    public class City
    {
        public int Id { get; set; }
        public string CityName { get; set; }

        public City(CityDTO cityDTO)
        {
            Id = cityDTO.Id;
            CityName = string.Join(" ", cityDTO.ShortNameOfCityType, cityDTO.CityName);
        }
    }
}
