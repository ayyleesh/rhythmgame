using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogManager : MonoBehaviour
{
    public static DialogManager instance;

    public GameObject dialogueBox;
    public GameObject dialogueQuestion;
    public Text dialogueName;
    public Text dialogueText;
    public Image dialogueAvatar;
    public float delay;
    public bool inDialogue;

    public bool isDialogueOption;
    private bool isTyping;
    private string completeText;
    private int optionCount;

    public Text questionText;
    public GameObject[] optionButtons;

    public Queue<DialogBase.Info> dialogueInfo = new Queue<DialogBase.Info>();
    DialogueEventHandler handler;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("fix this" + gameObject.name);
        }
        else
        {
            instance = this;
        }
    }

    public void EnqueueDialogue(DialogBase dialogBase)
    {
        dialogueBox.SetActive(true);
        dialogueInfo.Clear();
        inDialogue = true;

        if (dialogBase is DialogQuestions)
        {
            isDialogueOption = true;
            DialogQuestions dialogQuestions = dialogBase as DialogQuestions;
            optionCount = dialogQuestions.questionsInfo.Length;
            questionText.text = dialogQuestions.questionText;
            for (int i = 0; i < optionCount; i++)
            {
                optionButtons[i].SetActive(true);
                var buttonText = optionButtons[i].transform.GetChild(0);
                buttonText.gameObject.GetComponent<Text>().text = dialogQuestions.questionsInfo[i].buttonName;
                handler = optionButtons[i].GetComponent<DialogueEventHandler>();
                handler.eventHandler = dialogQuestions.questionsInfo[i].questionEvent;
                if (dialogQuestions.questionsInfo[i].nextDialogue != null)
                {
                    handler.nextDialogue = dialogQuestions.questionsInfo[i].nextDialogue;
                }
                else
                {
                    handler.nextDialogue = null;
                }
            }
        }
        else
        {
            isDialogueOption = false;
        }

        foreach (DialogBase.Info info in dialogBase.dialogueInfo)
        {
            dialogueInfo.Enqueue(info);
        }

        DequeueDialogue();
    }

    public void DequeueDialogue()
    {
        if (isTyping)
        {
            CompleteText();
            StopAllCoroutines();
            isTyping = false;
            return;
        }

        if (dialogueInfo.Count == 0)
        {
            EndOfDialogue();
            return;
        }

        DialogBase.Info info = dialogueInfo.Dequeue();
        info.dialogEvent.Invoke();
        completeText = info.lines;

        dialogueName.text = info.characterName;
        dialogueText.text = info.lines;
        dialogueAvatar.sprite = info.avatar;

        dialogueText.text = "";
        StartCoroutine(TypeDialogue(info));
    }

    IEnumerator TypeDialogue(DialogBase.Info info)
    {
        isTyping = true;
        foreach (char c in info.lines.ToCharArray())
        {
            yield return new WaitForSeconds(delay);
            dialogueText.text += c;
        }
        isTyping = false;
    }

    private void CompleteText()
    {
        dialogueText.text = completeText;
    }

    public void EndOfDialogue()
    {
        dialogueBox.SetActive(false);
        inDialogue = false;
        QuestionsLogic();
    }

    private void QuestionsLogic()
    {
        if (isDialogueOption)
        {
            dialogueQuestion.SetActive(true);
        }
    }

    public void CloseQuestions()
    {
        dialogueQuestion.SetActive(false);
    }
}
