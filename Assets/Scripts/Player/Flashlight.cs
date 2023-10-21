using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayerController{


    public class Flashlight : MonoBehaviour
    {

        public float flashlightBatteryLife = 8f; // Set the initial battery life in seconds
        public float flashlightBatteryTimer;   
        private bool showNotification = false;
        private float notificationTimer = 2f;
        public bool flashlightOn; 
        [SerializeField] private Light flashlightLight;
        [SerializeField] private GameObject batteryNotificationText;

        // Start is called before the first frame update
        void Start()
        {
            batteryNotificationText.gameObject.SetActive(false);
            flashlightLight.gameObject.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {
            if (flashlightOn)
            {
                flashlightBatteryTimer -= Time.deltaTime;

                // Check if the battery has run out
                if (flashlightBatteryTimer <= 0)
                {
                    flashlightOn = false;
                    flashlightLight.gameObject.SetActive(false);
                }
            }

            // Toggle the flashlight on/off
            if (Input.GetKeyDown(KeyCode.F))
            {
                flashlightOn = !flashlightOn;

                flashlightLight.gameObject.SetActive(flashlightOn);
            }

            // Recharge the flashlight when "G" is pressed
            if (Input.GetKeyDown(KeyCode.G))
            {
                flashlightBatteryTimer = flashlightBatteryLife;
                showNotification = true;
                
            }
            
            if(showNotification){
                batteryNotificationText.gameObject.SetActive(showNotification);
                notificationTimer -= Time.deltaTime;
                if(notificationTimer <= 0){
                    showNotification = false;
                    batteryNotificationText.gameObject.SetActive(showNotification);
                }
            }
        }
        }
    }
    
