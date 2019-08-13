using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalPopUp : MonoBehaviour
{
    public StatusBarScript statusBarScript;
    public int currentLevel, newLevel;
    public GameObject tutorialPopUp, RewardPrefab, instRewardPopUp;

    private void Start()
    {
        currentLevel = PlayerPrefs.GetInt("currentLevel");
        if (tutorialPopUp != null && PlayerPrefs.GetInt("tutorialIsShown") != 1)
        {
            ShowTutorial();
        }

        DontDestroyOnLoad(this.gameObject);
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
