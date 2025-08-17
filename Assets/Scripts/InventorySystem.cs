using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public static InventorySystem Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    //END OF SINGLETON SETUP

    public List<ItemData> inventory = new List<ItemData>();

    public event Action OnInventoryChanged;

    public void Add(ItemData item)
    {
        inventory.Add(item);
        Debug.Log("Added " + item.itemName + " to inventory.");
        // Notify any listeners (like the UI) that the inventory has changed.
        OnInventoryChanged?.Invoke();
    }

    public void Remove(ItemData item)
    {
        inventory.Remove(item);
        Debug.Log("Removed " + item.itemName + " from inventory.");
        // Notify any listeners that the inventory has changed.
        OnInventoryChanged?.Invoke();
    }


}
