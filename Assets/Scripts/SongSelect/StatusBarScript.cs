using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusBarScript : MonoBehaviour
{
    public int expPointsTotal, currentLevel;
    public float levelPercent;
    int[] levelMaxExp = new int[] { 10000, 20000, 30000, 50000, 80000, 130000};
    public Text coinsTotalText, levelText;
    public Slider expSlider;
    public GameObject toolTip;

    void Start()
    {
        expPointsTotal = PlayerPrefs.GetInt("expPoints");
        expSlider = FindObjectOfType<Slider>();

        for (int i = 0; i < levelMaxExp.Length; i++)
        {
            if (expPointsTotal > levelMaxExp[i])
            {
                currentLevel++;
            }
        }
        toolTip.GetComponentInChildren<Text>().text = expPointsTotal + "/" + levelMaxExp[currentLevel];

    }

    // Update is called once per frame
    void Update()
    {
        levelText.text = "Lv. " + currentLevel;
        levelPercent = expPointsTotal * 100 / levelMaxExp[currentLevel];
        expSlider.value = levelPercent;
        coinsTotalText.text = "" + PlayerPrefs.GetInt("coins");
    }

    public void OnClick()
    {
        StartCoroutine(ShowToolTip());
    }

    IEnumerator ShowToolTip()
    {
        toolTip.SetActive(true);
        yield return new WaitForSeconds(3);
        toolTip.SetActive(false);
    }
}
