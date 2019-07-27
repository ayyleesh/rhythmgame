using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPopUp : MonoBehaviour
{

    public GameObject bgOverlay;
    public GameObject deleteDataPopUp;
    public GameObject confirmPopUp;

    public void ShowPopUp()
    {
        bgOverlay.SetActive(true);
        deleteDataPopUp.SetActive(true);
    }

    public void ConfirmDeletion()
    {
        PlayerPrefs.DeleteAll();
        //Debug.Log("deleted");
        deleteDataPopUp.SetActive(false);
        confirmPopUp.SetActive(true);
    }

    public void ClosePopUp()
    {
        bgOverlay.SetActive(false);
        confirmPopUp.SetActive(false);
        deleteDataPopUp.SetActive(false);
    }
}
