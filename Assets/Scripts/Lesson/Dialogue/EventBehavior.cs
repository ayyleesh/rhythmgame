using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "Events")]
public class EventBehavior : ScriptableObject
{
    public bool isDestroyed;
    public void Test()
    {
        Debug.Log("test"); 
    }

    public void ShowBoard()
    {
        GameObject board = FindObjectOfType<testEvent>().board;
        if (board.activeInHierarchy)
        {
            Debug.Log("Board already active");
        }
        else
        {
            board.SetActive(true);
        }

    }

    public void HideBoard()
    {
        GameObject board = FindObjectOfType<testEvent>().board;
        if (board.activeInHierarchy)
        {
            board.SetActive(false);
        }
        else
        {
            Debug.Log("Board isn't active");
        }
        ClearWriting();
    }
    
    public void CloseQuestion()
    {
        DialogManager.instance.CloseQuestions();
    }

    public void ClearWriting()
    {
        GameObject[] line = GameObject.FindGameObjectsWithTag("LineRenderer");
        int lineCount = line.Length;
        for (int i = 0; i < lineCount; i++)
        {
            Destroy(line[i]);
        }
        isDestroyed = true;
        
    }

    public void NextLetter()
    {
        WritingHandler writingHandler = GameObject.FindObjectOfType<WritingHandler>();
        writingHandler.LoadNextLetter();

    }
}
