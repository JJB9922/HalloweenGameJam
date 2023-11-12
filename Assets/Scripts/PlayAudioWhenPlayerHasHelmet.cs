using UnityEngine;

namespace Assets.Scripts
{
    public class PlayAudioWhenPlayerHasHelmet : MonoBehaviour
    {
        private AudioSource audioSource;

        public void Awake()
        {
            audioSource = GetComponent<AudioSource>();

            audioSource.enabled = false;
        }

        public void FixedUpdate()
        {
            if(PlayerInventory.Instance.HelmentCollected && !audioSource.enabled)
            {
                audioSource.enabled = true;
            }
        }
    }
}
