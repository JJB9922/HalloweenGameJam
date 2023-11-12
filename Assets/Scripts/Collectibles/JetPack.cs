using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Collectibles
{
    public class JetPack : Collectible
    {
        public override void Initialise()
        {
            Name = "Alient Thruster DLC";
            Description = "I think it might make me fly...";
            CollectedText = "I should get out of here (Press CTRL to thrust yourself upwards)";

            base.Initialise();
        }

        public override void Collect()
        {
            base.Collect();
        }
    }
}
