using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Dialogue Tail")]
[System.Serializable]
public class DialogueTail : ScriptableObject
{
    public string nextScene;
    public Sprite background;
}
