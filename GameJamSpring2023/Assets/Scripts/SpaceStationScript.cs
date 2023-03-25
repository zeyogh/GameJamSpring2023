using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStationScript : MonoBehaviour
{
    int OnOrOff = 0; // on is 1 off is 0

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnOrOff = 1;
            Debug.Log("Station Has been interacted with: " + OnOrOff);
            
        }
        Debug.Log("In SpaceStation");
    }
}
