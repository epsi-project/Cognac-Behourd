using System;
using System.Collections.Generic;
using System.Linq;
using Cognac_Behourd.Class.Enumerations;
using Cognac_Behourd.Class.Interfaces;

namespace Cognac_Behourd.Class.Extensions
{
    public static class CategoriePoidsExtension
    {
        private static readonly Dictionary<int, CategoriePoids> categorieParPoidsMax = new Dictionary<int, CategoriePoids>()
        {
            { 52, CategoriePoids.Mouches },
            { 57, CategoriePoids.Legers },
            { 63, CategoriePoids.Lourds },
            { 69, CategoriePoids.Legers },
            { 75, CategoriePoids.Welters },
            { 81, CategoriePoids.Moyens },
            { 91, CategoriePoids.MiLourds },
            { int.MaxValue, CategoriePoids.SuperLourds },
        };

        public static CategoriePoids GetCategoriePoids(this IPesable pesable)
        {
            return GetCategoriePoidsParPoids(pesable.Poids);
        }

        public static CategoriePoids GetCategoriePoidsMoyen(this IEnumerable<IPesable> pesables)
        {
            return GetCategoriePoidsParPoids(pesables.Average(p => p.Poids));
        }

        public static CategoriePoids GetCategoriePoidsParPoids(float poids)
        {
            int key = categorieParPoidsMax.Keys.OrderBy(k => k).First(k => k < poids);
            return categorieParPoidsMax[key];
        }
    }
}
