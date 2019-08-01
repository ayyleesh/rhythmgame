using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{
    EquippableItem item;

    public Image icon;
    public Button removeButton;

    public void AddItem(EquippableItem newItem)
    {
        item = newItem;
        icon.sprite = item.itemImage;
        icon.enabled = true;
        removeButton.interactable = true;

    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnRemoveButton()
    {
        Equipment.instance.Remove(item);
    }
}
