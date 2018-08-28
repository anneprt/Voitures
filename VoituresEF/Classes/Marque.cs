using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoituresEF.Classes
{
    [Table("Marque")]

    public class Marque
    {
        [Column("IdMarque")]
        public int Id { get; set; }

        [Column("Libelle")]
        [Required]
        public string Nom { get; set; }

        public virtual ICollection<Modele> Modeles { get; set; }
    }
}
