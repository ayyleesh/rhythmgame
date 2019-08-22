using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalPopUp : MonoBehaviour
{
    public static GlobalPopUp instance;
    public StatusBarScript statusBarScript;
    public int currentLevel, newLevel;
    public GameObject RewardPrefab, instRewardPopUp;

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
        if (string.IsNullOrEmpty(PlayerPrefs.GetString("character")))
        {
            PlayerPrefs.SetString("character", "Suzu");
            PlayerPrefs.SetInt("characterID", 0);
        }

        currentLevel = PlayerPrefs.GetInt("currentLevel", 0);
    }

    private void Update()
    {
        if ( currentLevel != 0 && PlayerPrefs.GetInt("currentLevel") > currentLevel)
        {
            currentLevel = newLevel;
            StartCoroutine(ShowLevelUp());
        }
    }

    public void ShowTutorial(GameObject popUp, string boolPrefs)
    {
        if (popUp != null && PlayerPrefs.GetInt(boolPrefs) != 1)
        {
            popUp.SetActive(true);
            PlayerPrefs.SetInt(boolPrefs, 1);
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
