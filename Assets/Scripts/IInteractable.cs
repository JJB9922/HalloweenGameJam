using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    interface IInteractable
    {
        public abstract void Initialise();
        public abstract void Interact();
    }
}
