using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelLoader : MonoBehaviour
{
    public Image songThumbnail;
    public Text songTitle;
    public Text bpmIndicator;
    public Text levelIndicator;
    public Button normalButton;

    ButtonsScript buttonsScript;
    SnapScroll snapScroll;
    
    void Start()
    {
        GameObject content = GameObject.Find("Content");
        snapScroll = content.GetComponent<SnapScroll>();
        buttonsScript = FindObjectOfType<ButtonsScript>();
    }
    
    void Update()
    {
        songTitle.text = snapScroll.rhythmSongs[snapScroll.selectedPanelID].itemName;
        bpmIndicator.text = "BPM: " + snapScroll.rhythmSongs[snapScroll.selectedPanelID].bpm;
        levelIndicator.text = "Level: " + snapScroll.rhythmSongs[snapScroll.selectedPanelID].level;
        songThumbnail.sprite = snapScroll.rhythmSongs[snapScroll.selectedPanelID].itemThumbnail;

        int songIndex = snapScroll.selectedPanelID + 1;
        normalButton.GetComponent<Button>().onClick.AddListener(() => buttonsScript.LoadSongInfo(songIndex));
    }

    private void LoadLevel(string songName)
    {
        SceneManager.LoadScene(songName);
    }
}
