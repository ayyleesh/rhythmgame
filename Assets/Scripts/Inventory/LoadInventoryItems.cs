using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadInventoryItems : MonoBehaviour
{
    List<int> boughtItems = new List<int>() { 0, 1, 2, 3 };
    public PurchasableItems purchasableItems;
    public Transform itemSlotParent;
    public Transform characterSlotParent;

    CharacterSlot[] characterSlots;
    ItemSlot[] itemSlots;
    public StoreItem[] items;
    public List<EquippableItem> equippableItems = new List<EquippableItem>();
    public List<CharacterItem> characters = new List<CharacterItem>();

    private void Start()
    {
        itemSlots = itemSlotParent.GetComponentsInChildren<ItemSlot>();
        characterSlots = characterSlotParent.GetComponentsInChildren<CharacterSlot>();
        items = purchasableItems.items;
        FilterItems();
        LoadItems();
        LoadCharacters();
    }

    void FilterItems()
    {
        for (int i = 0; i < boughtItems.Count; i++)
        {
            if (items[boughtItems[i]] is EquippableItem)
            {
                equippableItems.Add(items[boughtItems[i]] as EquippableItem);
            }
            else if (items[boughtItems[i]] is CharacterItem)
            {
                characters.Add(items[boughtItems[i]] as CharacterItem);
            }
        }
    }

    void LoadItems()
    {
        for (int i = 0; i < equippableItems.Count; i++)
        {
            Image image = itemSlots[i].transform.GetChild(0).GetComponent<Image>();
            image.enabled = true;
            image.sprite = equippableItems[i].itemImage;
        }
    }

    void LoadCharacters()
    {
        for (int i = 0; i < characters.Count; i++)
        {
            Image image = characterSlots[i].transform.GetChild(0).GetComponent<Image>();
            image.enabled = true;
            image.sprite = characters[i].characterSprite;
        }
    }

    //public GameObject inventoryPrefab;
    //public GameObject container;

    //public StoreItem[] purchasableItems;
    //List<int> boughtItems = new List<int> { 1, 0 };

    //GameObject[] instInventoryItems;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    int listLength = boughtItems.Count;
    //    instInventoryItems = new GameObject[listLength];
    //    for (int i = 0; i < listLength; i++)
    //    {
    //        instInventoryItems[i] = Instantiate(inventoryPrefab, container.transform, false);
    //        instInventoryItems[i].transform.GetChild(0).GetComponent<Image>().sprite = purchasableItems[boughtItems[i]].itemImage;
    //        instInventoryItems[i].transform.GetChild(1).GetComponent<Text>().text = purchasableItems[boughtItems[i]].itemName;
    //    }
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}

    //public void FilterCharacters()
    //{
    //    for (int i = 0; i < instInventoryItems.Length; i++)
    //    {
    //        if (purchasableItems[i].itemType != "character")
    //        {
    //            instInventoryItems[i].SetActive(false);
    //        }
    //        if (purchasableItems[i].itemType == "character" && !instInventoryItems[i].activeInHierarchy)
    //        {
    //            instInventoryItems[i].SetActive(true);
    //        }
    //    }
    //}

    //public void FilterPowerUps()
    //{
    //    for (int i = 0; i < instInventoryItems.Length; i++)
    //    {
    //        if (purchasableItems[i].itemType != "powerUp")
    //        {
    //            instInventoryItems[i].SetActive(false);
    //        }
    //        if (purchasableItems[i].itemType == "powerUp" && !instInventoryItems[i].activeInHierarchy)
    //        {
    //            instInventoryItems[i].SetActive(true);
    //        }
    //    }
    //}

    //public void ShowAll()
    //{
    //    for (int i = 0; i < instInventoryItems.Length; i++)
    //    {
    //        if (!instInventoryItems[i].activeInHierarchy)
    //        {
    //            instInventoryItems[i].SetActive(true);
    //        }
    //    }
    //}
}
