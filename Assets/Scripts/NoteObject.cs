using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    public bool canBePressed;
    public KeyCode key;
    public int noteScore = 100;

    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            if (canBePressed)
            {
                //gameObject.SetActive(false);
                //if (Mathf.Abs(transform.position.y) > 0.4)
                //{
                //    Debug.Log("bad");
                //    GameManager.instance.BadHit();
                //}
                //if (Mathf.Abs(transform.position.y) > 0.2)
                //{
                //    Debug.Log("good");
                //    GameManager.instance.GoodHit();
                //}
                //else if (Mathf.Abs(transform.position.y) > 0.1)
                //{
                //    Debug.Log("perfect");
                //    GameManager.instance.PerfectHit();
                //}
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;
            GameManager.instance.ResetStreak();
        }
    }
}
