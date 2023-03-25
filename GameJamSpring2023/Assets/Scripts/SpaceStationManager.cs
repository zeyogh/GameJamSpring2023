using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStationManager : MonoBehaviour
{
    [SerializeField]GameObject SS1;
    [SerializeField]GameObject SS2;
    int beamSpawned = 0;

    void Awake(){
       
        Debug.Log(SS1.GetComponent<SpaceStationScript>().OnOrOff);
        Debug.Log(SS2.GetComponent<SpaceStationScript>().OnOrOff);

    }

    void Update(){

        // Debug.Log(SS1.GetComponent<SpaceStationScript>().OnOrOff);
        // Debug.Log(SS2.GetComponent<SpaceStationScript>().OnOrOff);
        if(SS1.GetComponent<SpaceStationScript>().OnOrOff == 1 && SS2.GetComponent<SpaceStationScript>().OnOrOff == 1 && beamSpawned == 0){
            beamSpawned = 1;
            Debug.Log("Beam Should Spawn and be visible");
            
        }

        
    }

    


}
