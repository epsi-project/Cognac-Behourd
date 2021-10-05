using System;
using System.Collections.Generic;
using System.Linq;
using Cognac_Behourd.Class.Enumerations;
using Cognac_Behourd.Class.Extensions;

namespace Cognac_Behourd.Class
{
    public class Equipe
    {
        public List<Personne> Joueurs { get; }

        public CategoriePoids CategoriePoidsMoyen { get => Joueurs.GetCategoriePoidsMoyen(); }
        public int TotalAnneeExperience { get => Joueurs.Sum(j => j.AnneeExperience); }

        public Equipe(List<Personne> joueurs)
        {
            Joueurs = joueurs;
        }

    }
}
