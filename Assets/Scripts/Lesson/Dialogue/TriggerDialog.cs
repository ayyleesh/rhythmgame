using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDialog : MonoBehaviour
{
    private bool isTriggered = false;
    public GameObject dialogueBox;
    public DialogBase dialogue;

    void Update()
    {
        if (dialogueBox.activeInHierarchy)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isTriggered)
        {
            TriggerDialogue();
            isTriggered = true;
        }
        
    }

    public void TriggerDialogue()
    {
        DialogManager.instance.EnqueueDialogue(dialogue);
    }
}
