using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SongSelector : MonoBehaviour
{
    public GameObject selectSongButton;
    public GameObject buttonContainer;

    private void Start()
    {
        Sprite[] thumbnails = Resources.LoadAll<Sprite>("LevelThumbnails");
        //foreach (Sprite thumbnail in thumbnails)
        //{
            GameObject container = Instantiate(selectSongButton) as GameObject;
            container.transform.parent = buttonContainer.transform;

        string songName = "scene1" /*thumbnail.name;*/;
        container.GetComponent<Button>().onClick.AddListener(() => LoadLevel(songName));
            //container.GetComponent<Image>().sprite = thumbnail;
        //}
    }

    private void LoadLevel(string songName)
    {
        SceneManager.LoadScene(songName);
    }
}
