using System;
using Assets.Scripts;
using PlayerController;
using UnityEngine;
using UnityEngine.SceneManagement;

// "Collectible"
public class CaveDoor : Interactable
{
    [SerializeField] private GameObject helmetUI;
    [SerializeField] private AudioClip caveMusic;

    private Transform player;

    public override void Initialise()
    {
        InteractText = "Open";

        base.Initialise();
    }

    private void Awake()
    {
        player = FindAnyObjectByType<PlayerMovement>().transform;
    }

    public override void Interact()
    {
        if (!helmetUI.activeInHierarchy)
        {
            GameManager.Instance.ShowInformationText($"There are strange markings on the door... Maybe I can find something to help me read them.");
            return;
        }

        if (PlayerInventory.Instance.TotalKeys == 0)
        {
            GameManager.Instance.ShowInformationText($"There looks like a slot in the door. Maybe I can find something that fits?");
            return;
        }

        if (PlayerInventory.Instance.TotalKeys < 3)
        {
            GameManager.Instance.ShowInformationText($"I need to find more relic parts ({PlayerInventory.Instance.TotalKeys}/3)");
            return;
        }

        Enter();
    }

    private void Enter()
    {
        SceneManager.LoadScene("CaveScene");
        FindAnyObjectByType<AudioManager>().PlayBackgroundMusic(caveMusic);
    }
}