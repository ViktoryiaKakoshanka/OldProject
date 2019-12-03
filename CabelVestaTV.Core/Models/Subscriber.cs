using System;
using CabelVestaTV.Core.GenericData;

namespace CabelVestaTV.Core.Models
{
    public class Subscriber
    {
        public int Id { get; set; }

        public int NumberOfContract { get; set; }
        public DateTime ContractDate { get; set; }

        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }

        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string SecondMobilePhone { get; set; }

        public RelationshipType RelationshipType { get; set; }

        public Address Address { get; set; }
    }
}