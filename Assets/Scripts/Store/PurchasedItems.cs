using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchasedItems : MonoBehaviour
{
    public static PurchasedItems instance;
    PurchasableItems purchasableItems;

    public List<int> items = new List<int>{ };

    public void Start()
    {
        purchasableItems = PurchasableItems.instance;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        
        for (int i = 0; i < purchasableItems.items.Length; i++)
        {
            int index = PlayerPrefs.GetInt("boughtItem" + i);
            if (index != 0)
            {
                items.Add(index);
            }

        }
    }
}
