using System.Collections.Generic;
using WpfOrganization.BLL.DTO;

namespace WpfOrganization.BLL.Interfaces
{
    public interface ICityService
    {
        void CreateCity(CityDTO orderDTO);

        CityDTO GetCity(int idMaster);
        IEnumerable<CityDTO> GetCities();

        void Dispose();
    }
}
