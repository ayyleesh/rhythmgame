using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LessonManager : MonoBehaviour
{
    public static LessonManager instance;
    public string letterName;
    public GameObject board;
    public GameObject letterAnimation;
    public Animator[] strokeAnimations;
    public GameObject cursor;
    public int index;

    private void Awake()
    {
        instance = this;
        index = 0;
    }
}
