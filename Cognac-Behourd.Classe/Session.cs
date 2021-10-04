using System;
using System.Collections.Generic;
using Cognac_Behourd.Class;

namespace Cognac_Behourd.Classe
{
    public class Session
    {
        public Session()
        {
            Joueurs = new List<Personne>();
        }
    
        public Partie PartieEnCours { get; set; }
   
        public List<Personne> Joueurs { get; set; }

        public void AjouterJoueur(Personne arrivant)
        {
            Joueurs.Add(arrivant);
        }

        public void AjouterJoueurs(IEnumerable<Personne> personnes)
        {
            Joueurs.AddRange(personnes);
        }

        public void LancerProchainePartie()
        {
            this.PartieEnCours = new Partie(Joueurs);
        }
    }
}
