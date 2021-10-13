using System;
using Xunit;
using System.Collections.Generic;
using Cognac_Behourd.Class;
using System.Linq;
using Cognac_Behourd.Class.Builders;
using Cognac_Behourd.Class.Enumerations;

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

            IEnumerable<Arme> armesDesJoueursInitiaux = session.PartieEnCours.Joueurs.Select(j => j.Arme).ToArray();

            session.LancerProchainePartie();

            IEnumerable<Arme> armesDesJoueursSuivants = session.PartieEnCours.Joueurs.Select(j => j.Arme).ToArray();

            Assert.Equal(armesDesJoueursSuivants, armesDesJoueursInitiaux);
        }

        [Fact]
        public void Les_Armures_Sont_Fixes_Elles_Ne_Changent_Pas_Sur_Une_Session()
        {
            Session session = new Session();

            session.AjouterJoueurs(new PersonneBuilder().Build(4));
            session.LancerProchainePartie();

            IEnumerable<ArmureType> armuresDesJoueursInitiaux = session.PartieEnCours.Joueurs.Select(j => j.ArmureType).ToArray();

            session.LancerProchainePartie();

            IEnumerable<ArmureType> armuresDesJoueursSuivants = session.PartieEnCours.Joueurs.Select(j => j.ArmureType).ToArray();

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

            IEnumerable<Personne> joueursInitiaux = session.PartieEnCours.Joueurs.ToArray();

            session.AjouterJoueur(arrivant);

            IEnumerable<Personne> joueursApresAjout = session.PartieEnCours.Joueurs.ToArray();

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

        [Fact]
        public void Une_Personne_Peux_Quitter_Une_Session_En_Cours()
        {
            Session session = new Session();

            Personne joueurDeDepart = new PersonneBuilder().Build();

            session.AjouterJoueur(joueurDeDepart);

            session.LancerProchainePartie();

            Assert.NotEmpty(session.PartieEnCours.Joueurs);

            session.SupprimerJoueur(joueurDeDepart);

            session.LancerProchainePartie();

            Assert.Throws<InvalidOperationException>(() => session.SupprimerJoueur(new PersonneBuilder().Build()));
            Assert.Empty(session.PartieEnCours.Joueurs);
        }

        [Fact]
        public void Des_Personnes_Peuvent_Quitter_Une_Session_En_Cours()
        {
            Session session = new Session();

            List<Personne> joueursDeDepart = new PersonneBuilder().Build(6);

            List<Personne> joueursQuiPartent = joueursDeDepart.Take(2).ToList();

            List<Personne> personnesQuiNexistePas = new PersonneBuilder().Build(1);

            session.AjouterJoueurs(joueursDeDepart);

            session.LancerProchainePartie();

            session.SupprimerJoueurs(joueursQuiPartent);

            session.LancerProchainePartie();

            Assert.Throws<InvalidOperationException>(() => session.SupprimerJoueurs(personnesQuiNexistePas));            
            Assert.Equal(joueursDeDepart.Count() - joueursQuiPartent.Count(), session.PartieEnCours.Joueurs.Count);
            Assert.DoesNotContain(session.PartieEnCours.Joueurs, j => joueursQuiPartent.Contains(j));
        }
    }
}