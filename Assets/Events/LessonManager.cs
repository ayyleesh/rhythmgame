using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LessonManager : MonoBehaviour
{
    public static LessonManager instance;
    public string letterName;
    public GameObject board;
    public GameObject letterAnimation;
    public Animator[] strokeAnimations;
    public GameObject cursor;
    public GameObject result, reward;
    public Text coins, expPoints;
    public int nextLevel, nextStage;
    public int index;
    public int wrong, correct;

    private void Awake()
    {
        instance = this;
        index = 0;
    }

}
