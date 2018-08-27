using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voitures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("VOITURES");
            Console.WriteLine();

            // int idMarque = ChoisirMarque();
            //AfficherModeles(idMarque);

            while (true)
            {
                var choix = AfficherMenu();
                switch (choix)
                {
                    case 1:
                        int idMarque = ChoisirMarque();
                        AfficherModeles(idMarque);
                        break;

                    case 2:
                        AfficherSegments();
                        break;
                    case 3:
                        CreerMarque();
                        break;
                    case 4:
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

        private static int ChoisirMarque()
        {
            Console.WriteLine();
            Console.WriteLine("> MARQUES");

            var connexion = CreerConnexion();
            connexion.Open();

            var commande = connexion.CreateCommand();

            commande.CommandText = "SELECT * FROM Marques ORDER BY Nom";
            var dataReader = commande.ExecuteReader();

            while (dataReader.Read())
            {

                var indexColonneNom = dataReader.GetOrdinal("Nom");
                var indexColonneId = dataReader.GetOrdinal("Id");
                Console.Write(dataReader.GetString(indexColonneNom));
                Console.Write("(");
                Console.Write(dataReader.GetInt32(indexColonneId));
                Console.WriteLine(")");
            }

            connexion.Close();

            Console.WriteLine("Quelle marque (Id)?");
            return int.Parse(Console.ReadLine());
        }

        private static void AfficherModeles(int idMarque)
        {
            Console.WriteLine();
            Console.WriteLine("> MODELES");

            var connexion = CreerConnexion();
            connexion.Open();

            var commande = connexion.CreateCommand();
            commande.CommandText =
                @"SELECT M.Nom AS NonModele,S.Nom AS NomSegment
                FROM Modeles M
                    INNER JOIN Segments S ON S.Id=M.IdSegment
                WHERE IdMarque=@IdMarque";
            commande.Parameters.AddWithValue("@IdMarque", idMarque);

            var dataReader = commande.ExecuteReader();
            while (dataReader.Read())
            {
                var indexColonneNomModele = dataReader.GetOrdinal("NomModele");
                var indexColonneNomSegment = dataReader.GetOrdinal("NomSegment");
                Console.Write(dataReader.GetString(indexColonneNomModele));
                Console.Write("(");
                Console.Write(dataReader.GetString(indexColonneNomSegment));
                Console.WriteLine(")");
            }

            connexion.Close();

        }
        private static void AfficherSegments()
        {

        }

        private static void CreerMarque()
        {

        }

        private static void SupprimerMarque ()
        {

        }

        private static int AfficherMenu()
        {
            Console.Clear();

            Console.WriteLine("1. Afficher les modèles");
            Console.WriteLine("2. Afficher les segments");
            Console.WriteLine("3. Créer une marque");
            Console.WriteLine("4. Supprimer une marque");
            Console.WriteLine("9. Quitter");

            Console.Write("Votre choix: ");
            return int.Parse(Console.ReadLine());
        }
        static SqlConnection CreerConnexion()
        {
            var chaineConnexion = "Server=.;database=voitures;Trusted_Connection=True";
            return new SqlConnection(chaineConnexion);
        }

    }
}
