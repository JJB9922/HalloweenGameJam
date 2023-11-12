using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Collectibles
{
    public class Helmet : Collectible
    {
        public override void Initialise()
        {
            Name = "Alien Head";
            Description = "Old trusty...";
            CollectedText = "You put on the Alien Head. It is... Snug.";
            
            base.Initialise();
        }

        public override void Collect()
        {
            base.Collect();
        }
    }
}
