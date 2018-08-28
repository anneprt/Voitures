using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using Voitures.Core;
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
                        AfficherModeles(marque);
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
            var serviceVoiture = new ServiceMarque();
            return serviceVoiture.GetMarque(idMarque);
        }

        private static void AfficherMarques()
        {
            Console.WriteLine();
            Console.WriteLine("> MARQUES");
            var serviceVoiture = new ServiceMarque();
            var marques = serviceVoiture.ListerMarques();
            foreach (var marque in marques)
            {

                Console.Write($"{marque.Nom} ({marque.Id})");
                Console.WriteLine($" :{marque.Modeles.Count} modèle(s)");
            }
        }
        private static void AfficherModeles(Marque marque)
        {
            Console.WriteLine();
            Console.WriteLine("> MODELES");

            foreach (var modele in marque.Modeles)
            {
                Console.WriteLine($"{modele.Nom} - {modele.Segment.Nom} ({modele.Id})");
            }

        }

        private static void CreerMarque()
        {
            Console.WriteLine();
            Console.WriteLine(">NOUVELLE MARQUE");
            Console.Write("Nom de la marque: ");
            var nomMarque = Console.ReadLine();
            var marque = new Marque();
            marque.Nom = nomMarque;
            var serviceVoiture = new ServiceMarque();
            serviceVoiture.CreerMarque(marque);
        }

        private static void ModifierMarque()
        {
            Console.WriteLine();
            Console.WriteLine(">MODIFICATION D'UNE MARQUE");
            var marque = ChoisirMarque();
            Console.Write("Nouveau nom: ");
            marque.Nom = Console.ReadLine();
            var serviceVoiture = new ServiceMarque();
            serviceVoiture.ModifierMarque(marque);
        }
        private static void SupprimerMarque()
        {
            Console.WriteLine();
            Console.WriteLine(">SUPPRESSION D'UNE MARQUE");
            Marque marque = ChoisirMarque();
            var serviceVoiture = new ServiceMarque();
            serviceVoiture.SupprimerMarque(marque);
        }
        private static int AfficherMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Afficher les modèles");
            Console.WriteLine();
            Console.WriteLine("2. Afficher les marques");
            Console.WriteLine("3. Créer une marque");
            Console.WriteLine("4. Modifier une marque");
            Console.WriteLine("5. Supprimer une marque");
            Console.WriteLine();
            Console.WriteLine("9. Quitter");
            Console.Write("Votre choix: ");
            return int.Parse(Console.ReadLine());
        }
    }
}

