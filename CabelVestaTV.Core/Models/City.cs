using CabelVestaTV.Core.GenericData;
using System.Collections.Generic;

namespace CabelVestaTV.Core.Models
{
    public class City
    {
        public int Id { get; set; }
        public CityTipe Type { get; set; }
        public string Name { get; set; }

        public ICollection<Street> Streets { get; set; }
    }
}
