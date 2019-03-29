using AutoMapper;
using System;
using System.Collections.Generic;
using WpfOrganization.BLL.DTO;
using WpfOrganization.BLL.Interfaces;
using WpfOrganization.DAL.Entities;
using WpfOrganization.DAL.Interfaces;

namespace WpfOrganization.BLL.Services
{
    public class CityService : ICityService
    {
        private IUnitOfWork Database { get; set; }
        
        public CityService(IUnitOfWork database)
        {
            Database = database;
        }

        public void CreateCity(CityDTO orderDTO)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CityDTO> GetCities()
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<City, CityDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<City>, IEnumerable<CityDTO>>(Database.Cities.GetAll());
        }

        public CityDTO GetCity(int idMaster)
        {
            throw new NotImplementedException();
        }
    }
}
