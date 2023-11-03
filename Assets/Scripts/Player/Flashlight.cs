using UnityEngine;

namespace PlayerController
{
    public class Flashlight : MonoBehaviour
    {
        public float flickerTime = 10f;
        public float flashlightBatteryLife = 8f; // Set the initial battery life in seconds
        public float flashlightBatteryTimer;
        private bool showNotification = false;
        private float notificationTimer = 2f;
        private int batteries = 0;
        public bool flashlightOn;
        public GameObject ControlsTextBatteries;

        [SerializeField] private LightFlickerEffect flashlightFlickerEffect;
        [SerializeField] private Light flashlightLight;
        [SerializeField] private GameObject batteryNotificationText;

        [SerializeField] private int switchFXId;
        [SerializeField] private int insertBatteryFXId;
        

        // Start is called before the first frame update
        void Start()
        {
            batteryNotificationText.gameObject.SetActive(false);
            flashlightLight.gameObject.SetActive(false);
            PlayerInventory.Instance.IncrementBatteries(3);
            batteries = PlayerInventory.Instance.Batteries;
        }

        // Update is called once per frame
        void Update()
        {
            if (flashlightOn)
            {
                flashlightBatteryTimer -= Time.deltaTime;

                // The flashlight will flicker during the last 5 seconds of battery life
                flashlightFlickerEffect.enabled = flashlightBatteryTimer < flickerTime;
                
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

                AudioManager.instance.PlaySoundEffect(switchFXId);
            }

            // Recharge the flashlight when "G" is pressed
            if (!flashlightOn && Input.GetKeyDown(KeyCode.G))
            {
                if (batteries > 0)
                {
                    flashlightBatteryTimer = flashlightBatteryLife;
                    showNotification = true;
                    PlayerInventory.Instance.DecrementBatteries(1);
                    AudioManager.instance.PlaySoundEffect(insertBatteryFXId);
                    batteries = PlayerInventory.Instance.Batteries;
                }

                if (showNotification)
                {
                    batteryNotificationText.gameObject.SetActive(showNotification);
                    notificationTimer -= Time.deltaTime;
                    if (notificationTimer <= 0)
                    {
                        showNotification = false;
                        batteryNotificationText.gameObject.SetActive(showNotification);
                    }
                }
            }
        }
    }
}