using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class DialogueEventHandler : MonoBehaviour, IPointerDownHandler
{
    public UnityEvent eventHandler;
    public DialogBase nextDialogue;
    
    public void OnPointerDown(PointerEventData pointerEventData)
    {
        eventHandler.Invoke();
        DialogManager.instance.CloseQuestions();

        if (nextDialogue != null)
        {
            DialogManager.instance.EnqueueDialogue(nextDialogue);
        }
    }
    
}
