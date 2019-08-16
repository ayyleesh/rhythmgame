using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowLetter : MonoBehaviour
{
    public List<NoteObject> notes = new List<NoteObject>();
    public Text nextLetter;
    public Text next2Letter;
    

    // Start is called before the first frame update
    void Start()
    {
        GameObject notesParent = GameObject.Find("Notes");
        for (int i = 0; i < notesParent.transform.childCount-2; i++)
        {
            notes.Add(notesParent.transform.GetChild(i).gameObject.GetComponent<NoteObject>());
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        nextLetter.text = notes[0].letter;
        next2Letter.text = notes[1].letter;
        if (!notes[0].gameObject.activeInHierarchy)
        {
            notes.Remove(notes[0]);
        }
    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.tag == "Note")
    //    {
    //        var note = other.gameObject;
    //        nextLetter.text = note.GetComponent<NoteObject>().letter;
    //    }
    //}

    //void OnTriggerExit2D(Collider2D other)
    //{
    //    if (other.gameObject.tag == "Note")
    //    {
    //        nextLetter.text = "";
    //    }
    //}
}
