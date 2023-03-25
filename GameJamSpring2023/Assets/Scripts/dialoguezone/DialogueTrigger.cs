using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public CharacterSO character;
    public DialogueManager manager;


    public void TriggerDialogue()
    {
        manager = FindObjectOfType<DialogueManager>();
        manager.StartDialogue(dialogue);
    }


    private void Start()
    {

    }
}
