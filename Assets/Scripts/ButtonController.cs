using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    
    public KeyCode key;
    public float delay;
    public bool createMode;
    public GameObject newNote;
    public GameObject scroller;

    SpriteRenderer sr;
    Color old;

    //bool active = false;
    //GameObject note, gm;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        //gm = GameObject.Find("GameManager");
        old = sr.color;
    }
    
    void Update()
    {
        if (createMode)
        {
            if (Input.GetKeyDown(key))
            {
                GameObject note = Instantiate(newNote, transform.position, Quaternion.identity);
                note.transform.parent = scroller.transform;
            }
        }
        else
        {
            if (Input.GetKeyDown(key))
            {
                StartCoroutine(Pressed());
            }
            //    if (Input.GetKeyDown(key) && active)
            //    {
            //        Destroy(note);
            //        gm.GetComponent<GameManager>().AddStreak();
            //        AddScore();
            //        active = false;
            //    }
            //    else if (Input.GetKeyDown(key) && !active)
            //    {
            //        gm.GetComponent<GameManager>().ResetStreak();
            //    }
        }
    }

    //void OnTriggerEnter2D(Collider2D col)
    //{
    //    active = true;
    //    if (col.gameObject.tag == "Note")
    //    {
    //        note = col.gameObject;
    //    }
    //}

    //void AddScore()
    //{
    //    PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score")+gm.GetComponent<GameManager>().GetScore());
    //}

    //void OnTriggerExit2D(Collider2D col)
    //{
    //    active = false;
    //}

    IEnumerator Pressed()
    {
        
        sr.color = new Color(0, 0, 0);
        yield return new WaitForSeconds(delay);
        sr.color = old;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "FinishNote")
        {
            Manager.instance.DisplayResult();
        }
    }
}
