using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Camera playerCamera;
    public float interactionDistance = 3f;

    void Update()
    {
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * interactionDistance, Color.red);

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (interactable != null && Input.GetKeyDown(KeyCode.E))
            {
                // Access the singleton instance and call the Add method.
                InventorySystem.Instance.Add(interactable.itemdata);

                // Now destroy the object from the scene.
                Destroy(hit.collider.gameObject);
            }
        }
    }
}