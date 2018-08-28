using System;
using System.Collections.Generic;
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
        public string Nom { get; set; }
    }
}
