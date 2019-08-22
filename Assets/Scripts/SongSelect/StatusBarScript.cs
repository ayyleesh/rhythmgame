using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBarScript : MonoBehaviour
{
    public static StatusBarScript instance;

    public int expPointsTotal, currentLevel;
    public float levelPercent;
    int[] levelMaxExp = new int[] { 1000, 2000, 3000, 5000, 8000, 13000, 21000, 34000, 55000, 89000};
    public Text coinsTotalText, levelText, expText;
    public Slider expSlider;

    void Start()
    {
        instance = this;
        expPointsTotal = PlayerPrefs.GetInt("expPoints");
        expSlider = FindObjectOfType<Slider>();

        for (int i = 0; i < levelMaxExp.Length; i++)
        {
            if (expPointsTotal > levelMaxExp[i])
            {
                currentLevel++;
            }
        }
        PlayerPrefs.SetInt("currentLevel", currentLevel);

    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = "Lv. " + PlayerPrefs.GetInt("currentLevel");
        expText.text = expPointsTotal + "/" + levelMaxExp[currentLevel];
        levelPercent = expPointsTotal * 100 / levelMaxExp[currentLevel];
        expSlider.value = levelPercent;
        coinsTotalText.text = "" + PlayerPrefs.GetInt("coins");
    }

    void LevelCount()
    {

    }
}
