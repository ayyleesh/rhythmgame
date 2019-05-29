using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsScript : MonoBehaviour
{
    public GameObject popUp;
    public bool isActive;

    public void ShowPopUp()
    {
        isActive = true;
        popUp.SetActive(true);
    }

    public void ClosePopUp()
    {
        if (isActive)
        {
            popUp.SetActive(false);
        }
    }
}
