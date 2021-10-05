using System;
using Cognac_Behourd.Class.Extensions;
using Cognac_Behourd.Class.Interfaces;

namespace Cognac_Behourd.Class
{
    public class Personne : IPesable
    {
        public Arme Arme { get; set; }
        public Armure Armure { get; set; }

        public string Prenom { get; set; }

        public string Nom { get; set; }

        public DateTime DateAdhesion { get; set; }

        public float Poids { get; set; }

        public DateTime DateDeNaissance { get; set; }

        public int Age { get => DateDeNaissance.GetAge(); }

        public int AnneeExperience { get => DateAdhesion.GetAge(); }

        public Personne(Arme arme, Armure armure, string prenom, string nom, DateTime dateAdhesion, float poids, DateTime dateDeNaissance)
        {
            Arme = arme;
            Armure = armure;
            Prenom = prenom;
            Nom = nom;
            DateAdhesion = dateAdhesion;
            Poids = poids;
            DateDeNaissance = dateDeNaissance;
        }
    }
}
