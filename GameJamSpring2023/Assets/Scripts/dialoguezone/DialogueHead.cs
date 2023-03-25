using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Dialogue Head")]
[System.Serializable]
public class DialogueHead : ScriptableObject    
{
    public string conversationID;
    public Dialogue firstDialogue;
    public Sprite background;



}
