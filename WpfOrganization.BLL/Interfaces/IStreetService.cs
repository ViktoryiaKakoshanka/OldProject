using System;
using System.Collections.Generic;
using System.Text;
using WpfOrganization.BLL.DTO;

namespace WpfOrganization.BLL.Interfaces
{
    public interface IStreetService
    {
        void CreateStreet(CityDTO orderDTO);

        CityDTO GetCity(int idMaster);
        IEnumerable<CityDTO> GetCities();

        void Dispose();
    }
}
