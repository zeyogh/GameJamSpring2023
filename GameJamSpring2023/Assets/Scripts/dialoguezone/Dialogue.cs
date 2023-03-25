using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Dialogue")]
[System.Serializable]
public class Dialogue : ScriptableObject
{
    public Dialogue(CharacterSO character, string[] sentences, Dialogue nextDialogue)
    {
        this.character = character;
        this.sentences = sentences;
        this.nextDialogue = nextDialogue;
    }

     
    public CharacterSO character;
    [TextArea(3, 10)]
    public string[] sentences;
    public Dialogue nextDialogue;
    public DialogueTail dialogueTail;
    public Sprite background;



}
