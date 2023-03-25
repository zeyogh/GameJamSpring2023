using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStationScript : MonoBehaviour
{
    public int OnOrOff = 0; // on is 1 off is 0
    int playerIsInMeXD = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerIsInMeXD = 1;
            Debug.Log("In SpaceStation");
            
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if (other.tag == "Player")
        {
            playerIsInMeXD = 0;
            Debug.Log("NOT In SpaceStation");
            
        }
    }

    void FixedUpdate(){
        if(playerIsInMeXD == 1 && Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("Space Station is ACTIVE");
        }
    }
    
}
