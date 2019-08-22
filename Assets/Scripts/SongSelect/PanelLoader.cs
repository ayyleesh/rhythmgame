using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelLoader : MonoBehaviour
{
    public Image albumThumbnail;
    public Text songTitle;
    public Text bpmIndicator;
    public Text levelIndicator;
    public Button normalButton;
    public Button lockedButton;

    public SongMenuObject[] songMenus;
    SnapScroll snapScroll;
    MenuObject[] menu;
    
    void Start()
    {
        GameObject content = GameObject.Find("Content");
        snapScroll = content.GetComponent<SnapScroll>();
        menu = snapScroll.menu;
        songMenus = new SongMenuObject[menu.Length];
        for (int i = 0; i < menu.Length; i++)
        {
            songMenus[i] = menu[i] as SongMenuObject;
        }
    }
    
    void Update()
    {
        songTitle.text = songMenus[snapScroll.selectedPanelID].itemName;
        levelIndicator.text = "Level: " + songMenus[snapScroll.selectedPanelID].level;
        bpmIndicator.text = "BPM: " + songMenus[snapScroll.selectedPanelID].bpm;
        albumThumbnail.sprite = songMenus[snapScroll.selectedPanelID].itemThumbnail;

        int songIndex = snapScroll.selectedPanelID + 1;
        if (snapScroll.selectedPanelID < 1)
        {
            normalButton.GetComponent<Button>().onClick.AddListener(() => LoadLevel("scene" + songIndex));
            lockedButton.gameObject.SetActive(false);
        }
        else
        {
            lockedButton.gameObject.SetActive(true);
        }
        
    }

    private void LoadLevel(string songName)
    {
        SceneManager.LoadScene(songName);
    }
}
