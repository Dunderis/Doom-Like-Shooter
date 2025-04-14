using UnityEngine;

// Door inherits from Interactable
public class Door : Interactable
{
    public bool isLocked = false;
    [Tooltip("Key needed to unlock the door (if needs key put 'blue_key' or 'red_key')")]
    public string keyNeeded = "";
    [Tooltip("Height the door opens")]
    public float openHeight = 3f; 
    public float openSpeed = 3f;
    public AudioClip doorSound;
    
    private bool isOpen = false;
    private Vector3 closedPosition;
    private Vector3 openPosition;
    
    void Start()
    {
        closedPosition = transform.position;
        openPosition = closedPosition + new Vector3(0, openHeight, 0);
    }
    
    void Update()
    {
        if (isOpen && transform.position != openPosition)
        {
            transform.position = Vector3.Lerp(transform.position, openPosition, Time.deltaTime * openSpeed);
        }
        else if (!isOpen && transform.position != closedPosition)
        {
            transform.position = Vector3.Lerp(transform.position, closedPosition, Time.deltaTime * openSpeed);
        }
    }
    
    // Override the Interact method from the base class
    public override void Interact()
    {
        if (isLocked)
        {
            if (keyNeeded != "")
            {
                // INVENTORY INTEGRATION
                // When inventory is ready, add:
                // Inventory inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
                // if (inventory && inventory.HasKey(keyNeeded))
                // {
                //     isLocked = false;
                //     ToggleDoor();
                // }
                // else
                // {
                    Debug.Log("You need a key to open this door");
                // }
            }
            else
            {
                Debug.Log("This door is locked");
            }
        }
        else
        {
            ToggleDoor();
        }
    }
    
    void ToggleDoor()
    {
        isOpen = !isOpen;
        
        if (doorSound)
            AudioSource.PlayClipAtPoint(doorSound, transform.position);
    }
}