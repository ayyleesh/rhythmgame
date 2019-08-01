using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public GameObject levelContainer;
    public GameObject levelButton;

    MenuObject[] menu;
    public LevelMenuObject[] levelGroups;

    public GameObject[] instContainer;
    public GameObject[] instButton;
    
    public int levelTotal;
    public int containerCount;
    public int buttonCount;
    int levelCount;

    SnapScroll snapScroll;
    // Start is called before the first frame update
    void Start()
    {
        levelCount = levelGroups.Length;
        StartCoroutine(LateStart(0.1f));

        GameObject content = GameObject.Find("Content");
        snapScroll = content.GetComponent<SnapScroll>();
        menu = snapScroll.menu;
        levelGroups = new LevelMenuObject[menu.Length];
        for (int i = 0; i < menu.Length; i++)
        {
            levelGroups[i] = menu[i] as LevelMenuObject;
        }
    }

    IEnumerator LateStart(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameObject content = GameObject.Find("Content");
        snapScroll = content.GetComponent<SnapScroll>();
        containerCount = snapScroll.panelCounter;
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
                instButton[i].transform.GetChild(1).GetComponent<Text>().text = levelGroups[k].levelNames[i];
                instButton[i].transform.GetChild(0).GetComponent<Text>().text = levelGroups[k].romajiNames[i];
                instButton[counter].GetComponent<Button>().onClick.AddListener(() => LoadLevel("scene" + snapScroll.selectedPanelID + counter));
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        instContainer[snapScroll.selectedPanelID].SetActive(true);

        for (int i = 0; i < levelCount; i++)
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
