using System.ComponentModel.DataAnnotations.Schema;

namespace WpfOrganization.DAL.Entities
{
    public class CableTVProblem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string NameOfProblem { get; set; }
    }
}
