using PlayerController;
using UnityEngine;

public class CaveEntrance : MonoBehaviour
{
   private void Awake()
   {
      var player = FindAnyObjectByType<PlayerMovement>().transform;
      player.position = transform.position;
      player.rotation = transform.rotation;
   }
}