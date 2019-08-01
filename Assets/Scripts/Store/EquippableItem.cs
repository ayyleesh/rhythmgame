using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equippable Item", menuName = "Item/Equippable Item")]
[System.Serializable]
public class EquippableItem : StoreItem
{
    public float coinMultiplier;
    public float expMultiplier;
}
