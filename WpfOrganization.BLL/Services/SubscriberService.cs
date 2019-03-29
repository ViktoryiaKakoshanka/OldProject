using AutoMapper;
using System;
using System.Collections.Generic;
using WpfOrganization.BLL.DTO;
using WpfOrganization.BLL.Interfaces;
using WpfOrganization.DAL.Entities;
using WpfOrganization.DAL.Interfaces;

namespace WpfOrganization.BLL.Services
{
    public class SubscriberService : ISubscriberService
    {
        private IUnitOfWork Database { get; set; }
        
        public SubscriberService(IUnitOfWork database)
        {
            Database = database;
        }

        public void CreateSubscriber(SubscriberDTO subscriberDTO)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CityDTO> GetCities()
        {
            throw new NotImplementedException();
        }

        public CityDTO GetCity(int idCity)
        {
            throw new NotImplementedException();
        }

        public StreetDTO GetStreet(int idProblem)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StreetDTO> GetStreets()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SubscriberDTO> GetSubscribers()
        {
            var a = Database.Subscribers.GetAll();
            var mapper = new MapperConfiguration(config => config.CreateMap<Subscriber, SubscriberDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Subscriber>, IEnumerable<SubscriberDTO>>(a);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
