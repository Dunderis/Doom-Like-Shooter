using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactRange = 20f;
    public KeyCode interactKey = KeyCode.E;
    private Camera cam;
    

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        
        if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
        {
            
            
            IInteractable interactable = hit.collider.GetComponentInParent<IInteractable>();
            if (interactable != null)
            {
                if (Input.GetKeyDown(interactKey))
                {
                    
                    interactable.Interact();

                }
                
               
            }
            
        }
    }
}