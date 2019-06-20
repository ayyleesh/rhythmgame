using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadDialogue : MonoBehaviour
{
    public DialogBase dialogue;
    public float loadDelay;
    
    void Start()
    {
        StartCoroutine(LoadDialogue());
    }

    IEnumerator LoadDialogue()
    {
        yield return new WaitForSeconds(loadDelay);
        TriggerDialogue();
    }

    public void TriggerDialogue()
    {
        DialogManager.instance.EnqueueDialogue(dialogue);
    }
}
