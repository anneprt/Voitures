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
            Console.WriteLine("Modèles chez Renault");

            AfficherModeles();

            Console.ReadKey();
            
        }

        private static void AfficherModeles()
        {
            var connexion = CreerConnexion();
            connexion.Open();

            var commande = connexion.CreateCommand();
            //commande.CommandText = "SELECT Nom FROM Modeles WHERE IdMarque=2";
            commande.CommandText =
                @"SELECT M.Nom AS NonModele,S.Nom AS NomSegment
                FROM Modeles M
                    INNER JOIN Segments S ON S.Id=M.IdSegment
                WHERE IdMarque=2";
        
            var dataReader = commande.ExecuteReader();
            while (dataReader.Read())
            {
                // var colonneNom = dataReader.GetOrdinal("Nom");
                //Console.WriteLine(dataReader.GetString(colonneNom));
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
