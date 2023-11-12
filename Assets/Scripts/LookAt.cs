using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class LookAt : MonoBehaviour
    {
        public Transform Target;
        public float MinDistance = 12f;

        public void Update()
        {
            if (!PlayerInventory.Instance.HelmentCollected) return;

            var distance = Vector3.Distance(transform.position, Target.position);

            if (distance <= MinDistance)
            {
                transform.LookAt(Target);
            }
        }

        private void OnDrawGizmos()
        {
            if (Target == null) return;

            var distance = Vector3.Distance(transform.position, Target.position);
            Gizmos.color = Color.white;
            Gizmos.DrawLine(transform.position, Target.position);

            if (distance <= MinDistance)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(transform.position, MinDistance);
            }
            else
            {
                Gizmos.color = Color.green;
                Gizmos.DrawSphere(transform.position, MinDistance);
            }
        }
    }
}
