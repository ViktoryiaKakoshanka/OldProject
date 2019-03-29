using System;
using System.Collections.Generic;
using System.Data.Entity;
using WpfOrganization.DAL.Entities;
using WpfOrganization.GenericData;

namespace WpfOrganization.DAL.EF
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext db)
        {
            db.Masters.Add(new Master
            {
                OrdersOnCableTv = null,
                Name = "A",
                Surname = "M",
                Patronymic = "S",
                Brigade = false,
                ComplitedOrderRepairAndRestructionListByMaster = null,
                HomePhone = "+375",
                MobilePhone = "",
                OrdersRepairAndRestructionAccountableToMaster = null,
                SecondHomePhone = null,
                SecondMobilePhone = null,
                SecondWorkPhone = null,
                WorkPhone = null
            });

            var streets = new List<Street> {
                new Street
                {
                    StreetName = "Ленинская",
                    StreetTypes = StreetType.Street
                },
                new Street
                {
                    StreetName = "ЧашникиУл",
                    StreetTypes = StreetType.Street
                },
                new Street
                {
                    StreetName = "ХойникиУл",
                    StreetTypes = StreetType.Street
                },
            };
            db.Streets.AddRange(streets);
            
            var city = new City
            {
                CityName = "Чашники",
                ShortNameOfCityType = "г."
            };
            city.Streets.Add(streets[0]);
            city.Streets.Add(streets[1]);
            db.Cities.Add(city);

            var city1 = new City
            {
                CityName = "Хойники",
                ShortNameOfCityType = "г."
            };
            city1.Streets.Add(streets[2]);
            db.Cities.Add(city1);

            db.CableTvProblems.Add(new CableTVProblem { NameOfProblem = "Снежат каналы" });

            var subscriber = new Subscriber
            {
                ContractDate = DateTime.Now,
                City = city,
                ApartmentNumber = "1",
                HomePhone = "1",
                HouseNumber = "1",
                MobilePhone = "+3758 44 774-96-07",
                NumberOfContract = 102,
                RelationshipType = RelationshipType.StatePackage,
                Street = streets[0],
                Name = "Test Name",
                Surname = "Test Surname",
                Patronymic = "Test Patronymic"
            };
            db.Subscribers.Add(subscriber);

            db.SubscriberRelationships.Add(new SubscriberRelationship
            {
                Subscriber = subscriber,
                RelationshipDate = DateTime.Now,
                RelationshipType = RelationshipType.StatePackage
            });

            db.OrdersOnCableTv.Add(new OrderOnCableTV
            {
                CreationDate = DateTime.Now,
                EstimatedCompletionDate = DateTime.Now.AddDays(3),
                IsCollectiveOrder = false,
                OrderStatus = OrderStatus.Created,
                Subscriber = subscriber,
                Remark = "Test",                
            });

            db.SaveChanges();
        }
    }
}
