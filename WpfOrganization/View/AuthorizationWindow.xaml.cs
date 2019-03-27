using System;
using System.Windows;
using WpfOrganization.BLL.DTO;
using WpfOrganization.DAL.EF;
using WpfOrganization.DAL.Entities;
using WpfOrganization.GenericData;

namespace WpfOrganization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using (var ctx = new DatabaseContext(@"Data Source=.\SQLEXPRESS;Initial Catalog=CableTV;Integrated Security=True"))
            {
                var stud = new User() { Login = "Bill", Password = "", AdminRole = AdminRole.Dispatcher, LoggedIn = false};
                ctx.Users.Add(stud);
                
                var city = new City()
                {
                    CityName = "Чашники",
                    ShortNameOfCityType = "г."
                };
                ctx.Cities.Add(city);


                var street = new Street()
                {
                    StreetName = "Ленина",
                    StreetTypes = StreetType.Street
                };
                ctx.Streets.Add(street);

                ctx.SaveChanges();

                var subscriber = new Subscriber()
                {
                    RelationshipType = RelationshipType.StatePackage,
                    City = city,
                    Street = street,
                    Surname = "T",
                    Name = "T",
                    Patronymic = "T",
                    ContractDate = DateTime.Now,
                    NumberOfContract = 2
                };
                ctx.Subscribers.Add(subscriber);

                var order = new OrderOnCableTV()
                {
                    Subscriber = subscriber,
                    OrderStatus = OrderStatus.Created,
                    EstimatedCompletionDate = DateTime.Now,
                    CreationDate = DateTime.Now
                };
                ctx.OrdersOnCableTv.Add(order);
                ctx.SaveChanges();
            }
        }
    }
}
