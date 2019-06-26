using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Dialog", menuName = "Dialogues")]

public class DialogBase : ScriptableObject
{
    [System.Serializable]
    public class Info
    {
        public string characterName;
        public Sprite avatar;
        [TextArea(4, 8)]
        public string lines;
        public UnityEvent dialogEvent;

    }
    [Header("Insert New Dialog Below")]
    public Info[] dialogueInfo;
}
