namespace WpfOrganization.DAL.Entities
{
    public class Street
    {
        public int Id { get; set; }
        public string StreetName { get; set; }

        public int? StreetTypesId { get; set; }
        public StreetType StreetTypes { get; set; }
    }
}
