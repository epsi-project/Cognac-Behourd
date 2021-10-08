using Cognac_Behourd.Interfaces;

namespace Cognac_Behourd
{
    public class Core
    {
        private IInteractable _interactable;
        
        public Core(IInteractable interactable)
        {
            _interactable = interactable;
        }

        public void Run()
        {
            
        }
    }
}