using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Collectibles
{
    public class Battery : Collectible
    {
        public override void Initialise()
        {
            this.Name = "Battery";
            this.Description = "POWAAAA";

            base.Initialise();
        }

        public override void Collect()
        {
            base.Collect();
        }
    }
}
