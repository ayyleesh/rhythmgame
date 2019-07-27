using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level Group", menuName = "Scrolling Object/Level Group")]
[System.Serializable]
public class LevelGroups : RhythmSong
{
    public string[] levelNames;
    public string[] romajiNames;
}
