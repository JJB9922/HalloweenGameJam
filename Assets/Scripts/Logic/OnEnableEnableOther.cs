using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnableEnableOther : MonoBehaviour
{
    public GameObject otherToEnable;  // 
    public float waitBeforeEnable = 0.1f;


    private void OnEnable()
    {
        StartCoroutine(Play());
    }

    IEnumerator Play()
    {
        yield return new WaitForSeconds(waitBeforeEnable);
        otherToEnable.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
