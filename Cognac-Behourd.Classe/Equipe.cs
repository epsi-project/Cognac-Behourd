using System;
using System.Collections.Generic;
using Cognac_Behourd.Class.Enumerations;

namespace Cognac_Behourd.Class
{
    public class Equipe
    {
        public Equipe()
        {
        }

        public List<Personne> Joueurs { get; }
        public CategoriePoids CategoriePoidsMoyen { get; }
        public int TotalAnneeExperience { get; }
    }
}
