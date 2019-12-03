using CabelVestaTV.Core.GenericData;

namespace CabelVestaTV.Core.Models
{
    public class Street
    {
        public int Id { get; set; }
        public string StreetName { get; set; }

        public StreetType StreetTypes { get; set; }
    }
}
