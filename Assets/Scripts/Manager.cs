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

    public Text scoreText;
    public Text multiplierText;

    public bool startPlaying;

    public int currentScore;
    public int score = 100;
    public int perfectScore = 150;
    
    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierTresholds;

    public float totalNotes;
    public float perfectHit;
    public float goodHit;
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

    public void MissNote()
    {
        Debug.Log("miss");
        currentMultiplier = 1;
        multiplierText.text = currentMultiplier + "x";
        missedHit++;
    }
}
