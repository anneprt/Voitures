using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoituresEF.Classes;
using VoituresEF.Data;

namespace VoituresEF
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("VOITURES");
            Console.WriteLine();
            while (true)
            {
                var choix = AfficherMenu();
                switch (choix)
                {
                    case 1:
                        var marque = ChoisirMarque();
                        AfficherModeles(marque.Id);
                        break;
                    case 2:
                        AfficherMarques();
                        break;
                    case 3:
                        CreerMarque();
                        break;
                    case 4:
                        ModifierMarque();
                        break;
                    case 5:
                        SupprimerMarque();
                        break;
                    case 9:
                        Environment.Exit(0);
                        break;
                }
                Console.WriteLine("Appuyez pour retourner au menu...");
                Console.ReadKey();
            }
        }
        private static Marque ChoisirMarque()
        {
            AfficherMarques();
            Console.WriteLine("Quelle marque (Id)?");
            var idMarque = int.Parse(Console.ReadLine());
            using (var contexte = new Contexte())
            {
                return contexte.Marques.Single(x => x.Id == idMarque);
            }
        }

        private static void AfficherMarques()
        {
            Console.WriteLine();
            Console.WriteLine("> MARQUES");
            using (var contexte = new Contexte())
            {
                var marques = contexte.Marques
                    .OrderBy(x => x.Nom).ToList();
                foreach (var marque in marques)
                {
                    Console.WriteLine($"{marque.Nom} ({marque.Id})");
                }
            }
        }
        private static void AfficherModeles(int idMarque)
        {
            Console.WriteLine();
            Console.WriteLine("> MODELES");
            //var connexion = CreerConnexion();
            //connexion.Open();
            //var commande = connexion.CreateCommand();
            //commande.CommandText =
            //    @"SELECT M.Nom AS NomModele, S.Nom AS NomSegment
            //      FROM Modeles M
            //          INNER JOIN Segments S ON S.Id = M.IdSegment
            //      WHERE IdMarque = @IdMarque";
            //commande.Parameters.AddWithValue("@IdMarque", idMarque);
            //var dataReader = commande.ExecuteReader();
            //while (dataReader.Read())
            //{
            //    var indexColonneNomModele = dataReader.GetOrdinal("NomModele");
            //    var indexColonneNomSegment = dataReader.GetOrdinal("NomSegment");
            //    Console.Write(dataReader.GetString(indexColonneNomModele));
            //    Console.Write(" (");
            //    Console.Write(dataReader.GetString(indexColonneNomSegment));
            //    Console.WriteLine(")");
            //}
            //connexion.Close();
        }

        private static void CreerMarque()
        {
            Console.WriteLine();
            Console.WriteLine(">NOUVELLE MARQUE");
            Console.Write("Nom de la marque: ");
            var nomMarque = Console.ReadLine();
            var marque = new Marque();
            marque.Nom = nomMarque;
            using (var contexte = new Contexte())
            {
                contexte.Marques.Add(marque);
                contexte.SaveChanges();
            }
        }

        private static void ModifierMarque()
        {
            Console.WriteLine();
            Console.WriteLine(">MODIFICATION D'UNE MARQUE");
            // 1ère option: on rattache l'objet marque 
            //  au nouveau contexte puis on précise son nouvel état
            var marque = ChoisirMarque();
            using (var contexte = new Contexte())
            {
                contexte.Marques.Attach(marque);
                contexte.Entry(marque).State = EntityState.Modified;
                contexte.SaveChanges();
            }
            // 2ère option: on rattache l'objet marque 
            //  au nouveau contexte puis on le modifie
            //var marque = ChoisirMarque();
            //using (var contexte = new Contexte())
            //{
            //    contexte.Marques.Attach(marque);
            //    Console.Write("Nouveau nom: ");
            //    marque.Nom = Console.ReadLine();
            //    contexte.SaveChanges();
            //}
            // 3ème option: on récupère l'objet marque 
            //  dans le nouveau contexte puis on le modifie
            //int idMarque = ChoisirMarque().Id;
            //using (var contexte = new Contexte())
            //{
            //    var marque = contexte.Marques.Single(x => x.Id == idMarque);
            //    Console.Write("Nouveau nom: ");
            //    marque.Nom = Console.ReadLine();
            //    contexte.SaveChanges();
            //}
        }
        private static void SupprimerMarque()
        {
            Console.WriteLine();
            Console.WriteLine(">SUPPRESSION D'UNE MARQUE");
            Marque marque = ChoisirMarque();
            using (var contexte = new Contexte())
            {
                contexte.Marques.Attach(marque);
                contexte.Marques.Remove(marque);
                contexte.SaveChanges();
            }
        }
        private static int AfficherMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Afficher les modèles");
            Console.WriteLine("2. Afficher les marques");
            Console.WriteLine("3. Créer une marque");
            Console.WriteLine("4. Modifier une marque");
            Console.WriteLine("5. Supprimer une marque");
            Console.WriteLine("9. Quitter");
            Console.Write("Votre choix: ");
            return int.Parse(Console.ReadLine());
        }
    }
}

