using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Collectibles
{
    public class RelicPart : Collectible
    {
        public override void Initialise()
        {
            this.Name = "Relic Part";
            this.Description = "This looks like part of an old key.";
            this.CollectedText = this.Description;

            base.Initialise();
        }
    }
}
