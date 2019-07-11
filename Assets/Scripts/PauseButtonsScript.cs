using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseButtonsScript : MonoBehaviour
{
    public bool isPaused = false;
    public bool enableCountDown;
    public GameObject pauseBG;
    public GameObject pausePanel;
    public GameObject countDownText;
    public GameObject replayConfirmPopUp;
    public GameObject exitConfirmPopUp;
    public AudioSource gameMusic, gameSFX;
    public Slider musicAdjustSlider, sfxAdjustSlider, dialogueSpeedSlider;

    public void Start()
    {
        gameMusic = GameObject.Find("GameMusic").GetComponent<AudioSource>();
        gameSFX = GameObject.Find("TapFX").GetComponent<AudioSource>();
    }

    public void Update()
    {
        AdjustVolume(musicAdjustSlider, gameMusic);
        AdjustVolume(sfxAdjustSlider, gameSFX);
        AdjustSpeed(dialogueSpeedSlider);
    }

    public void IncreaseVolume()
    {
        Transform parent = EventSystem.current.currentSelectedGameObject.transform.parent;
        Slider slider = parent.GetComponentInChildren<Slider>();
        if (slider.value <= slider.maxValue)
        {
            slider.value += 1;
        }
    }

    public void DecreaseVolume()
    {
        Transform parent = EventSystem.current.currentSelectedGameObject.transform.parent;
        Slider slider = parent.GetComponentInChildren<Slider>();
        if (slider.value >= slider.minValue)
        {
            slider.value -= 1;
        }
    }

    public void AdjustVolume(Slider slider, AudioSource sound)
    {
        Transform nodesContainer = slider.transform.Find("Nodes");
        sound.volume = 0.25f * slider.value;
        int sliderValue = (int)slider.value;
        for (int i = 1; i <= slider.value; i++)
        {
            nodesContainer.transform.GetChild(i).GetComponent<Image>().color = new Color32(36, 214, 255, 255);
        }
        for (int k = (int)slider.value + 1; k < slider.maxValue + 1; k++)
        {
            nodesContainer.transform.GetChild(k).GetComponent<Image>().color = new Color32(0, 0, 0, 130);
        }
    }

    public void AdjustSpeed(Slider slider)
    {
        if (slider.value == 0)
        {
            DialogManager.instance.delay = 0.05f;
        }
        else if (slider.value == 2)
        {
            DialogManager.instance.delay = 0.01f;
        }
        
    }

    public void PauseGame()
    {
        if (isPaused == false)
        {
            Time.timeScale = 0;
            gameMusic.Pause();
            pauseBG.SetActive(true);
            pausePanel.SetActive(true);
            isPaused = true;
        }
    }

    public void UnpauseGame()
    {
        if (isPaused == true)
        {
            isPaused = false;
            pausePanel.SetActive(false);
            
            if (enableCountDown == true)
            {
                countDownText.SetActive(true);
                StartCoroutine(CountDown());
            }
            else
            {
                pauseBG.SetActive(false);
                gameMusic.Play();
                Time.timeScale = 1;
            }
        }
    }

    IEnumerator CountDown()
    {
            float pauseTime = Time.realtimeSinceStartup + 4f;
            while (Time.realtimeSinceStartup < pauseTime)
                yield return 0;
            countDownText.SetActive(false);
            pauseBG.SetActive(false);
            gameMusic.Play();
            Time.timeScale = 1;        
    }

    public void Replay()
    {
        replayConfirmPopUp.SetActive(true);
    }

    public void CancelReplay()
    {
        replayConfirmPopUp.SetActive(false);
        UnpauseGame();
    }

    public void ConfirmReplay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        exitConfirmPopUp.SetActive(true);
    }

    public void CancelExit()
    {
        exitConfirmPopUp.SetActive(false);
        UnpauseGame();
    }

    public void ConfirmExit()
    {
        SceneManager.LoadScene("Song Selector");
    }

    public void ExitLesson()
    {
        SceneManager.LoadScene("LevelSelector");
    }

    
}
