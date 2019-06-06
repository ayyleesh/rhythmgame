using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public GameObject levelContainer;
    public GameObject levelButton;

    public GameObject[] instContainer;
    public GameObject[] instButton;

    public int[] levelNumbers;

    public int levelTotal;
    public int containerCount;
    public int buttonCount;
    int levelCount;

    SnapScroll snapScroll;
    // Start is called before the first frame update
    void Start()
    {
        levelCount = levelNumbers.Length;
        StartCoroutine(LateStart(0.01f));
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
            for (int i = 0; i < levelNumbers[k]; i++)
            {
                instButton[i] = Instantiate(levelButton, instContainer[k].transform, false);
                int counter = i;
                instButton[i].GetComponent<ButtonCount>().buttonCount = counter;
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
