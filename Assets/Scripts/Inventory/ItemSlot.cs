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

            if (Equipment.instance.equipped.Count != 0 && item == Equipment.instance.equipped[0])
            {
                FindObjectOfType<EquipUI>().DisplayWarning("Item is already equipped!");
                return;
            }
            bool isEquipped = Equipment.instance.Add(item);
            if (isEquipped)
            {
                Debug.Log("equipped " + item.itemName);
            }
        }
    }

}
