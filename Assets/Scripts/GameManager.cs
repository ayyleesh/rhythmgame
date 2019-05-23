﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public NoteScroller noteScroller;
    public AudioSource gameMusic;
    public GameObject result;

    public Text scoreText;
    public Text multiplierText;
    public Text comboText;
    public Text scorePercentageText, perfectScoreText, goodScoreText, missedText, rankText, scoreFinalText;

    public bool startPlaying;

    public int score;
    public int currentScore;
    int multiplier = 1;
    int combo = 0;

    public float totalNotes;
    public float perfectHit;
    public float goodHit;
    public float badHit;
    public float missedHit;
    
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
        comboText.text = "Combo: " + combo;
        scoreText.text = "" + currentScore;
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
        AddCombo();
        UpdateGUI();
    }

    

    public void DisplayResult()
    {
        result.SetActive(true);
        gameMusic.Stop();
        goodScoreText.text = "" + goodHit;
        perfectScoreText.text = "" + perfectHit;
        missedText.text = "" + missedHit;

        scoreFinalText.text = "" + currentScore;
        float total = goodHit + perfectHit;
        float percentHit = (total / totalNotes) * 100f;

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
