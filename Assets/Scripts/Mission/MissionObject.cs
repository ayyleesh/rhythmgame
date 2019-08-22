using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Mission", menuName = "Mission")]
public class MissionObject : ScriptableObject
{
    public string missionName;
    public string missionImage;
    public RewardObject reward;
    public GoalsObjects goal;
}
