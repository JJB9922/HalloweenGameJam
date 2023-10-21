using UnityEngine;
using UnityEngine.UI;
using PlayerController;

public class SprintBarUI : MonoBehaviour
{
    public Slider sprintSlider;
    //Sorry
    public Image fillArea;

    private PlayerMovement playerController; // Reference to your player controller script

    private void Start()
    {

        fillArea.color = new Color(0.4858491f, 1f, 0.5726692f, 0f);

        playerController = FindObjectOfType<PlayerMovement>();
        
        if (sprintSlider == null)
        {
            Debug.LogError("SprintSlider not assigned in the inspector.");
        }        

    }

    private void Update()
    {
        float sprintStatus = playerController.currentSprintTime / playerController.sprintDuration;

        if (sprintStatus < 1){
            fillArea.color = new Color(0.4858491f, 1f, 0.5726692f, 1f);
        } else {
            fillArea.color = new Color(0.4858491f, 1f, 0.5726692f, 0f);
        }

        sprintSlider.value = sprintStatus;

    }
}
