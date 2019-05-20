using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public KeyCode key;
    bool active = false;
    GameObject note, specialNote, gameManager;
    Color old;
    public bool createMode;
    public GameObject newNote;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        old = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (createMode)
        {
            if (Input.GetKeyDown(key))
            {
                Instantiate(newNote, transform.position, Quaternion.identity);
            }
        }
        else {
            if (Input.GetKeyDown(key))
            {
                StartCoroutine(Pressed());
            }
            if (Input.GetKeyDown(key) && active)
            {
                Destroy(note);
                gameManager.GetComponent<GameManager>().AddCombo();
                AddScore();
                active = false;
            }
            else if (Input.GetKeyDown(key) && !active)
            {
                gameManager.GetComponent<GameManager>().ResetStreak();
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
        
    }

    void AddScore()
    {

        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + gameManager.GetComponent<GameManager>().GetScore());
    }

    void OnTriggerExit2D(Collider2D col)
    {
        active = false;
    }

    IEnumerator Pressed()
    {
        
        spriteRenderer.color = new Color(0, 0, 0);
        yield return new WaitForSeconds(0.5f);
        spriteRenderer.color = old;
    }
}
