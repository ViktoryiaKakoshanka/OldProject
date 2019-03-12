using System;

namespace WpfOrganization.BLL.DTO
{
    public class UserActionDTO
    {
        public int Id { get; set; }
        public DateTime DateOfAction { get; set; }

        public int UserId { get; set; }
    }
}
