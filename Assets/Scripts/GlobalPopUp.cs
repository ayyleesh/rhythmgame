using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalPopUp : MonoBehaviour
{
    public static GlobalPopUp instance;
    public StatusBarScript statusBarScript;
    public int currentLevel, newLevel;
    public GameObject tutorialPopUp, RewardPrefab, instRewardPopUp;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        currentLevel = PlayerPrefs.GetInt("currentLevel");
        if (tutorialPopUp != null && PlayerPrefs.GetInt("tutorialIsShown") != 1)
        {
            ShowTutorial();
        }
        
    }

    private void Update()
    {
        if ( currentLevel != 0 && PlayerPrefs.GetInt("currentLevel") > currentLevel)
        {
            currentLevel = newLevel;
            StartCoroutine(ShowLevelUp());
        }
    }

    void ShowTutorial()
    {
        tutorialPopUp.SetActive(true);
        PlayerPrefs.SetInt("tutorialIsShown", 1);
    }

    public void CloseTutorial()
    {
        if (tutorialPopUp.activeInHierarchy)
        {
            tutorialPopUp.SetActive(false);
        }
    }

    IEnumerator ShowLevelUp()
    {
        yield return new WaitForSeconds(0.5f);
        instRewardPopUp = Instantiate(RewardPrefab, GameObject.Find("Canvas").transform);
        GameObject.Find("Panel Top").transform.GetChild(1).GetComponent<Text>().text = "You've reached level " + PlayerPrefs.GetInt("currentLevel");
        Button closeButton = GameObject.Find("Panel Bottom").transform.GetChild(0).GetComponent<Button>();
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + 1);
        closeButton.onClick.AddListener(() => CloseLevelUp());
    }

    public void CloseLevelUp()
    {
        Destroy(instRewardPopUp);
    }

}
