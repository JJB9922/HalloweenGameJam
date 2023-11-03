using System;
using PlayerController;
using UnityEngine;
using UnityEngine.SceneManagement;

// "Collectible"
public class CaveDoor : MonoBehaviour
{
    [SerializeField] private GameObject helmetUI;
    [SerializeField] private AudioClip caveMusic;

    private Transform player;

    private void Awake()
    {
        player = FindAnyObjectByType<PlayerMovement>().transform;
    }

    private void Update()
    {
        if (!helmetUI.activeInHierarchy) return;

        if (
            Input.GetKeyDown(KeyCode.E) &&
            Vector3.Distance(transform.position, player.position) < 6)
        {
            Enter();
        }
    }

    private void Enter()
    {
        SceneManager.LoadScene("CaveScene");
        FindAnyObjectByType<AudioManager>().PlayBackgroundMusic(caveMusic);
    }
}