using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Equippable Item", menuName = "Items/Equippable Items")]
[System.Serializable]
public class EquippableItem : StoreItem
{
    public float extraExp;
    public float extraCoins;
}
