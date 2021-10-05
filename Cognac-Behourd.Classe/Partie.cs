using System;
using System.Collections.Generic;
using System.Linq;
using Cognac_Behourd.Class.Extensions;

namespace Cognac_Behourd.Class
{
    public class Partie
    {
        public Partie(List<Personne> joueurs)
        {
            Joueurs = joueurs;
            EquilibrageDesEquipes();
        }

        public void EquilibrageDesEquipes()
        {
            int quart = Joueurs.Count / 4;
            int troisQuart = quart * 3;
            int moitier = Joueurs.Count / 2;

            Personne[] joueurTrie = Joueurs
                .OrderBy(p => p.GetCategoriePoids())
                .ThenBy(p => p.DateAdhesion)
                .ToArray();

            List<Personne> joueursEquipeUn = joueurTrie
                .Take(quart)
                .Concat(
                    joueurTrie
                    .Skip(troisQuart)
                    .Take(quart)
                ).ToList();

            List<Personne> joueursEquipeDeux = Joueurs
                .Skip(quart)
                .Take(moitier)
                .ToList();

            EquipeUn = new Equipe(joueursEquipeUn);
            EquipeDeux = new Equipe(joueursEquipeDeux);
        }

        public List<Personne> Joueurs { get; set; }
        public Equipe EquipeUn { get; set; }
        public Equipe EquipeDeux { get; set; }
    }
}
