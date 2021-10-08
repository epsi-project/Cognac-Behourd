using System.Linq;
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
                .SetNomPrenom("OIRY", "Théo")
                .Build();
            
            CliFaker cliFaker = new CliFaker();
            cliFaker.ChoisirMenu(MenuOption.AjouterUnMembre);
            cliFaker.EntrerPersonne(personneAjoutee);
            
            cliFaker.ChoisirMenu(MenuOption.AfficherToutLesJoueurs);

            new Core(cliFaker).Run();
            
            Assert.Contains(cliFaker.Resultats, r => r.Contains("OIRY") && r.Contains("Théo"));
        }
        
        [Fact]
        public void On_Peux_Lancer_Une_Partie()
        {
            CliFaker cliFaker = new CliFaker();
            
            cliFaker.ChoisirMenu(MenuOption.LancerLaPartie);
            
            new Core(cliFaker).Run();
            
            Assert.Equal("La partie est prête!", cliFaker.LastResult); 
        }
    }
}