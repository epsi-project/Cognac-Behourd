using System;
using System.Collections.Generic;
using System.Linq;

namespace Cognac_Behourd.Class
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
            if (arrivant.Age < 16)
                throw new InvalidOperationException("Pas de behourd en dessous de 16 ans");
            
            Joueurs.Add(arrivant);
        }

        public void AjouterJoueurs(List<Personne> personnes)
        {
            if(personnes.Any(p => p.Age < 16))
                throw new InvalidOperationException("Pas de behourd en dessous de 16 ans");

            Joueurs.AddRange(personnes);
        }

        public void LancerProchainePartie()
        {
            PartieEnCours = new Partie(Joueurs);
        }

        public void SupprimerJoueur(Personne joueur)
        {
            if (Joueurs.Any(j => j == joueur))
                Joueurs.Remove(joueur);
            else
                throw new InvalidOperationException("Joueur non présent dans la partie");
        }

        public void SupprimerJoueurs(List<Personne> joueursQuiPartent)
        {
            if(joueursQuiPartent.Any(j => !Joueurs.Contains(j)))
                throw new InvalidOperationException("Joueur non présent dans la partie");
            
            Joueurs.RemoveAll(joueursQuiPartent.Contains);
        }
    }
}
