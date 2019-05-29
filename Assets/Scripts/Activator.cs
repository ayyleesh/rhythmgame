using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public KeyCode key;
    bool active = false;
    GameObject note;
    Color old;
    public bool createMode;
    public GameObject newNote;
    public GameObject scroller;
    public GameObject hitIndicators;
    public GameObject perfectIndicator, goodIndicator, badIndicator, missedIndicator;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        old = spriteRenderer.color;
    }

    // Update is called once per frame
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
        else {
            if (Input.GetKeyDown(key))
            {
                StartCoroutine(Pressed());
            }
            if (Input.GetKeyDown(key) && active)
            {
                note.SetActive(false);
                if (Mathf.Abs(note.transform.position.y) > 0.4)
                {
                    Debug.Log("bad");
                    var bad = Instantiate(badIndicator, hitIndicators.transform);
                    Destroy(bad, 1);
                    GameManager.instance.BadHit();
                }
                if (Mathf.Abs(note.transform.position.y) > 0.2)
                {
                    Debug.Log("good");
                    var good = Instantiate(goodIndicator, hitIndicators.transform);
                    Destroy(good, 1);
                    GameManager.instance.GoodHit();
                }
                else if (Mathf.Abs(note.transform.position.y) > 0.1)
                {
                    Debug.Log("perfect");
                    var perfect = Instantiate(perfectIndicator, hitIndicators.transform);
                    Destroy(perfect, 1);
                    GameManager.instance.PerfectHit();
                }
                active = false;
            }
            else if (Input.GetKeyDown(key) && !active)
            {
                GameManager.instance.ResetStreak();
                Debug.Log("missed");
                var missed = Instantiate(missedIndicator, hitIndicators.transform);
                Destroy(missed, 1);
                GameManager.instance.MissedHit();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Note")
        {
            active = true;
            note = other.gameObject;
        }

        else if (other.gameObject.tag == "FinishNote")
        {
            GameManager.instance.DisplayResult();
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Note")
        {
            Debug.Log("missed");
            active = false;
            GameManager.instance.MissedHit();
        }
        
    }

    IEnumerator Pressed()
    {
        
        spriteRenderer.color = new Color(0, 0, 0);
        yield return new WaitForSeconds(0.05f);
        spriteRenderer.color = old;
    }
}
