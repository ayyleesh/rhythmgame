using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    public static Equipment instance;
    public int equipLimit = 2;
    public List<EquippableItem> equipped = new List<EquippableItem>();

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than 1 instance of equipment found");
            return;
        }
        instance = this;
    }

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;

    public bool Add(EquippableItem item)
    {
        if (equipped.Count >= equipLimit)
        {
            FindObjectOfType<EquipUI>().DisplayWarning("Not enough rooms!");
            return false;
        }
        equipped.Add(item);

        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();

        return true;
    }

    public void Remove(EquippableItem item)
    {
        equipped.Remove(item);

        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }
}
