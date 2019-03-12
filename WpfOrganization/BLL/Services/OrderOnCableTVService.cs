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
        private bool _disposed;

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
                IsCollectiveRequest = orderDTO.IsCollectiveRequest,
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
                Name = master.FullName.Name,
                Brigade = master.Brigade,
                HomePhone = master.HomePhone,
                MobilePhone = master.MobilePhone,
                Patronymic = master.FullName.Patronymic,
                SecondHomePhone = master.SecondHomePhone,
                SecondMobilePhone = master.SecondMobilePhone,
                SecondWorkPhone = master.SecondWorkPhone,
                Surname = master.FullName.Surname,
                WorkPhone = master.WorkPhone,
                Id = master.Id
            };
        }

        public IEnumerable<MasterDTO> GetMasters()
        {
            var mapper = new MapperConfiguration(config => config.CreateMap<Master, MasterDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Master>, IEnumerable<MasterDTO>>(Database.Masters.GetAll());
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
