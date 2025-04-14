using UnityEngine;

public class PickupItem : MonoBehaviour // PUT THIS SCRIPT ON EVERY PICK UP OBJECT ON THE MAP
{
    public Item itemData;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bool pickedUp = InventorySystem.Instance.AddItem(itemData);
            if (pickedUp) Destroy(gameObject);
        }
    }
}