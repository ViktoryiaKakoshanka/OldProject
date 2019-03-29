using WpfOrganization.GenericData;

namespace WpfOrganization.BLL.DTO
{
    public class StreetDTO
    {
        public int Id { get; set; }
        public string StreetName { get; set; }

        public StreetType StreetTypes { get; set; }
    }
}
