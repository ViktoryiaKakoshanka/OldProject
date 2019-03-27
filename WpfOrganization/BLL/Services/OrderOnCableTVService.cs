using System;
using System.Collections.Generic;
using AutoMapper;
using WpfOrganization.BLL.DTO;
using WpfOrganization.BLL.Interfaces;
using WpfOrganization.DAL.Entities;
using WpfOrganization.DAL.Interfaces;
using WpfOrganization.GenericData;
using Exception = WpfOrganization.BLL.Infrastructure;

namespace WpfOrganization.BLL.Services
{
    public class OrderOnCableTVService : IOrderService
    {
        private IUnitOfWork Database { get; set; }

        public OrderOnCableTVService(IUnitOfWork database)
        {
            Database = database;
        }
        
        public void MakeOrder(OrderOnCableTVDTO orderDTO)
        {
            var master = Database.Masters.FindById(orderDTO.MasterId);
            var subscriber = Database.Subscribers.FindById(orderDTO.SubscriberId);

            if (master == null)
            {
                throw new Exception.ValidationException("Master not found.", string.Empty);
            }

            if (subscriber == null)
            {
                throw new Exception.ValidationException("Subscriber not found.", string.Empty);
            }
            
            var order = new OrderOnCableTV
            {
                MasterId = master.Id,
                SubscriberId = subscriber.Id,
                CableTVProblemId = orderDTO.CableTVProblemId,
                CreationDate = DateTime.Now,
                EstimatedCompletionDate = orderDTO.EstimatedCompletionDate,
                IsCollectiveOrder = orderDTO.IsCollectiveOrder,
                NonStandardProblem = orderDTO.NonStandardProblem,
                OrderStatus = OrderStatus.Created,
                PhoneNumber = orderDTO.PhoneNumber,
                Remark = orderDTO.Remark,
                UserLocation = orderDTO.UserLocation
            };
            Database.OrdersOnCableTV.Create(order);
            Database.Save();
        }

        public CableTVProblemDTO GetCableTVProblem(int idProblem)
        {
            var problem = Database.CableTVProblems.FindById(idProblem);
            if (problem == null)
            {
                throw new Exception.ValidationException("Problem not found.", string.Empty);
            }

            return new CableTVProblemDTO() { NameOfProblem = problem.NameOfProblem };
        }

        public IEnumerable<CableTVProblemDTO> GetCableTVProblems()
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<CableTVProblem, CableTVProblemDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<CableTVProblem>, IEnumerable<CableTVProblemDTO>>(Database.CableTVProblems.GetAll());
        }

        public MasterDTO GetMaster(int idMaster)
        {
            var master = Database.Masters.FindById(idMaster);
            if (master == null)
            {
                throw new Exception.ValidationException("Master not found.", string.Empty);
            }

            return new MasterDTO()
            {
                Name = master.Name,
                Brigade = master.Brigade,
                HomePhone = master.HomePhone,
                MobilePhone = master.MobilePhone,
                Patronymic = master.Patronymic,
                SecondHomePhone = master.SecondHomePhone,
                SecondMobilePhone = master.SecondMobilePhone,
                SecondWorkPhone = master.SecondWorkPhone,
                Surname = master.Surname,
                WorkPhone = master.WorkPhone,
                Id = master.Id
            };
        }

        public IEnumerable<MasterDTO> GetMasters()
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<Master, MasterDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Master>, IEnumerable<MasterDTO>>(Database.Masters.GetAll());
        }

        public SubscriberDTO GetSubscriber(int idSubscriber)
        {
            var subscriber = Database.Subscribers.FindById(idSubscriber);
            if (subscriber == null)
            {
                throw new Exception.ValidationException("Subscriber not found.", string.Empty);
            }
            return new SubscriberDTO()
            {
                NumberOfContract = subscriber.NumberOfContract,
                RelationshipType = subscriber.RelationshipType,
                ApartmentNumber = subscriber.ApartmentNumber,
                CityId = subscriber.CityId

            };
        }

        public IEnumerable<SubscriberDTO> GetSubscribers()
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<Subscriber, SubscriberDTO>()).CreateMapper();

            var subscriber = Database.Subscribers.GetAll();
            return mapper.Map<IEnumerable<Subscriber>, IEnumerable<SubscriberDTO>>(subscriber);
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
