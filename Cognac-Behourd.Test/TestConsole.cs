using Cognac_Behourd.Class;
using Cognac_Behourd.Class.Builders;
using Cognac_Behourd.Enumerations;
using Xunit;

namespace Cognac_Behourd.Test
{
    public class TestConsole
    {
        [Fact]
        public void On_Peux_Ajouter_Un_Joueur()
        {
            Personne personneAjoutee = new PersonneBuilder()
                .SetRandomNomPrenom()
                .Build();
            
            CliFaker cliFaker = new CliFaker();
            cliFaker.ChoisirMenu(MenuOption.AjouterUnMembre);
            cliFaker.EntrerPersonne(personneAjoutee);
            
            cliFaker.ChoisirMenu(MenuOption.AfficherToutLesJoueurs);
            cliFaker.ChoisirMenu(MenuOption.Quitter);
            
            new Core(cliFaker).Run();
            
            CheckPersonneIsInResults(personneAjoutee, cliFaker);
        }
        
        [Fact]
        public void On_Peux_Lancer_Une_Partie()
        {
            CliFaker cliFaker = new CliFaker();
            
            cliFaker.ChoisirMenu(MenuOption.LancerLaPartie);
            cliFaker.ChoisirMenu(MenuOption.Quitter);
            
            new Core(cliFaker).Run();
            
            Assert.Contains("La partie est prête!\n", cliFaker.Resultats); 
        }

        [Fact]
        public void On_Peux_Afficher_Les_Joueurs_De_La_Partie_En_Cours()
        {
            Personne personneAjoutee = new PersonneBuilder()
                .SetRandomNomPrenom()
                .Build();

            CliFaker cliFaker = new CliFaker();
            cliFaker.ChoisirMenu(MenuOption.AjouterUnMembre);
            cliFaker.EntrerPersonne(personneAjoutee);
            
            cliFaker.ChoisirMenu(MenuOption.LancerLaPartie);
            cliFaker.ChoisirMenu(MenuOption.AfficherLesEquipesDeLaPartieEnCours);
            
            cliFaker.ChoisirMenu(MenuOption.Quitter);
            
            new Core(cliFaker).Run();
            
            CheckPersonneIsInResults(personneAjoutee, cliFaker);
        }

        private static void CheckPersonneIsInResults(Personne personne, CliFaker cliFaker)
        {
            Assert.Contains(cliFaker.Resultats, r => r.Contains(personne.Nom) && r.Contains(personne.Prenom));
        }
    }
}