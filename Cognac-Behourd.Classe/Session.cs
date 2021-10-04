using System;
using System.Collections.Generic;
using Cognac_Behourd.Class;

namespace Cognac_Behourd.Classe
{
    public class Session
    {
        public Session()
        {

        }
    
        public Partie PartieEnCours { get; set; }
   
        public List<Personne> Joueurs { get; set; }

        public void AjouterJoueur(Personne arrivant)
        {
            throw new NotImplementedException();
        }

        public void LancerProchainePartie()
        {
            throw new NotImplementedException();
        }
    }
}
