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

            int idMarque = ChoisirMarque();
            AfficherModeles(idMarque);

            Console.ReadKey();

        }

        private static int ChoisirMarque()
        {
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
                Console.WriteLine("Modèles");
                Console.WriteLine();

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
            static SqlConnection CreerConnexion()
            {
                var chaineConnexion = "Server=.;database=voitures;Trusted_Connection=True";
                return new SqlConnection(chaineConnexion);
            }

        }
    } 
