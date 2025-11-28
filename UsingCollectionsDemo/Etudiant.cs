using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UsageCollections
{
    public class Etudiant
    {
        public int NO { get; set; }            // Numéro d'ordre
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public double NoteCC { get; set; }     // Contrôle continu
        public double NoteDevoir { get; set; } // Devoir

        // Constructeur vide
        public Etudiant() { }

        // Constructeur avec paramètres
        public Etudiant(int no, string prenom, string nom, double noteCC, double noteDevoir)
        {
            NO = no;
            Prenom = prenom;
            Nom = nom;
            NoteCC = noteCC;
            NoteDevoir = noteDevoir;
        }

        // Moyenne pondérée : CC = 33%, Devoir = 67%
        public double Moyenne()
        {
            return NoteCC * 0.33 + NoteDevoir * 0.67;
        }

        public override string ToString()
        {
            return $"{NO}\t{Nom}\t{Prenom}\t{NoteCC:F2}\t{NoteDevoir:F2}\t{Moyenne():F2}";
        }
    }
}