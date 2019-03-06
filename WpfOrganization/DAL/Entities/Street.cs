﻿using System.ComponentModel.DataAnnotations.Schema;

namespace WpfOrganization.DAL.Entities
{
    public class Street
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string StreetName { get; set; }

        public int? StreetTypesId { get; set; }
        public StreetType StreetTypes { get; set; }
    }
}