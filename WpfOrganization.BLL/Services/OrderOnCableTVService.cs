using AutoMapper;
using System;
using System.Collections.Generic;
using WpfOrganization.BLL.DTO;
using WpfOrganization.BLL.Interfaces;
using WpfOrganization.DAL;
using WpfOrganization.DAL.Entities;
using WpfOrganization.DAL.Interfaces;
using WpfOrganization.GenericData;
using Exception = WpfOrganization.BLL.Infrastructure;

namespace WpfOrganization.BLL.Services
{
    public class OrderOnCableTVService : IOrderService
    {
        private IUnitOfWork Database { get; set; }

        public OrderOnCableTVService() : this(TemporaryUnitOfWork.Database)
        {
        }

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

        public void Dispose()
        {
            Database.Dispose();
        }

        public void DelegateToMaster(MasterDTO masterDTO)
        {
            throw new NotImplementedException();
        }

        public void Controlate()
        {
            throw new NotImplementedException();
        }

        public void Controlate(DateTime dateControlated)
        {
            throw new NotImplementedException();
        }

        public void Complete()
        {
            throw new NotImplementedException();
        }

        public void Complete(DateTime dateCompleted)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderOnCableTVDTO> GetUndelegatedOrdersOnCableTV()
        {
            var undelegatedOrdersOnCableTV = Database.OrdersOnCableTV.Get(o => o.MasterId == null);
            /*
            var mapper = new MapperConfiguration(c => c.CreateMap<OrderOnCableTV, OrderOnCableTVDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<OrderOnCableTV>, IEnumerable<OrderOnCableTVDTO>>(undelegatedOrdersOnCableTV);*/
            return null;
        }
    }
}
