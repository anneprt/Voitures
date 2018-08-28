using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoituresEF.Classes;

namespace VoituresEF.Data
{
    public class Contexte : DbContext
    {
        public Contexte()
            : base("Contexte")
        {

        }
        public DbSet<Marque> Marques { get; set; }
        public DbSet<Modele> Modeles { get; set; }
        public DbSet<Segment> Segments { get; set; }
    }
}
