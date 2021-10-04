using System;
using System.Collections.Generic;

namespace Cognac_Behourd.Class
{
    public class Partie
    {
        public Partie(List<Personne> joueurs)
        {
            Joueurs = joueurs;
        }

        public List<Personne> Joueurs { get; set; }
    }
}
