using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogButton : MonoBehaviour
{
    public void GetNextLine()
    {
        DialogManager.instance.DequeueDialogue();
    }
}
