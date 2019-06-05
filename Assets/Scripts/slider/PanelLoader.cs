using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelLoader : MonoBehaviour
{
    public Image albumThumbnail;
    public Text songTitle;
    public Button normalButton;

    public Sprite[] thumbnails;

    SnapScroll snapScroll;
    
    void Start()
    {
        GameObject content = GameObject.Find("Content");
        snapScroll = content.GetComponent<SnapScroll>();
    }
    
    void Update()
    {
        songTitle.text = snapScroll.songTitle[snapScroll.selectedPanelID];
        albumThumbnail.sprite = thumbnails[snapScroll.selectedPanelID];

        int songIndex = snapScroll.selectedPanelID + 1;
        normalButton.GetComponent<Button>().onClick.AddListener(() => LoadLevel("scene"+songIndex));
    }

    private void LoadLevel(string songName)
    {
        SceneManager.LoadScene(songName);
    }
}
