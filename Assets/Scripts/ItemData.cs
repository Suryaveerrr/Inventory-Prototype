using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    [Header("Item info")]
    public string itemName;
    public string description;
    public Sprite icon;
    public GameObject itemPrefab;

    [Header("Combining")]
    public ItemData itemToCombineWith;
    public ItemData resultingItem;

}
