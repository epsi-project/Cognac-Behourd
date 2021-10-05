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
        public Equipe EquipeUn { get; set; }
        public Equipe EquipeDeux { get; set; }
    }
}
