using UnityEngine;
using UnityEngine.UI;
using PlayerController;

public class FlashlightBatteryBarUI : MonoBehaviour
{
    public Slider flashlightBatterBarSlider;
    //Sorry
    public Image fillArea;

    private Flashlight playerController; // Reference to your player controller script

    private void Start()
    {

        fillArea.color = new Color(0.9691716f, 1f, 0.259434f, 0f);

        playerController = FindObjectOfType<Flashlight>();
        
        if (flashlightBatterBarSlider == null)
        {
            Debug.LogError("SprintSlider not assigned in the inspector.");
        }        

    }

    private void Update()
    {
        float batteryStatus = playerController.flashlightBatteryTimer / playerController.flashlightBatteryLife;

        if (playerController.flashlightOn){
            fillArea.color = new Color(0.9691716f, 1f, 0.259434f, 1f);
        } else {
            fillArea.color = new Color(0.9691716f, 1f, 0.259434f, 0f);
        }

        flashlightBatterBarSlider.value = batteryStatus;

    }
}
