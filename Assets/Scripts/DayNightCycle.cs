using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class DayNightCycle : MonoBehaviour
    {
        public Light Sun;

        public float TimeOfDay = 0;

        private float step = 0.01f;
        private bool rising = true;

        public void FixedUpdate()
        {
            if((Sun.intensity >= 1) && rising)
            {
                rising = false;
            }

            if((Sun.intensity <= 0) && !rising)
            {
                rising = true;
            }

            if(rising)
            {
                Sun.intensity += step * Time.deltaTime;
            }
            else
            {
                Sun.intensity -= step * Time.deltaTime;
            }
        }
    }
}
