using System;
using System.Collections.Generic;
using System.ComponentModel;
using WpfOrganization.BLL.DTO;
using WpfOrganization.BLL.Interfaces;
using WpfOrganization.BLL.Services;
using WpfOrganization.DAL.Interfaces;
using WpfOrganization.DAL.Repositories;

namespace WpfOrganization.ViewModel
{
    public class OrderOnCableTVViewModel
    {
        public IList<Subscriber> Subscribers { get; private set; }
        public IList<OrderOnCableTV> OrdersOnCableTV { get; private set; }
        public IList<City> Cities { get; private set; }

        private static IUnitOfWork unitOfWork = new EFUnitOfWork(@"Data Source=.\SQLEXPRESS;Initial Catalog=CableTV;Integrated Security=True");
        IOrderService _orderService;
        ISubscriberService _subscriberService;

        public OrderOnCableTVViewModel() : this(new OrderOnCableTVService(unitOfWork), new SubscriberService(unitOfWork))
        {
        }

        public OrderOnCableTVViewModel(IOrderService orderService, ISubscriberService subscriberService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _subscriberService = subscriberService ?? throw new ArgumentNullException(nameof(subscriberService));

            Subscribers = new List<Subscriber>();
            OrdersOnCableTV = new List<OrderOnCableTV>();
            Cities = new List<City>();

            FillSubscribers(_subscriberService.GetSubscribers());
        }

        void FillSubscribers(IEnumerable<SubscriberDTO> subscribersDTO)
        {
            foreach (var item in subscribersDTO)
            {
                Subscribers.Add(new Subscriber(item));
            }
        }

        void FillUnallocatedOrders(IEnumerable<OrderOnCableTVDTO> ordersDTO)
        {
            foreach(var item in ordersDTO)
            {
                OrdersOnCableTV.Add(new OrderOnCableTV(item));
            }
        }

        void FillCities(IEnumerable<CityDTO> citiesDTO)
        {
            foreach (var item in citiesDTO)
            {
                Cities.Add(new City());
            }
        }
    }

    public class Subscriber
    {
        public int NumberOfContract { get; }
        public string Relationship { get; }
        public string Surname { get; }
        public string Name { get; }
        public string Patronymic { get; }
        public string City { get; }
        public string Street { get; }
        public string HouseNumber { get; set; }
        public string ApartmentNumber { get; set; }


        public Subscriber(SubscriberDTO subscriberDTO)
        {
            NumberOfContract = subscriberDTO.NumberOfContract;
            Relationship = subscriberDTO.RelationshipType.ToString();
            Surname = subscriberDTO.Surname;
            Name = subscriberDTO.Name;
            Patronymic = subscriberDTO.Patronymic;
            City = subscriberDTO.City?.CityName;
            Street = subscriberDTO.Street.StreetName;
            HouseNumber = subscriberDTO.HouseNumber;
            ApartmentNumber = subscriberDTO.ApartmentNumber;
        }
    }

    public class OrderOnCableTV
    {
        public bool IsCollectiveOrder { get; }
        public int NumberOfContract { get; }
        public string SubscriberSurname { get; }
        public string SubscriberName { get; }
        public string SubscriberPatronymic { get; }
        public string Problem { get; }
        public DateTime DateTimeOfOrderCtreation { get; }
        public DateTime EstimatedCompletionDate { get; }
        public string Remark { get; }
        public string PhoneNumber { get; }

        public OrderOnCableTV(OrderOnCableTVDTO orderOnCableTVDTO)
        {
            IsCollectiveOrder = orderOnCableTVDTO.IsCollectiveOrder;
            NumberOfContract = orderOnCableTVDTO.Subscriber.NumberOfContract;
            SubscriberSurname = orderOnCableTVDTO.Subscriber.Surname;
            SubscriberName = orderOnCableTVDTO.Subscriber.Name;
            SubscriberPatronymic = orderOnCableTVDTO.Subscriber.Patronymic;
            Problem = orderOnCableTVDTO.Problem.NameOfProblem ?? orderOnCableTVDTO.NonStandardProblem;
            DateTimeOfOrderCtreation = orderOnCableTVDTO.CreationDate;
            EstimatedCompletionDate = orderOnCableTVDTO.EstimatedCompletionDate;
            Remark = orderOnCableTVDTO.Remark;
            PhoneNumber = orderOnCableTVDTO.PhoneNumber;
        }
    }

    public class City
    {
        
    }
}