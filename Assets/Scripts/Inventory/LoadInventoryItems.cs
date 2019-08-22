using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadInventoryItems : MonoBehaviour
{
    public GameObject itemsWindow;
    public GameObject charactersWindow;
    public Button itemsFilter, charactersFilter;

    public List<int> boughtItems = new List<int>() { 0 };
    public PurchasableItems purchasableItems;
    public PurchasedItems purchased;
    public Transform itemSlotParent;
    public Transform characterSlotParent;

    CharacterSlot[] characterSlots;
    ItemSlot[] itemSlots;
    StoreItem[] items;
    List<EquippableItem> equippableItems = new List<EquippableItem>();
    List<CharacterItem> characters = new List<CharacterItem>();

    [Header("filter buttons sprite state")]
    public SpriteState filterButtonsStates = new SpriteState();

    [Header("character buttons sprite state")]
    public SpriteState characterButtonsStates = new SpriteState();

    private void Start()
    {
        purchased = PurchasedItems.instance;

        for (int i = 0; i < PurchasedItems.instance.items.Count; i++)
        {
            boughtItems.Add(purchased.items[i]);
        }

        itemSlots = itemSlotParent.GetComponentsInChildren<ItemSlot>();
        characterSlots = characterSlotParent.GetComponentsInChildren<CharacterSlot>();
        items = purchasableItems.items;
        FilterItems();
        LoadItems();
        EnableCharacters();
        if (PlayerPrefs.GetString("previousScene") == "LevelSelector")
        {
            ViewCharacters();
        }
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
            itemSlots[i].item = equippableItems[i];
        }
    }

    void EnableCharacters()
    {
        for (int i = 0; i < characters.Count; i++)
        {
            GameObject characterButtons = GameObject.Find(characters[i].itemName);
            characterButtons.GetComponent<Button>().interactable = true;
            characterButtons.transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    public void ViewItems()
    {
        itemsWindow.SetActive(true);
        itemsFilter.GetComponent<Image>().sprite = filterButtonsStates.highlightedSprite;
        charactersWindow.SetActive(false);
        charactersFilter.GetComponent<Image>().sprite = filterButtonsStates.disabledSprite;
    }

    public void ViewCharacters()
    {
        itemsWindow.SetActive(false);
        itemsFilter.GetComponent<Image>().sprite = filterButtonsStates.disabledSprite;
        charactersWindow.SetActive(true);
        charactersFilter.GetComponent<Image>().sprite = filterButtonsStates.highlightedSprite;
    }
    
}
