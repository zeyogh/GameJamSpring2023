using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Intro : MonoBehaviour
{

    public Dialogue dialogue;

    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("boop");
        GameManager gameManger = FindObjectOfType<GameManager>();
        //gameManger.PauseGame();
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();
        dialogueManager.StartDialogue(dialogue);
    }
    

}
