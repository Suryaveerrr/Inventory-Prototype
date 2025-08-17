using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Transform slotContainer;
    public GameObject slotPrefab;
    public GameObject crossHair;

    private bool isPanelActive;
    private List<GameObject> instantiatedSlots = new List<GameObject>();

    void Start()
    {
        // Subscribe to the event from the InventorySystem
        InventorySystem.Instance.OnInventoryChanged += UpdateUI;

        
    }

    void Update()
    {
        // Check for the 'I' key to toggle the inventory panel
        if (Input.GetKeyDown(KeyCode.I))
        {
            isPanelActive = !isPanelActive;
            inventoryPanel.SetActive(isPanelActive);
            crossHair.SetActive(!isPanelActive); 

            // Manage cursor visibility and lock state
            if (isPanelActive)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }

            
        }
    }

    void UpdateUI()
    {
        // Clear all the old slots before redrawing
        foreach (GameObject slot in instantiatedSlots)
        {
            Destroy(slot);
        }
        instantiatedSlots.Clear();

        // Get the current inventory list and draw new slots
        foreach (ItemData item in InventorySystem.Instance.inventory)
        {
            GameObject newSlot = Instantiate(slotPrefab, slotContainer);
            instantiatedSlots.Add(newSlot);

            // Find the child 'ItemIcon' image and set its sprite
            Image itemIcon = newSlot.transform.Find("ItemIcon").GetComponent<Image>();
            itemIcon.sprite = item.icon;
            itemIcon.enabled = true; // Make sure the image component is visible
        }
    }

    // It's good practice to unsubscribe from events when the object is destroyed
    private void OnDestroy()
    {
        InventorySystem.Instance.OnInventoryChanged -= UpdateUI;
    }
}