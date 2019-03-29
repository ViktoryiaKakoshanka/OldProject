using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfOrganization.DAL.Entities
{
    public class City
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ShortNameOfCityType { get; set; }
        public string CityName { get; set; }

        public virtual ICollection<Street> Streets { get; set; }
        public virtual ICollection<Master> Masters { get; set; }

        public City()
        {
            Streets = new List<Street>();
            Masters = new List<Master>();
        }
    }
}
