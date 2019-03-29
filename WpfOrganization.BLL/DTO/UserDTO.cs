using WpfOrganization.GenericData;

namespace WpfOrganization.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool LoggedIn { get; set; }
        public AdminRole AdminRole { get; set; }
    }
}
