using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBarScript : MonoBehaviour
{
    public static StatusBarScript instance;

    public int expPointsTotal, currentLevel;
    public float levelPercent;
    int[] levelMaxExp = new int[] { 10000, 20000, 30000, 50000, 80000};
    public Text coinsTotalText, levelText;
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
        levelPercent = expPointsTotal * 100 / levelMaxExp[currentLevel];
        expSlider.value = levelPercent;
        coinsTotalText.text = "" + PlayerPrefs.GetInt("coins");
    }

    void LevelCount()
    {

    }
}
