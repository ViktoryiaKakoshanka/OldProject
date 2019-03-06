using System.Collections.Generic;

namespace WpfOrganization.DAL.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool LoggedIn { get; set; }
        public bool AdminRole { get; set; }

        public virtual  ICollection<UserAction> UserActionHistory { get; set; }
    }
}