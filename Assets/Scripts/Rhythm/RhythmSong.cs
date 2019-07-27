using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Song", menuName = "Scrolling Object/Rhythm Song")]
[System.Serializable]
public class RhythmSong : ScriptableObject
{
    public string itemName;
    public Sprite itemThumbnail;
    public int level;
    public int bpm;
}
