using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SpaceStationScript : MonoBehaviour
{
    public Sprite TurnedOn;
    public int OnOrOff = 0; // on is 1 off is 0
    int playerIsInMeXD = 0;
    public int arrAdded = 0;
    public Dialogue convo;
    public DialogueManager dialogueManager;

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

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)){
             if(playerIsInMeXD == 1 && OnOrOff == 0){
                OnOrOff = 1;
                TurnOn();
                if (convo != null && dialogueManager != null)
                {
                    dialogueManager.StartDialogue(convo);
                }
             }
        }
        
        
    }

    void TurnOn(){
        this.GetComponent<SpriteRenderer>().sprite = TurnedOn;
    }
    
}
