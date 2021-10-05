using System;
using System.Collections.Generic;
using System.Linq;
using Cognac_Behourd.Class;

namespace Cognac_Behourd.Classe
{
    public class Session
    {
        public Session()
        {
            Joueurs = new List<Personne>();
        }
    
        public Partie PartieEnCours { get; private set; }
   
        public List<Personne> Joueurs { get; private set; }

        public void AjouterJoueur(Personne arrivant)
        {
            if (arrivant.Age < 16)
                throw new InvalidOperationException("Pas de behourd en dessous de 16 ans");
            
            Joueurs.Add(arrivant);
        }

        public void AjouterJoueurs(IEnumerable<Personne> personnes)
        {
            if(personnes.Any(p => p.Age < 16))
                throw new InvalidOperationException("Pas de behourd en dessous de 16 ans");

            Joueurs.AddRange(personnes);
        }

        public void LancerProchainePartie()
        {
            PartieEnCours = new Partie(Joueurs);
        }
    }
}
