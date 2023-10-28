using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnablePlaySound : MonoBehaviour
{
    public int audioManagerClipID;  // the sound ID to play
    public float waitBeforePlaying = 0.1f;


    private void OnEnable()
    {
        StartCoroutine(Play());
    }

    IEnumerator Play()
    {
        yield return new WaitForSeconds(waitBeforePlaying);
        AudioManager.instance.PlaySoundEffect(audioManagerClipID);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
