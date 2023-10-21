using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceLight : MonoBehaviour
{


    public Transform playerBody;
    public Transform machineBody;
    public Light targetLight;  // Reference to the Light component you want to modify
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var distance = Vector3.Distance (machineBody.position, playerBody.position);

        if(distance < 180 && distance > 20){
            targetLight.intensity = distance/36;
            targetLight.range = distance / 10;
        } else if (distance < 20){
            targetLight.intensity = 0.1f;
            targetLight.range = 5f;
        }

    }
}
