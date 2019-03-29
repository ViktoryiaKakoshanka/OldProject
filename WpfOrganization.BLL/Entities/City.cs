using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfOrganization.BLL.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string ShortNameOfCityType { get; set; }
        public string CityName { get; set; }

        public virtual ICollection<Street> Streets { get; set; }
        //public virtual ICollection<Master> Masters { get; set; }
    }
}
