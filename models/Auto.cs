using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace kodutoo.models
{
    public class Auto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Mudel { get; set; }
        public int Price { get; set; }
        public bool OnRenditud { get; set; }
        public ICollection<Rentija> Rentijad { get; set;}
    }
}
