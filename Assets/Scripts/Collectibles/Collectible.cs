using Assets.Scripts;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Collectible : Interactable, ICollectible, IEntity
    {
        public GameObject collectTextPrefab; // Assign the Text UI prefab element in the Inspector
        private GameObject collectText;
        public KeyCode collectKey = KeyCode.E;
        public bool canCollect = true;
        public string collectibleIngameName;
        public int audioManagerClipID;  // the AI will say the name of the object when in sight
        public GameObject EnableObjectOnCollect; // enables a game object when this object is collected. e.g. used for the helmet

        public string Description { get; protected set; }
        
        public string CollectedText { get; protected set; }
        
        public event Action<Collectible> OnCollected;
        public event Action<Collectible, string> OnCollectFailed;



        public override void Initialise()
        {
            InteractText = $"Press {collectKey.ToString()} to collect {Name}";
        }



        public virtual void Collect()
        {
            // collect sound
            if (audioManagerClipID != -1)
            {
                AudioManager.instance.PlaySoundEffect(audioManagerClipID);
            }

            if (EnableObjectOnCollect != null)
            {
                EnableObjectOnCollect.gameObject.SetActive(true);
            }

            this.OnCollected?.Invoke(this);
            PlayerLeft();

            interactableTransform.gameObject.SetActive(false);
        }

        public void Collected(Collectible c)
        {
            this.OnCollected?.Invoke(c);
        }

        protected virtual void CollectFailed(Collectible c, string message)
        {
            OnCollectFailed?.Invoke(c, message);
        }

        public override void Interact()
        {
            Collect();
        }
    }
}