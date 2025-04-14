using UnityEngine;

public class InteractionController : MonoBehaviour
{
    public float reachDistance = 3f;
    
    void Update()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, reachDistance))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if (interactable && Input.GetKeyDown(KeyCode.E))
            {
                interactable.Interact();
            }
        }
    }
}