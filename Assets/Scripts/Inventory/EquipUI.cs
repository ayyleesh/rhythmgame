using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipUI : MonoBehaviour
{
    Equipment equipment;

    public Transform itemsParent;
    EquipmentSlot[] slots;

    // Start is called before the first frame update
    void Start()
    {
        equipment = Equipment.instance;
        equipment.onItemChangedCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<EquipmentSlot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < equipment.equipped.Count)
            {
                slots[i].AddItem(equipment.equipped[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
