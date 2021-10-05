using System;
using System.Collections.Generic;
using System.Linq;

namespace Cognac_Behourd.Class
{
    public class Partie
    {
        public Partie(List<Personne> joueurs)
        {
            Joueurs = joueurs;
            EquilibrageDesEquipe();
        }

        public void EquilibrageDesEquipe()
        {
            int nombreJoueurEquipeUn = Joueurs.Count / 2;
            var joueurEquipeUn = Joueurs.Take(nombreJoueurEquipeUn).ToList();
            var joueurEquipeDeux = Joueurs.Skip(nombreJoueurEquipeUn).ToList();

            EquipeUn = new Equipe(joueurEquipeUn);
            EquipeDeux = new Equipe(joueurEquipeDeux);
        }

        public List<Personne> Joueurs { get; set; }
        public Equipe EquipeUn { get; set; }
        public Equipe EquipeDeux { get; set; }
    }
}
