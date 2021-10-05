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
            int quart = Joueurs.Count / 4;
            int troisQuart = quart * 3;
            int moitier = Joueurs.Count / 2;

            Personne[] joueurTrie = Joueurs
                .OrderBy(p => p.Poids)
                .ThenBy(p => p.DateAdhesion)
                .ToArray();

            List<Personne> joueurEquipeUn = joueurTrie
                .Take(quart)
                .Concat(
                    joueurTrie
                    .Skip(troisQuart)
                    .Take(quart)
                ).ToList();

            List<Personne> joueurEquipeDeux = Joueurs
                .Skip(quart)
                .Take(moitier)
                .ToList();

            EquipeUn = new Equipe(joueurEquipeUn);
            EquipeDeux = new Equipe(joueurEquipeDeux);
        }

        public List<Personne> Joueurs { get; set; }
        public Equipe EquipeUn { get; set; }
        public Equipe EquipeDeux { get; set; }
    }
}
