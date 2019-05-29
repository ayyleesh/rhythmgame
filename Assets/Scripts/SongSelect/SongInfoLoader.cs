using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongInfoLoader : MonoBehaviour
{
    public string songName;
    public Image coverAlbum;
    public AudioSource songPreview;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySong()
    {
        songPreview.Play();
    }

    public void StopPlaying()
    {
        songPreview.Stop();
    }
}
