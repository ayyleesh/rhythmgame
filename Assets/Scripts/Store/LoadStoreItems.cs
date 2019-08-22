using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadStoreItems : MonoBehaviour
{
    public static LoadStoreItems instance;

    public PurchasableItems purchasable;
    public PurchasedItems purchased;

    public StoreItem[] items;
    public GameObject itemPrefab;
    public GameObject itemContainer;

    public Text currentCoinsText;

    [Header("Confirmation")]
    public GameObject confirmPopUp;
    public Image purchasedItemSprite;
    public Text purchasedItemName;
    public Text purchasedPrice;
    public Button purchaseButton;

    [Header("Message")]
    public GameObject messagePopUp;
    public Text message;

    GameObject[] instItems, button;
    public List<int> boughtItems = new List<int> { 0, 1 };

    int currentCoins;
    // Start is called before the first frame update
    void Start()
    {
        purchased = PurchasedItems.instance;
        purchasable = PurchasableItems.instance;
        instance = this;
        currentCoins = PlayerPrefs.GetInt("coins");
        currentCoinsText.text = "" + currentCoins;
        items = purchasable.items;

        instItems = new GameObject[items.Length];
        button = new GameObject[items.Length];
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i] != null)
            {
                instItems[i] = Instantiate(itemPrefab, itemContainer.transform);
                instItems[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemImage;
                instItems[i].transform.GetChild(1).GetComponent<Text>().text = items[i].itemName;
                instItems[i].transform.GetChild(2).GetComponent<Text>().text = items[i].itemDesc;
                instItems[i].transform.GetChild(4).GetComponentInChildren<Text>().text = "" + items[i].itemPrice;
                int x = i;
                instItems[i].transform.GetChild(4).GetComponent<Button>().onClick.AddListener(() => ShowPopUp(x));
                if (purchased.items.Contains(items[i].itemID))
                {
                    instItems[i].transform.GetChild(5).gameObject.SetActive(true);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuyItem(int index)
    {
        if (currentCoins >= items[index].itemPrice)
        {
            Debug.Log("buy for " + items[index].itemPrice );
            currentCoins = currentCoins - items[index].itemPrice;
            currentCoinsText.text = "" + currentCoins;
            PlayerPrefs.SetInt("coins", currentCoins);
            int boughtItemID = items[index].itemID;
            ShowMessage("Successfully bought " + items[index].itemName + " for " + items[index].itemPrice + " coins!");
            DisableItem(boughtItemID);
            AddToInventory(boughtItemID);
        }
        else
        {
            ShowMessage("You don't have enough coins!");
        }
    }

    public void AddToInventory(int id)
    {
        purchased.items.Add(id);
        PlayerPrefs.SetInt("boughtItem" + (purchased.items.Count - 1), id);
    }

    public void ShowPopUp(int id)
    {
        confirmPopUp.SetActive(true);
        purchasedItemName.text = items[id].itemName;
        purchasedItemSprite.sprite = items[id].itemImage;
        purchasedPrice.text = "" + items[id].itemPrice;
        purchaseButton.onClick.AddListener(() => BuyItem(id));
    }

    public void ShowMessage(string msg)
    {
        messagePopUp.SetActive(true);
        message.text = msg;
    }

    public void ClosePopUp()
    {
        confirmPopUp.SetActive(false);
        messagePopUp.SetActive(false);
    }

    public void DisableItem(int id)
    {
        instItems[id].transform.GetChild(4).gameObject.SetActive(true);
    }
}
