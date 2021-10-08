using System;
using System.Collections.Generic;
using Cognac_Behourd.Class;
using Cognac_Behourd.Class.Builders;
using Cognac_Behourd.Class.Enumerations;
using Cognac_Behourd.Classe;
using Xunit;

namespace Cognac_Behourd.Test
{
    public class TestEquilibrage
    {
        [Fact]
        public void Les_Equipes_Sont_Equilibres_En_Nombre()
        {
            Session session = new Session();

            session.AjouterJoueurs(new PersonneBuilder().Build(4));

            session.LancerProchainePartie();

            int nombreDeJoueursEquipeUn = session.PartieEnCours.EquipeUn.Joueurs.Count;
            int nombreDeJoueursEquipeDeux = session.PartieEnCours.EquipeDeux.Joueurs.Count;

            Assert.Equal(nombreDeJoueursEquipeUn, nombreDeJoueursEquipeDeux);
        }

        [Fact]
        public void Les_Equipes_Sont_Equilibres_En_Poids()
        {
            Session session = new Session();

            List<Personne> joueursSoixanteKilo = new PersonneBuilder()
                .SetPoids(60f)
                .Build(4);

            List<Personne> joueursCentKilo = new PersonneBuilder()
                .SetPoids(100f)
                .Build(4);

            session.AjouterJoueurs(joueursSoixanteKilo);
            session.AjouterJoueurs(joueursCentKilo);

            session.LancerProchainePartie();

            CategoriePoids categoriePoidsEquipeUn = session.PartieEnCours.EquipeUn.CategoriePoidsMoyen;
            CategoriePoids categoriePoidsEquipeDeux = session.PartieEnCours.EquipeDeux.CategoriePoidsMoyen;

            Assert.Equal(categoriePoidsEquipeUn, categoriePoidsEquipeDeux);
        }

        [Fact]
        public void Les_Equipes_Sont_Equilibres_En_Experience()
        {
            Session session = new Session();

            PersonneBuilder personneBuilder = new PersonneBuilder()
                .SetPoids(70f);

            List<Personne> joueursExperimentes = personneBuilder
                .SetDateAdhesion(DateTime.Today.AddYears(-10))
                .Build(4);

            List<Personne> joueursNonExperimentes = personneBuilder
                .SetDateAdhesion(DateTime.Today.AddYears(-1))
                .Build(4);

            session.AjouterJoueurs(joueursExperimentes);
            session.AjouterJoueurs(joueursNonExperimentes);

            session.LancerProchainePartie();

            int anneesExperienceMoyenneEquipeUn = session.PartieEnCours.EquipeUn.TotalAnneeExperience;
            int anneesExperienceMoyenneEquipeDeux = session.PartieEnCours.EquipeDeux.TotalAnneeExperience;

            Assert.Equal(anneesExperienceMoyenneEquipeUn, anneesExperienceMoyenneEquipeDeux);
        }
    }
}
