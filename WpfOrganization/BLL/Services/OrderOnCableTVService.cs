using System;
using System.Collections.Generic;
using AutoMapper;
using WpfOrganization.BLL.DTO;
using WpfOrganization.BLL.Interfaces;
using WpfOrganization.DAL.Entities;
using WpfOrganization.DAL.Interfaces;
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
            var master = Database.Masters.Get(orderDTO.MasterId);
            var problem = Database.CableTVProblems.Get(orderDTO.CableTVProblemId);
            var subscriber = Database.Subscribers.Get(orderDTO.SubscriberId);

            if (master == null)
            {
                throw new Exception.ValidationException("Master not found.", "");
            }

            if (problem == null)
            {
                throw new Exception.ValidationException("Problem not found.", "");
            }

            if (subscriber == null)
            {
                throw new Exception.ValidationException("Subscriber not found.", "");
            }

            var mapper = new MapperConfiguration(config => config.CreateMap<OrderOnCableTV, OrderOnCableTVDTO>()
                .ForMember(dto => dto.Status, 
                    db => db.MapFrom(o => ConvertEnumToString(o.OrderStatus))));

            var order = new OrderOnCableTV
            {
                Master = master,
                Subscriber = subscriber
            };
        }

        private static OrderStatus ConvertEnumToString(string status)
        {
            return OrderStatus.Checked;
        }

        public CableTVProblemDTO GetCableTVProblem(int idProblem)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CableTVProblemDTO> GetCableTVProblems()
        {
            throw new NotImplementedException();
        }

        public MasterDTO GetMaster(int idMaster)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MasterDTO> GetMasters()
        {
            throw new System.NotImplementedException();
        }

        
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
