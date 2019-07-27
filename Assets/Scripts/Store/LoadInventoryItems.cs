using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadInventoryItems : MonoBehaviour
{

    public GameObject inventoryPrefab;
    public GameObject container;

    public StoreItem[] purchasableItems;
    List<int> boughtItems = new List<int> { 1, 0 };

    [Header("Sprite for filter buttons")]
    public SpriteState state = new SpriteState();

    GameObject[] instInventoryItems;
    // Start is called before the first frame update
    void Start()
    {
        purchasableItems = FindObjectOfType<PurchasableItems>().purchasableItems;
        GameObject.Find("Filter/All").GetComponent<Image>().sprite = state.pressedSprite;
        int listLength = boughtItems.Count;
        instInventoryItems = new GameObject[listLength];
        for (int i = 0; i < listLength; i++)
        {
            instInventoryItems[i] = Instantiate(inventoryPrefab, container.transform, false);
            instInventoryItems[i].transform.GetChild(0).GetComponent<Image>().sprite = purchasableItems[boughtItems[i]].itemImage;
            instInventoryItems[i].transform.GetChild(1).GetComponent<Text>().text = purchasableItems[boughtItems[i]].itemName;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FilterCharacters()
    {
        GameObject.Find("Filter/Character").GetComponent<Image>().sprite = state.disabledSprite;
        GameObject.Find("Filter/All").GetComponent<Image>().sprite = state.disabledSprite;
        GameObject.Find("Filter/PowerUp").GetComponent<Image>().sprite = state.pressedSprite;
        for (int i = 0; i < instInventoryItems.Length; i++)
        {
            if (purchasableItems[i].itemType != "character")
            {
                instInventoryItems[i].SetActive(false);
            }
            if (purchasableItems[i].itemType == "character" && !instInventoryItems[i].activeInHierarchy)
            {
                instInventoryItems[i].SetActive(true);
            }
        }
    }

    public void FilterPowerUps()
    {
        GameObject.Find("Filter/Character").GetComponent<Image>().sprite = state.pressedSprite;
        GameObject.Find("Filter/All").GetComponent<Image>().sprite = state.disabledSprite;
        GameObject.Find("Filter/PowerUp").GetComponent<Image>().sprite = state.disabledSprite;
        for (int i = 0; i < instInventoryItems.Length; i++)
        {
            if (purchasableItems[i].itemType != "powerUp")
            {
                instInventoryItems[i].SetActive(false);
            }
            if (purchasableItems[i].itemType == "powerUp" && !instInventoryItems[i].activeInHierarchy)
            {
                instInventoryItems[i].SetActive(true);
            }
        }
    }

    public void ShowAll()
    {
        GameObject.Find("Filter/Character").GetComponent<Image>().sprite = state.disabledSprite;
        GameObject.Find("Filter/All").GetComponent<Image>().sprite = state.pressedSprite;
        GameObject.Find("Filter/PowerUp").GetComponent<Image>().sprite = state.disabledSprite;
        for (int i = 0; i < instInventoryItems.Length; i++)
        {
            if (!instInventoryItems[i].activeInHierarchy)
            {
                instInventoryItems[i].SetActive(true);
            }
        }
    }
}
