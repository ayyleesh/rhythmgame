using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "New Dialogue Questions", menuName = "DialogQuestions")]
public class DialogQuestions : DialogBase
{
    [System.Serializable]
    public class Questions
    {
        public string buttonName;
        public UnityEvent questionEvent;
        public DialogBase nextDialogue;
    }
    [TextArea(2, 10)]
    public string questionText;
    public Questions[] questionsInfo;

}
