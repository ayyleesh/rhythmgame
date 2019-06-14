using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public NoteScroller noteScroller;
    public AudioSource gameMusic;
    public GameObject result;
    public Slider slider;
    public GameObject comboObject;

    public Text scoreText;
    public Text multiplierText;
    public Text comboText;
    public Text scorePercentageText, comboScoreText, perfectScoreText, goodScoreText, badScoreText, missedText, rankText, scoreFinalText;

    public bool startPlaying;

    public int score;
    public int currentScore;
    int multiplier = 1;
    int combo = 0;
    string formatScore;

    public float totalNotes;
    public float hit;
    public float perfectHit;
    public float goodHit;
    public float badHit;
    public float missedHit;
    float percentHit;

    void Start()
    {
        instance = this;
        totalNotes = FindObjectsOfType<NoteObject>().Length;

        scoreText.text = "000";
        multiplierText.text = "1x";
        comboText.text = "Combo: 0";
    }
    
    void Update()
    {
        if (!startPlaying)
        {
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                noteScroller.hasStarted = true;
                gameMusic.Play();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.SetActive(false);
        ResetStreak();
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

        if (combo >= 6)
        {
            comboObject.SetActive(true);
        }
        else
        {
            comboObject.SetActive(false);
        }
        comboText.text = "" + combo;
        scoreText.text = formatScore;
        percentHit = (goodHit + perfectHit) / totalNotes * 100f;
        slider.value = percentHit;
    }

    public void GoodHit()
    {
        score = NoteObject.FindObjectOfType<NoteObject>().noteScore;
        HitNote();
        goodHit++;
    }

    public void PerfectHit()
    {
        score = NoteObject.FindObjectOfType<NoteObject>().noteScore + 50;
        HitNote();
        perfectHit++;
    }

    public void BadHit()
    {
        ResetStreak();
        badHit++;
    }

    public void MissedHit()
    {
        ResetStreak();
        missedHit++;
    }

    public void HitNote()
    {
        currentScore += score * multiplier;
        formatScore = currentScore.ToString("N0", CultureInfo.CreateSpecificCulture("en-US"));
        AddCombo();
        UpdateGUI();
        hit++;
    }

    

    public void DisplayResult()
    {
        result.SetActive(true);
        gameMusic.Stop();
        
        goodScoreText.text = "" + goodHit;
        perfectScoreText.text = "" + perfectHit;
        badScoreText.text = "" + badHit;
        missedText.text = "" + missedHit;

        scoreFinalText.text = "" + formatScore;
        float total = goodHit + perfectHit;

        scorePercentageText.text = percentHit.ToString("F1") + "%";

        string rankVal = "D";

        if (percentHit > 50)
        {
            rankVal = "C";
            if (percentHit > 75)
            {
                rankVal = "B";
                if (percentHit > 90)
                {
                    rankVal = "A";
                    if (percentHit > 95)
                    {
                        rankVal = "S";
                    }
                }
            }
        }
        rankText.text = rankVal;
    }

}
