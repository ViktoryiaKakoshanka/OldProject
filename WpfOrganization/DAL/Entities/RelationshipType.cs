using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WpfOrganization.DAL.Entities
{
    public class RelationshipType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NameRelationship { get; set; }

        public virtual ICollection<Subscriber> Subscribers { get; set; }
    }
}