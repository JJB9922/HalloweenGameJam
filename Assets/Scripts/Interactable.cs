using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Interactable : MonoBehaviour, IInteractable, IEntity
    {
        public string Name { get; protected set; }
        public string InteractText { get; protected set; }
        public int ID { get; set; }

        public event Action<Interactable> OnInteracted;
        public event Action<Interactable> OnPlayerNear;
        public event Action<Interactable> OnPlayerLeft;

        public KeyCode InteractKey = KeyCode.E;

        private bool playerIsNear = false;

        private float distance;

        public float interactDistance = 2f;

        public Transform playerBody;

        public Transform interactableTransform;

        public void Start()
        {
            ID = UnityEngine.Random.Range(0, 10000);
            interactableTransform = transform;
        }

        public virtual void Initialise()
        {
            InteractText = $"Press {InteractKey.ToString()} to {InteractText}";
        }

        private void Update()
        {
            distance = Vector3.Distance(interactableTransform.position, playerBody.position);

            if (distance <= interactDistance)
            {
                playerIsNear = true;

                this.OnPlayerNear?.Invoke(this);
            }
            else
            {
                if (playerIsNear)
                {
                    this.OnPlayerLeft?.Invoke(this);
                }

                playerIsNear = false;
            }

            if (playerIsNear && Input.GetKeyDown(InteractKey))
            {
                Interact();
            }
        }

        private void OnDrawGizmos()
        {
            interactableTransform = transform;
            distance = Vector3.Distance(interactableTransform.position, playerBody.position);
            Gizmos.color = Color.white;
            Gizmos.DrawLine(interactableTransform.position, playerBody.position);

            if (distance <= interactDistance)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(interactableTransform.transform.position, interactDistance);
            }
            else
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawSphere(interactableTransform.transform.position, interactDistance);
            }
        }

        protected void PlayerLeft()
        {
            OnPlayerLeft?.Invoke(this);
        }

        public virtual void Interact()
        {
            return;
        }
    }
}
