﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testEvent : MonoBehaviour
{
    public static testEvent instance;
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
