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
                gameObject.SetActive(false);
                //Manager.instance.HitNote();
                if (Mathf.Abs(transform.position.y) > 0.4)
                {
                    Debug.Log("bad");
                    Manager.instance.MissNote();
                }
                if (Mathf.Abs(transform.position.y) > 0.2)
                {
                    Debug.Log("good");
                    Manager.instance.GoodHit();
                }
                else if(Mathf.Abs(transform.position.y) > 0.1)
                {
                    Debug.Log("perfect");
                    Manager.instance.PerfectHit();
                }
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
            Manager.instance.MissNote();
        }
    }
}
