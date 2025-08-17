# Inventory Prototype
A functional prototype of a first-person inventory system built in Unity. This project demonstrates core mechanics for item management, player interaction, and dynamic UI rendering, making it a great foundation for any game requiring an inventory.
---

## Features

* **Raycast-Based Item Pickup**: Look at items in the game world and press 'E' to pick them up.
* **Dynamic Inventory UI**:
    * Press 'I' to toggle the inventory panel on and off.
    * Automatically hides the player's crosshair when the inventory is open.
    * Uses a `Grid Layout Group` to neatly arrange all collected item icons in real-time.
* **Scriptable Object Architecture**: All items are defined as **ScriptableObject** assets. This data-driven approach allows for new items (with their own names, icons, and 3D prefabs) to be created and modified easily without writing any new code.
* **Timed UI Elements**: Demonstrates the use of Coroutines by displaying a temporary "Controls" message for 5 seconds at the start of the game.

---

## Key Concepts Demonstrated

This project serves as a practical example of several important programming patterns and Unity features:

* **Singleton Pattern**: The `InventorySystem` is implemented as a singleton, ensuring there is only one globally accessible manager for all inventory data.
* **Observer Pattern (Events & Actions)**: The UI is decoupled from the backend logic. The `InventoryUI` script subscribes to an `OnInventoryChanged` event, only updating the visuals when the inventory data actually changes.
* **Prefab-Based Workflow**: All in-world items and UI slots are based on prefabs, allowing for efficient and consistent object creation.
* **Coroutines**: Used to handle time-based operations without freezing the game.
