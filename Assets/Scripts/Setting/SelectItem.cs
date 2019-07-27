using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectItem : MonoBehaviour
{
    List<int> boughtItems = new List<int> { 1, 2, 3 };
    StoreItem[] purchasableItems;
    public GameObject content, equipSlot;
    InventoryItem[] inventoryItems;
    public EquippedItem[] equippedItems;
    public List<int> itemsToEquip;
    public List<int> powerUpItems;
    public SpriteState state = new SpriteState();
    public int itemsEquipped;

    public int itemEquipped1, itemEquipped2;

    public void Start()
    {
        purchasableItems = FindObjectOfType<PurchasableItems>().purchasableItems;
        inventoryItems = content.GetComponentsInChildren<InventoryItem>();
        equippedItems = equipSlot.GetComponentsInChildren<EquippedItem>();
        LoadItems();
        LoadEquippedItem();
    }

    public void LoadEquippedItem()
    {
        if (PlayerPrefs.GetInt("itemEquipped1") != 0 || PlayerPrefs.GetInt("itemEquipped1") != 0)
        {
            itemEquipped1 = PlayerPrefs.GetInt("itemEquipped1");
            itemEquipped2 = PlayerPrefs.GetInt("itemEquipped2");
            equippedItems[0].transform.GetChild(0).gameObject.SetActive(true);
            equippedItems[1].transform.GetChild(0).gameObject.SetActive(true);
            equippedItems[0].transform.GetChild(0).GetComponent<Image>().sprite = purchasableItems[itemEquipped1].itemImage;
            equippedItems[1].transform.GetChild(0).GetComponent<Image>().sprite = purchasableItems[itemEquipped2].itemImage;
        }
    }

    public void LoadItems()
    {
        
        for (int i = 0; i < boughtItems.Count; i++)
        {
            StoreItem item = purchasableItems[boughtItems[i]];
            
            if (item.itemType == "powerUp")
            {
                powerUpItems.Add(item.itemID);
            }
        }
        for (int i = 0; i < powerUpItems.Count; i++)
        {
            Image image = inventoryItems[i].transform.GetChild(0).GetComponentInChildren<Image>();
            image.enabled = true;
            image.sprite = purchasableItems[powerUpItems[i]].itemImage;
            inventoryItems[i].GetComponent<InventoryItem>().itemID = purchasableItems[powerUpItems[i]].itemID;
            int x = i;
            inventoryItems[i].GetComponent<Button>().onClick.AddListener(() => OnItemSelect(powerUpItems[x]));
        }
    }

    public void OnItemSelect(int itemID)
    {
        if (itemsToEquip.Contains(itemID))
        {
            Debug.Log("item is already equipped");
            return;
        }
        if (itemsEquipped < 2)
        {
            itemsEquipped += 1;
            EventSystem.current.currentSelectedGameObject.GetComponent<InventoryItem>().isEquipped = true;
            EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite = state.pressedSprite;
            EquipItems(itemID);
        }
        else
        {
            Debug.Log("maximum reached");
            EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite = state.disabledSprite;
        }
    }

    public void EquipItems(int itemID)
    {
        Debug.Log("equipped " + purchasableItems[itemID].itemName);
        GameObject image = equipSlot.transform.GetChild(itemsEquipped).GetChild(0).gameObject;
        image.SetActive(true);
        image.GetComponentInChildren<Image>().sprite = purchasableItems[itemID].itemImage;
        equippedItems[itemsEquipped - 1].itemID = purchasableItems[itemID].itemID;
        itemsToEquip.Add(purchasableItems[itemID].itemID);
    }

    public void DequipItems()
    {
        EquippedItem unequippedItem = EventSystem.current.currentSelectedGameObject.GetComponentInParent<EquippedItem>();
        Debug.Log("unequipped " + unequippedItem.itemID);
        itemsEquipped -= 1;
        itemsToEquip.Remove(unequippedItem.itemID);
        DeselectItem(unequippedItem.itemID);
        unequippedItem.itemID = 0;
        unequippedItem.transform.GetChild(0).gameObject.SetActive(false);

        if (equippedItems[0].itemID == 0 && equippedItems[1].itemID != 0)
        {
            Debug.Log("move up");
            equippedItems[0].transform.GetChild(0).GetComponent<Image>().sprite = equippedItems[1].transform.GetChild(0).GetComponent<Image>().sprite;
            equippedItems[0].transform.GetChild(0).gameObject.SetActive(true);
            equippedItems[1].transform.GetChild(0).GetComponent<Image>().sprite = null;
            equippedItems[1].transform.GetChild(0).gameObject.SetActive(false);
        }
    }
    
    public void DeselectItem(int itemID)
    {
        Debug.Log("deselected ");
    }

    public void ConfirmItemsEquip()
    {
        itemEquipped1 = equippedItems[0].itemID;
        itemEquipped2 = equippedItems[1].itemID;
        PlayerPrefs.SetInt("itemEquipped1", itemEquipped1);
        PlayerPrefs.SetInt("itemEquipped2", itemEquipped2);
    }
}
