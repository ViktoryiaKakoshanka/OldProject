using System;
using System.Collections.Generic;
using System.Text;
using WpfOrganization.GenericData;

namespace WpfOrganization.BLL.Entities
{
    public class Street
    {
        public int Id { get; set; }
        public string StreetName { get; set; }

        public StreetType StreetTypes { get; set; }
    }
}
