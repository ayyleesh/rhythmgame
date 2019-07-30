using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level Group", menuName = "Menu Object/Level Group")]
[System.Serializable]
public class LevelMenuObject : MenuObject
{
    public string[] levelNames;
    public string[] romajiNames;
}
