using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event", menuName = "Events")]
public class EventBehavior : ScriptableObject
{
    public void Test()
    {
        Debug.Log("test"); 
    }
}
