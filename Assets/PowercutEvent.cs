using PlayerController;
using UnityEngine;

public class PowercutEvent : MonoBehaviour
{
    [SerializeField] private AudioClip dangerMusic;
    [SerializeField]private GameObject[] objectsToDisable;

    private Transform player;

    private void Awake()
    {
        player = FindAnyObjectByType<PlayerMovement>().transform;
    }

    private void Update()
    {
        if (!(Vector3.Distance(transform.position, player.position) < 12)) return;
        FindAnyObjectByType<AudioManager>().PlayBackgroundMusic(dangerMusic);
        GetComponent<AudioSource>().Play();

        foreach (var o in objectsToDisable)
        {
            o.SetActive(false);
        }

        enabled = false;
    }
}