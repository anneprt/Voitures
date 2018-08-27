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
            var chaineConnexion = "Server=.;database=voitures;Trusted_Connection=True";
            var connexion = new SqlConnection(chaineConnexion);
            connexion.Open();

            var commande = connexion.CreateCommand();
            commande.CommandText = "SELECT Nom FROM Modeles WHERE IdMarque=2";
            var dataReader = commande.ExecuteReader();
            while (dataReader.Read())
            {
                var colonneNom = dataReader.GetOrdinal("Nom");
                Console.WriteLine(dataReader.GetString(colonneNom));
            }

            connexion.Close();
            Console.ReadKey();
        }
    }
}
