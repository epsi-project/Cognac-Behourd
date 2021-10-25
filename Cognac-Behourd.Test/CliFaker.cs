using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Cognac_Behourd.Class;
using Cognac_Behourd.Enumerations;
using Cognac_Behourd.Interfaces;

namespace Cognac_Behourd.Test
{
    public class CliFaker : IInteractable
    {
        public List<string> Resultats { get; }

        private readonly List<string> _reponses;
        private IEnumerator<string> _reponsesEnumerator;

        public CliFaker()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
            
            Resultats = new List<string>();
            _reponses = new List<string>();
        }

        public void Ecrire(string text) => Resultats.Add(text);

        public string Lire()
        {
            _reponsesEnumerator ??= _reponses.GetEnumerator();
            
            _reponsesEnumerator.MoveNext();

            return _reponsesEnumerator.Current;
        }

        public void ChoisirMenu(MenuOption menuOption)
        {
            AddReponse(((int)menuOption).ToString());
        } 

        public void EntrerPersonne(Personne personne)
        {
            AddReponse(personne.Nom);
            AddReponse(personne.Prenom);
            AddReponse(personne.Arme.Name);
            AddReponse(((int)personne.ArmureType).ToString());
            AddReponse(personne.Poids.ToString(CultureInfo.InvariantCulture));
            AddReponse(personne.DateDeNaissance.ToShortDateString());
        }

        private void AddReponse(string reponse)
        {
            if (_reponsesEnumerator != null)
                throw new InvalidOperationException("Les reponses sont bloqués");

            _reponses.Add(reponse);
        }
    }
}