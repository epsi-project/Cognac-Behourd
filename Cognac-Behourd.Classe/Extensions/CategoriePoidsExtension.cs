using System.Collections.Generic;
using System.Linq;
using Cognac_Behourd.Class.Enumerations;
using Cognac_Behourd.Class.Interfaces;

namespace Cognac_Behourd.Class.Extensions
{
    public static class CategoriePoidsExtension
    {
        private static readonly Dictionary<int, CategoriePoids> CategorieParPoidsMax = new Dictionary<int, CategoriePoids>()
        {
            { 52, CategoriePoids.Mouches },
            { 57, CategoriePoids.Plumes },
            { 63, CategoriePoids.Legers },
            { 69, CategoriePoids.Welters },
            { 75, CategoriePoids.Moyens },
            { 81, CategoriePoids.MiLourds },
            { 91, CategoriePoids.Lourds },
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
            int key = CategorieParPoidsMax.Keys.OrderBy(k => k).First(k => k > poids);
            return CategorieParPoidsMax[key];
        }
    }
}
