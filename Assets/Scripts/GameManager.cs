using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    int multiplier = 1;
    int combo = 0;
    int score = 100;
    int perfectScore = 150;
    
    public Text multiplierText;
    public Text comboText;

    // Start is called before the first frame update
    void Start()
    {
        multiplierText.text = "1x";
        comboText.text = "combo: 0";
        PlayerPrefs.SetInt("Score", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {

    }

    public void AddCombo()
    {
        combo++;
        if (combo >= 24)
        {
            multiplier = 4;
        }
        else if (combo >= 16)
        {
            multiplier = 3;
        }
        else if (combo >= 3)
        {
            multiplier = 2;
        }
        else
        {
            multiplier = 1;
        }

        UpdateGUI();
    }

    public void ResetStreak()
    {
        combo = 0;
        multiplier = 1;
        UpdateGUI();
    }

    public void UpdateGUI()
    {
        multiplierText.text = multiplier + "x";
        comboText.text = "Combo: " + combo;
        
    }

    public int GetScore()
    {
        return score * multiplier;
    }

    public int GetPerfectScore()
    {
        return perfectScore * multiplier;
    }

}
