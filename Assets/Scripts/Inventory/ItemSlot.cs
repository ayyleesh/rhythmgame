using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    public EquippableItem item;

    public void OnClick()
    {
        if (item != null)
        {
            bool isEquipped = Equipment.instance.Add(item);
            if (isEquipped)
            {
                Debug.Log("equipped " + item.itemName);
            }
        }
    }

}
