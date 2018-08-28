using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoituresEF.Classes
{
    public class Modele
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public int IdMarque { get; set; }
        public int IdSegment { get; set; }
    }
}
