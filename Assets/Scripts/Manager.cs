using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    NoteObject noteObject;

    public NoteScroller noteScroller;
    public AudioSource gameMusic;
    public static Manager instance;
    public GameObject result;

    public Text scorePercentageText, perfectScoreText, goodScoreText, missedText, rankText, scoreFinalText;
    public Text scoreText;
    public Text multiplierText;

    public bool startPlaying;

    public int currentScore;
    public int score = 100;
    public int perfectScore = 150;
    public int badScore = 0;
    
    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierTresholds;

    public float totalNotes;
    public float perfectHit;
    public float goodHit;
    public float badHit;
    public float missedHit;

    void Start()
    {
        scoreText.text = "000";
        multiplierText.text = "1x";
        currentMultiplier = 1;
        instance = this;
        totalNotes = FindObjectsOfType<NoteObject>().Length;
        //score = noteObject.noteScore;
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

    public void HitNote()
    {
        Debug.Log("hit");

        if (currentMultiplier - 1 < multiplierTresholds.Length)
        {
            multiplierTracker++;

            if (multiplierTresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }
        }

        scoreText.text = "" + currentScore;
        multiplierText.text = currentMultiplier + "x";
    }

    public void GoodHit()
    {
        currentScore += score * currentMultiplier;
        HitNote();
        goodHit++;
    }

    public void PerfectHit()
    {
        currentScore += perfectScore * currentMultiplier;
        HitNote();
        perfectHit++;
    }

    public void BadHit()
    {
        currentMultiplier = 1;
        MissNote();
        badHit++;
    }

    public void MissNote()
    {
        Debug.Log("miss");
        currentMultiplier = 1;
        multiplierText.text = currentMultiplier + "x";
        missedHit++;
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
