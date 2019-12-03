using System;

namespace CabelVestaTV.Core.Models
{
    public class UserAction
    {
        public int Id { get; set; }
        public DateTime DateOfAction { get; set; }

        public int UserId { get; set; }
    }
}
