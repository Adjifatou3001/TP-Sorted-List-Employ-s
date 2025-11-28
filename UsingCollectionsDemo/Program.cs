using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace UsageCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            // ====== DECLARATION ======
            SortedList<int, Etudiant> lstEtudiants = new SortedList<int, Etudiant>();

            Console.Write("Combien d'étudiants voulez-vous saisir ? ");
            int n = int.Parse(Console.ReadLine());

            // ====== QUESTION 2 : SAISIE ======
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"\n--- Étudiant {i + 1} ---");

                Console.Write("Numéro d’ordre (NO) : ");
                int no = int.Parse(Console.ReadLine());

                // Prénom (seulement lettres)
                string prenom;
                do
                {
                    Console.Write("Prénom : ");
                    prenom = Console.ReadLine();
                    if (!Regex.IsMatch(prenom, @"^[A-Za-z]+$"))
                        Console.WriteLine("Erreur : le prénom doit contenir uniquement des lettres.");
                } while (!Regex.IsMatch(prenom, @"^[A-Za-z]+$"));

                // Nom (seulement lettres)
                string nom;
                do
                {
                    Console.Write("Nom : ");
                    nom = Console.ReadLine();
                    if (!Regex.IsMatch(nom, @"^[A-Za-z]+$"))
                        Console.WriteLine("Erreur : le nom doit contenir uniquement des lettres.");
                } while (!Regex.IsMatch(nom, @"^[A-Za-z]+$"));


                Console.Write("Note CC : ");
                double noteCC = double.Parse(Console.ReadLine());

                Console.Write("Note Devoir : ");
                double noteDevoir = double.Parse(Console.ReadLine());

                // Utilisation du constructeur de ta classe
                Etudiant e = new Etudiant(no, prenom, nom, noteCC, noteDevoir);

                lstEtudiants.Add(no, e);
            }

            // ====== QUESTION 3 : MOYENNE DE LA CLASSE ======
            double moyenneClasse = 0;
            if (lstEtudiants.Count > 0)
            {
                double somme = 0;
                foreach (Etudiant et in lstEtudiants.Values)
                    somme += et.Moyenne();

                moyenneClasse = somme / lstEtudiants.Count;
            }

            // ====== QUESTION 4 : LIGNES PAR PAGE ======
            int lignesParPage;
            do
            {
                Console.Write("\nNombre de lignes par page (5 à 15) : ");
            }
            while (!int.TryParse(Console.ReadLine(), out lignesParPage) || lignesParPage < 5 || lignesParPage > 15);

            int total = lstEtudiants.Count;
            int totalPages = (int)Math.Ceiling((double)total / lignesParPage);
            int pageActuelle = 1;

            List<Etudiant> liste = new List<Etudiant>(lstEtudiants.Values);

            // ====== Méthode d'affichage ======
            void AfficherPage(int page)
            {
                Console.Clear();
                Console.WriteLine($"===== PAGE {page}/{totalPages} =====\n");
                Console.WriteLine("NO\tNom\tPrénom\tCC\tDevoir\tMoyenne");
                Console.WriteLine("------------------------------------------------------------");

                int start = (page - 1) * lignesParPage;
                int end = Math.Min(start + lignesParPage, total);

                for (int i = start; i < end; i++)
                {
                    Etudiant e = liste[i];
                    Console.WriteLine(e.ToString());
                }

                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine($"Moyenne de la classe : {moyenneClasse:F2}");
            }

            // ====== QUESTION 5 : NAVIGATION ======
            while (true)
            {
                AfficherPage(pageActuelle);

                Console.WriteLine("\n(N) Suivante | (P) Précédente | (Q) Quitter");
                Console.Write("Votre choix : ");
                string choix = Console.ReadLine().ToUpper();

                if (choix == "N")
                {
                    if (pageActuelle < totalPages) pageActuelle++;
                }
                else if (choix == "P")
                {
                    if (pageActuelle > 1) pageActuelle--;
                }
                else if (choix == "Q")
                {
                    Console.WriteLine("Fin du programme.");
                    break;
                }
            }
        } 
    } 
} 
