using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemyInteractable : Interactable
    {
        public string SayThis;

        public override void Initialise()
        {
            InteractText = "Speak";

            base.Initialise();
        }

        public override void Interact()
        {
            if (!PlayerInventory.Instance.HelmentCollected)
            {
                GameManager.Instance.ShowInformationText($"It makes... noises... I need to find something to understand them.");
                return;
            }

            GameManager.Instance.ShowInformationText($"{SayThis}");
        }
    }
}