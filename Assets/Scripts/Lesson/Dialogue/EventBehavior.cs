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
        GameObject board = FindObjectOfType<LessonManager>().board;
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
        GameObject board = FindObjectOfType<LessonManager>().board;
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

    
    public void PlayAnimation()
    {
        int i = LessonManager.instance.index;
        Debug.Log(i.ToString());
        Animator anim = LessonManager.instance.strokeAnimations[i];
        GameObject animObj = LessonManager.instance.letterAnimation.transform.GetChild(i).gameObject;
        animObj.SetActive(true);
        int animID = i + 1;
        anim.Play(LessonManager.instance.letterName+animID);
        LessonManager.instance.index += 1;
    }

    public void ClearAnimation()
    {
        GameObject letterAnimation = LessonManager.instance.letterAnimation;
        letterAnimation.SetActive(false);
    }

    public void StartWriting()
    {
        FindObjectOfType<WritingHandler>().canWrite = true;
        LessonManager.instance.cursor.SetActive(true);
    }

    public void DisableWriting()
    {
        if (LessonManager.instance.board.activeInHierarchy)
        {
            WritingHandler writingHandler = FindObjectOfType<WritingHandler>();
            writingHandler.canWrite = false;
            LessonManager.instance.cursor.SetActive(false);
        }
    }

    public void GiveReward()
    {
        PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + 50);
        PlayerPrefs.SetInt("expPoints", PlayerPrefs.GetInt("expPoints") + 500);
        LessonManager.instance.coins.text = "" + 50;
        LessonManager.instance.expPoints.text = "" + 500;
        LessonManager.instance.reward.SetActive(true);
    }
}
