using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public GameObject levelContainer;
    public GameObject levelButton;
    public string levelID;
    public GameObject[] instContainer;
    public GameObject[] instButton;
    public LevelGroups[] levelGroups;
    

    public int levelTotal;
    public int containerCount;
    public int buttonCount;

    SnapScroll snapScroll;
    ButtonsScript buttonsScript;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LateStart(0.01f));
    }

    IEnumerator LateStart(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameObject content = GameObject.Find("Content");
        snapScroll = content.GetComponent<SnapScroll>();
        buttonsScript = FindObjectOfType<ButtonsScript>();
        containerCount = levelGroups.Length;
        instContainer = new GameObject[containerCount];
        instButton = new GameObject[levelTotal];
        

        for (int k = 0; k < containerCount; k++)
        {
            instContainer[k] = Instantiate(levelContainer, transform, false);
            instContainer[k].SetActive(false);
            for (int i = 0; i < levelGroups[k].levelNames.Length; i++)
            {
                instButton[i] = Instantiate(levelButton, instContainer[k].transform, false);
                int counter = i;
                instButton[i].GetComponent<ButtonCount>().buttonCount = counter;
                instButton[i].transform.GetChild(0).GetComponent<Text>().text = levelGroups[k].levelNames[i];
                instButton[i].transform.GetChild(1).GetComponent<Text>().text = levelGroups[k].romajiNames[i];
                instButton[counter].GetComponent<Button>().onClick.AddListener(() => buttonsScript.LoadPopUpInfo(snapScroll.selectedPanelID, counter));
            }
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        instContainer[snapScroll.selectedPanelID].SetActive(true);

        for (int i = 0; i < levelGroups.Length; i++)
        {
            if (i != snapScroll.selectedPanelID)
            {
                instContainer[i].SetActive(false);
            }
        }

    }

    void LoadLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}
