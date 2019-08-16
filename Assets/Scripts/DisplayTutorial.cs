using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTutorial : MonoBehaviour
{
    public GameObject tutorial;
    public Button closeTutorial;
    public GlobalPopUp globalPopUp;
    public string boolPref;

    private void Start()
    {
        if (globalPopUp == null)
        {
            globalPopUp = GlobalPopUp.instance;
        }

        globalPopUp.ShowTutorial(tutorial, boolPref);
        closeTutorial.onClick.AddListener(() => CloseTutorial());
    }

    public void CloseTutorial()
    {
        tutorial.SetActive(false);
    }
}
