using System;
using Xunit;
using Cognac_Behourd.Classe;
using System.Collections.Generic;
using Cognac_Behourd.Class;
using System.Linq;
using Cognac_Behourd.Class.Builders;

namespace Cognac_Behourd.Test
{
    public class TestParties
    {
        [Fact]
        public void Les_Armes_Sont_Fixes_Elles_Ne_Changent_Pas_Sur_Une_Session()
        {
            Session session = new Session();

            session.AjouterJoueurs(new PersonneBuilder().Build(4));
            session.LancerProchainePartie();

            IEnumerable<Arme> armesDesJoueursInitiaux = session.PartieEnCours.Joueurs.Select(j => j.Arme);

            session.LancerProchainePartie();

            IEnumerable<Arme> armesDesJoueursSuivants = session.PartieEnCours.Joueurs.Select(j => j.Arme);

            Assert.Equal(armesDesJoueursSuivants, armesDesJoueursInitiaux);
        }

        [Fact]
        public void Les_Armures_Sont_Fixes_Elles_Ne_Changent_Pas_Sur_Une_Session()
        {
            Session session = new Session();

            session.AjouterJoueurs(new PersonneBuilder().Build(4));
            session.LancerProchainePartie();

            IEnumerable<Armure> armuresDesJoueursInitiaux = session.PartieEnCours.Joueurs.Select(j => j.Armure);

            session.LancerProchainePartie();

            IEnumerable<Armure> armuresDesJoueursSuivants = session.PartieEnCours.Joueurs.Select(j => j.Armure);

            Assert.Equal(armuresDesJoueursSuivants, armuresDesJoueursInitiaux);
        }

        [Fact]
        public void Une_Personne_Qui_Rejoint_La_Session_Ne_Rejoint_Pas_La_Session_Avant_La_Partie_Suivante()
        {
            Session session = new Session();

            Personne joueurDeDepart = new PersonneBuilder().Build();

            Personne arrivant = new PersonneBuilder().Build();

            session.AjouterJoueur(joueurDeDepart);

            session.LancerProchainePartie();

            IEnumerable<Personne> joueursInitiaux = session.PartieEnCours.Joueurs;

            session.AjouterJoueur(arrivant);

            IEnumerable<Personne> joueursApresAjout = session.PartieEnCours.Joueurs;

            Assert.Equal(joueursInitiaux, joueursApresAjout);
        }

        [Fact]
        public void Une_Personne_Qui_Rejoint_La_Session_A_Plus_De_16_ans()
        {
            Session session = new Session();

            DateTime moinsDeSeizeAns = DateTime.Today.AddYears(-15);
            DateTime plusDeSeizeAns = DateTime.Today.AddYears(-20);

            List<Personne> joueurs = new PersonneBuilder()
                .SetDateNaissance(plusDeSeizeAns)
                .Build(10);

            joueurs.AddRange(new PersonneBuilder()
                .SetDateNaissance(moinsDeSeizeAns)
                .Build(2));

            Assert.Throws<InvalidOperationException>(() => session.AjouterJoueurs(joueurs));
            Assert.Empty(session.Joueurs);
        }
    }
}
