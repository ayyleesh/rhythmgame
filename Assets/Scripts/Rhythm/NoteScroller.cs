using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteScroller : MonoBehaviour
{
    public float beatTempo;
    public float difficulty;
    public float scrollSpeed;
    public bool hasStarted;
    

    void Start()
    {
        scrollSpeed = beatTempo / 60f * difficulty;
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted)
        {
            transform.position -= new Vector3(0f, scrollSpeed * Time.deltaTime, 0f);
        }
    }
}
