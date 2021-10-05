using System;
namespace Cognac_Behourd.Class
{
    public class Personne
    {
        public Arme Arme { get; set; }
        public Armure Armure { get; set; }

        public string Prenom { get; set; }

        public string Nom { get; set; }

        public DateTime DateAdhesion { get; set; }

        public float Poids { get; set; }
        public DateTime DateDeNaissance { get; set; }

        public Personne(Arme arme, Armure armure, string prenom, string nom, DateTime dateAdhesion, float poids)
        {
            Arme = arme;
            Armure = armure;
            Prenom = prenom;
            Nom = nom;
            DateAdhesion = dateAdhesion;
            Poids = poids;
        }
    }
}
