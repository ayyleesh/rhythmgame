using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipUI : MonoBehaviour
{
    Equipment equipment;
    PurchasableItems purchasableItems;
    EquipmentSlot[] slots;
    public Text warningMessage;
    public Button dismissWarningButton;

    public Transform itemsParent;
    public GameObject warningPopUp;
    public int[] saveEquipped;

    // Start is called before the first frame update
    void Start()
    {
        equipment = Equipment.instance;
        purchasableItems = PurchasableItems.instance;
        equipment.onItemChangedCallBack += UpdateUI;
        warningMessage = warningPopUp.transform.GetComponentInChildren<Text>();
        slots = itemsParent.GetComponentsInChildren<EquipmentSlot>();

        saveEquipped = new int[equipment.equipLimit];
        saveEquipped[0] = PlayerPrefs.GetInt("itemEquipped1");
        saveEquipped[1] = PlayerPrefs.GetInt("itemEquipped2");
        DisplayEquipped();
    }

    void DisplayEquipped()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (saveEquipped[i] != 0)
            {
                bool isEquipped = Equipment.instance.Add(purchasableItems.items[saveEquipped[i]] as EquippableItem);
                slots[i].AddItem(purchasableItems.items[saveEquipped[i]] as EquippableItem);
            }
        }
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

    public void DisplayWarning(string warning)
    {
        warningPopUp.SetActive(true);
        warningMessage.text = warning;
    }

    public void CloseWarning()
    {
        warningPopUp.SetActive(false);
    }

    public void SaveEquippedItem()
    {
        for (int i = 0; i < equipment.equipLimit; i++)
        {
            if (slots[i].item != null)
            {
                saveEquipped[i] = slots[i].item.itemID;
            }
            else
            {
                saveEquipped[i] = 0;
            }
        }

        PlayerPrefs.SetInt("itemEquipped1", saveEquipped[0]);
        PlayerPrefs.SetInt("itemEquipped2", saveEquipped[1]);
        DisplayWarning("Saved!");
        if (PlayerPrefs.GetString("previousScene") == "LevelSelector" || PlayerPrefs.GetString("previousScene") == "Song Selector")
        {
            dismissWarningButton.onClick.AddListener(() => FindObjectOfType<NavButtonScript>().ToPreviousScene());
        }
    }
}
