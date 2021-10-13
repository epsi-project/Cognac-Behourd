using System;
using Cognac_Behourd.Class.Enumerations;
using Cognac_Behourd.Class.Extensions;
using Cognac_Behourd.Class.Interfaces;

namespace Cognac_Behourd.Class
{
    public class Personne : IPesable
    {
        public Arme Arme { get; set; }
        public ArmureType ArmureType { get; set; }

        public string Prenom { get; set; }

        public string Nom { get; set; }

        public DateTime DateAdhesion { get; set; }

        public float Poids { get; set; }

        public DateTime DateDeNaissance { get; set; }

        public int Age { get => DateDeNaissance.GetAge(); }

        public int AnneeExperience { get => DateAdhesion.GetAge(); }

        public Personne(Arme arme, ArmureType armureType, string prenom, string nom, DateTime dateAdhesion, float poids, DateTime dateDeNaissance)
        {
            Arme = arme;
            ArmureType = armureType;
            Prenom = prenom;
            Nom = nom;
            DateAdhesion = dateAdhesion;
            Poids = poids;
            DateDeNaissance = dateDeNaissance;
        }

        public override string ToString()
        {
            return
                $"{Nom} {Prenom} - Arme: {Arme.Name}, Armure: {ArmureType.ToString()}, Categorie: {this.GetCategoriePoids().ToString()}, Age: {Age}ans, Experience:{AnneeExperience}ans";
        }
    }
}
