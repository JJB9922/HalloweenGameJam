using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Collectibles
{
    class BatteryForRelic : RelicPart
    {
        private bool firstVisit = true;

        public override void Initialise()
        {
            this.Name = "Trade";
            this.Description = "It wants... batteries?";
            this.CollectedText = this.Description;
            
            base.Initialise();

            this.InteractText = "Press E to Trade";
        }

        public override void Interact()
        {
            if (!PlayerInventory.Instance.HelmentCollected)
            {
                GameManager.Instance.ShowInformationText($"I don't understand what it is saying.");
                return;
            }

            if(firstVisit)
            {
                GameManager.Instance.ShowInformationText($"It wants... batteries?");
                firstVisit = false;
                return;
            }

            if (PlayerInventory.Instance.Batteries < 3)
            {
                GameManager.Instance.ShowInformationText($"I don't have enough batteries, I should find more.");
                return;
            }


            base.Collect();
        }
    }
}
