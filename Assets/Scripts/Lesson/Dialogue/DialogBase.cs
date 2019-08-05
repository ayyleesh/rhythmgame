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
        public CharacterItem character;
        public Expressions characterExpression;
        //public string characterName;
        //public Sprite avatar;
        [TextArea(4, 8)]
        public string lines;
        public UnityEvent dialogEvent;

        public void ChangeExpression()
        {
            character.Expression = characterExpression;
        }

    }
    [Header("Insert New Dialog Below")]
    public Info[] dialogueInfo;
}
