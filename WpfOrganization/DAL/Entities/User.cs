namespace WpfOrganization.DAL.Entities
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool LoggedIn { get; set; }
        public bool AdminRole { get; set; }
    }
}