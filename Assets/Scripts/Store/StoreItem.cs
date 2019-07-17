using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Store Item", menuName = "Store Items")]
[System.Serializable]
public class StoreItem : ScriptableObject
{
    public int itemID;
    //public enum ItemType { character, powerUp};
    //public ItemType itemType;
    public string itemType;
    public Sprite itemImage;
    public string itemName;
    [TextArea(4, 8)]
    public string itemDesc;
    public int itemPrice;
}
