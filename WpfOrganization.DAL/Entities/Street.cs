using System.ComponentModel.DataAnnotations.Schema;
using WpfOrganization.GenericData;

namespace WpfOrganization.DAL.Entities
{
    public class Street
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string StreetName { get; set; }

        public StreetType StreetTypes { get; set; }
    }
}
