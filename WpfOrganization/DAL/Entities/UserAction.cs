using System;

namespace WpfOrganization.DAL.Entities
{
    public class UserAction
    {
        public int Id { get; set; }
        public DateTime DateOfAction { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
