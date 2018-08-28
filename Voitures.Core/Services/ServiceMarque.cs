using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoituresEF.Classes;
using VoituresEF.Data;

namespace Voitures.Core
{
    public class ServiceMarque
    {
        public void SupprimerMarque(Marque marque)
        {
            using (var contexte = new Contexte())
            {
                contexte.Entry(marque).State = EntityState.Deleted;
                contexte.SaveChanges();
            }
        }

        public void ModifierMarque(Marque marque)
        {
            using (var contexte = new Contexte())
            {
                contexte.Marques.Attach(marque);
                contexte.Entry(marque).State = EntityState.Modified;
                contexte.SaveChanges();
            }
        }

        public void CreerMarque(Marque marque)
        {
            using (var contexte = new Contexte())
            {
                contexte.Marques.Add(marque);
                contexte.SaveChanges();
            }
        }

        public IEnumerable<Marque> ListerMarques()
        {
            using (var contexte = new Contexte())
            {
                return contexte.Marques
                    .Include(x => x.Modeles)
                    .OrderBy(x => x.Nom).ToList();
            }
        }

        public Marque GetMarque(int idMarque)
        {
            using (var contexte = new Contexte())
            {
                return contexte.Marques
                    .Include(x => x.Modeles)
                    .Single(x => x.Id == idMarque);
            }
        }
    }
}
