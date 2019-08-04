using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchasableItems : MonoBehaviour
{
    public static PurchasableItems instance;

    public StoreItem[] items;

    public void Awake()
    {
        instance = this;
    }
}
