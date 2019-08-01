using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Character", menuName = "Item/Character Item")]
[System.Serializable]
public class CharacterItem : StoreItem
{
    public Sprite characterSprite;
}
