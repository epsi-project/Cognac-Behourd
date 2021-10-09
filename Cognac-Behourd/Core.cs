using System;
using System.Collections.Generic;
using System.Globalization;
using Cognac_Behourd.Interfaces;
using System.Linq;
using System.Threading;
using Cognac_Behourd.Class;
using Cognac_Behourd.Class.Builders;
using Cognac_Behourd.Class.Enumerations;
using Cognac_Behourd.Enumerations;

namespace Cognac_Behourd
{
    public class Core
    {
        private readonly IInteractable _interactable;
        private readonly Session _session;
        
        public Core(IInteractable interactable)
        {
            _session = new Session();
            _interactable = interactable;
        }

        public void Run()
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");
            
            bool exit = false;
            while (!exit)
            {
                switch (ChooseEnumOption<MenuOption>())
                {
                    case MenuOption.AjouterUnMembre:
                        AjouterUnMembre();
                        break;
                    case MenuOption.LancerLaPartie:
                        LancerLaPartie();
                        break;
                    case MenuOption.AfficherToutLesJoueurs:
                        AfficherToutLesJoueurs();
                        break;
                    case MenuOption.AfficherLesEquipesDeLaPartieEnCours:
                        break;
                    case MenuOption.Quitter:
                        exit = true;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }                
            }

        }

        private T ChooseEnumOption<T>() where T : struct
        {
            T result;

            do
            {
                ShowEnumOptions(typeof(T));
                _interactable.Ecrire("Choisissez une option :\n");
            } while (!TryParseEnumOption(out result));

            return result;
        }

        private void ShowEnumOptions(Type enumType)
        {
            List<string> options = Enum.GetNames(enumType).Zip((int[])Enum.GetValues(enumType))
                .Select(tuple => $"{tuple.Second} - {tuple.First}\n")
                .ToList();

            foreach (string option in options)
                _interactable.Ecrire(option);
        }

        private bool TryParseEnumOption<T>(out T value) where T : struct
        {
            return Enum.TryParse(_interactable.Lire(), out value);
        }

        private void AjouterUnMembre()
        {
            PersonneBuilder personneBuilder = new PersonneBuilder();
            
            _interactable.Ecrire("Choisissez un nom puis un prénom :");
            personneBuilder.SetNomPrenom(_interactable.Lire(), _interactable.Lire());
            
            _interactable.Ecrire("Choisissez une arme :");
            personneBuilder.SetArme(new Arme(_interactable.Lire()));
            
            _interactable.Ecrire("Choisissez une armure :");
            personneBuilder.SetArmure(ChooseEnumOption<ArmureType>());
            
            _interactable.Ecrire("Entrez le poids :");
            personneBuilder.SetPoids(float.Parse(_interactable.Lire()));
            
            _interactable.Ecrire("Entrez la date de naissance :");
            personneBuilder.SetDateNaissance(DateTime.ParseExact(_interactable.Lire(), "dd/MM/yyyy", null));

            try
            {
                _session.AjouterJoueur(personneBuilder.Build());
            }
            catch (InvalidOperationException exception)
            {
                _interactable.Ecrire(exception.Message);
            }
        }

        private void LancerLaPartie()
        {
            _session.LancerProchainePartie();
            _interactable.Ecrire("La partie est prête!\n");
        }

        private void AfficherToutLesJoueurs()
        {
            foreach (Personne personne in _session.Joueurs)
                _interactable.Ecrire(personne.ToString());
        }
    }
}