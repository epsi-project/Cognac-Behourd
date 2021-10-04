using System;
using Xunit;
using Cognac_Behourd.Classe;
using System.Collections.Generic;
using Cognac_Behourd.Class;
using System.Linq;

namespace Cognac_Behourd.Test
{
    public class UnitTest1
    {
        [Fact]
        public void Les_Armes_Sont_Fixes_Elles_Ne_Changent_Pas_Sur_Une_Session()
        {
            Session session = new Session();

            IEnumerable<Arme> armesDesJoueursInitiaux = session.PartieEnCours.Joueurs.Select(j => j.Arme);

            session.LancerProchainePartie();

            IEnumerable<Arme> armesDesJoueursSuivants = session.PartieEnCours.Joueurs.Select(j => j.Arme);

            Assert.Equal(armesDesJoueursSuivants, armesDesJoueursInitiaux);
        }

        [Fact]
        public void Les_Armures_Sont_Fixes_Elles_Ne_Changent_Pas_Sur_Une_Session()
        {
            Session session = new Session();

            IEnumerable<Armure> armuresDesJoueursInitiaux = session.PartieEnCours.Joueurs.Select(j => j.Armure);

            session.LancerProchainePartie();

            IEnumerable<Armure> armuresDesJoueursSuivants = session.PartieEnCours.Joueurs.Select(j => j.Armure);

            Assert.Equal(armuresDesJoueursSuivants, armuresDesJoueursInitiaux);
        }

        [Fact]
        public void Une_Personne_Qui_Rejoint_La_Session_Ne_Rejoint_Pas_La_Session_Avant_La_Partie_Suivante()
        {
            Personne arrivant = new Personne();

            Session session = new Session();

            IEnumerable<Personne> joueursInitiaux = session.PartieEnCours.Joueurs;

            session.AjouterJoueur(arrivant);

            IEnumerable<Personne> joueursApresAjout = session.PartieEnCours.Joueurs;

            Assert.Equal(joueursInitiaux, joueursApresAjout);
        }
    }
}
