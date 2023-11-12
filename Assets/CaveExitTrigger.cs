using Assets.Scripts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Assets
{
    public class CaveExitTrigger : Interactable
    {
        public override void Initialise()
        {
            InteractText = "Exit Cave";

            base.Initialise();

            base.OnPlayerNear += Enter;
        }

        private void Enter(Interactable i)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
