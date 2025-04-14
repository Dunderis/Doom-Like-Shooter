using UnityEngine;

public class Pickup : MonoBehaviour
{
    [Header("Pickup Type")]
    public PickupType type = PickupType.Health;
    
    [Header("General Settings")]
    public int amount = 10;
    public AudioClip pickupSound;
    public bool rotatePickup = true;
    public float rotationSpeed = 100f;
    
    void Update()
    {
        if (rotatePickup)
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            bool pickupSuccessful = false;
            
            switch (type)
            {
                case PickupType.Health:
                    // Commented out until PlayerHealth is implemented
                    /*
                    PlayerHealth health = other.GetComponent<PlayerHealth>();
                    if (health != null)
                    {
                        health.Heal(amount);
                        pickupSuccessful = true;
                    }
                    */
                    
                    // Temporary solution until PlayerHealth exists
                    Debug.Log("Picked up health: " + amount);
                    pickupSuccessful = true;
                    break;
                    
                case PickupType.Ammo:
                    ShootingController shooter = other.GetComponentInChildren<ShootingController>();
                    if (shooter != null)
                    {
                        shooter.AddAmmo(amount);
                        Debug.Log("Added ammo: " + amount);
                        pickupSuccessful = true;
                    }
                    break;
                    
                case PickupType.Armor:
                    // Commented out until PlayerArmor is implemented
                    /*
                    PlayerArmor armor = other.GetComponent<PlayerArmor>();
                    if (armor != null)
                    {
                        armor.AddArmor(amount);
                        pickupSuccessful = true;
                    }
                    */
                    
                    // Temporary solution until PlayerArmor exists
                    Debug.Log("Picked up armor: " + amount);
                    pickupSuccessful = true;
                    break;
                    
                case PickupType.Key:
                    // Commented out until Inventory is implemented
                    /*
                    Inventory inventory = other.GetComponent<Inventory>();
                    if (inventory != null)
                    {
                        inventory.AddKey();
                        pickupSuccessful = true;
                    }
                    */
                    
                    // Temporary solution until Inventory exists
                    Debug.Log("Picked up key");
                    pickupSuccessful = true;
                    break;
            }
            
            if (pickupSuccessful)
            {
                if (pickupSound)
                    AudioSource.PlayClipAtPoint(pickupSound, transform.position);
                
                Destroy(gameObject);
            }
        }
    }
    
    public enum PickupType
    {
        Health,
        Ammo,
        Armor,
        Key
    }
}