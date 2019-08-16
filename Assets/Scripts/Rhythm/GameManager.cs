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
    public GameObject result, reward;
    public Slider slider;
    public GameObject comboObject;
    public GameObject tapToStart;

    public Text scoreText;
    public Text multiplierText;
    public Text comboText;
    [Header("Result Scoring")]
    public Text scorePercentageText, comboScoreText, perfectScoreText, goodScoreText, badScoreText, missedText, rankText, scoreFinalText;

    [Header("Rewards")]
    public Text coinAmt, expPointAmt;

    public bool startPlaying;

    public int score;
    public int currentScore;
    int multiplier = 1;
    int combo = 0;
    int maxCombo = 0;
    string formatScore;

    public float totalNotes;
    public float hit;
    public float perfectHit;
    public float goodHit;
    public float badHit;
    public float missedHit;
    public int totalCoins, totalExpPoints;
    float percentHit;

    public float coinMultiplier = 1;
    public float expMultiplier = 1;
    public DisplayTutorial displayTutorial;
    PurchasableItems purchasableItems;
    public EquippableItem[] equippedItems;

    void Start()
    {
        instance = this;
        totalNotes = FindObjectsOfType<NoteObject>().Length-1;
        purchasableItems = FindObjectOfType<PurchasableItems>();
        displayTutorial = FindObjectOfType<DisplayTutorial>();
        equippedItems = new EquippableItem[2];
        AddEquippedItems();

        scoreText.text = "000";
        multiplierText.text = "1x";
        comboText.text = "Combo: 0";
        totalCoins = PlayerPrefs.GetInt("coins");
        totalExpPoints = PlayerPrefs.GetInt("expPoints");

        
    }
    
    void Update()
    {
        if (!startPlaying && !displayTutorial.tutorial.activeInHierarchy)
        {
            tapToStart.SetActive(true);
            if (Input.anyKey)
            {
                tapToStart.SetActive(false);
                startPlaying = true;
                noteScroller.hasStarted = true;
                gameMusic.Play();
            }
        }
    }

    void AddEquippedItems()
    {
        if (PlayerPrefs.GetInt("itemEquipped1") != 0)
        {
            equippedItems[0] = purchasableItems.items[PlayerPrefs.GetInt("itemEquipped1")] as EquippableItem;
        }

        if (PlayerPrefs.GetInt("itemEquipped2") != 0)
        {
            equippedItems[1] = purchasableItems.items[PlayerPrefs.GetInt("itemEquipped2")] as EquippableItem;
        }

        for (int i = 0; i < equippedItems.Length; i++)
        {
            if (equippedItems[i] != null)
            {
                coinMultiplier = coinMultiplier * equippedItems[i].coinMultiplier;
                expMultiplier = expMultiplier * equippedItems[i].expMultiplier;
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
        if (combo > maxCombo)
        {
            maxCombo = combo;
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
        comboScoreText.text = "" + maxCombo;
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

    public void DisplayReward()
    {
        reward.SetActive(true);
        int coin = (int)Mathf.Floor(currentScore * 0.1f * coinMultiplier);
        int exp = (int)(currentScore * expMultiplier);
        coinAmt.text = "" + coin;
        expPointAmt.text = "" + exp;
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins")+coin);
        PlayerPrefs.SetInt("expPoints", PlayerPrefs.GetInt("expPoints")+exp);
    }

}
