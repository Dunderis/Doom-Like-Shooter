using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class ObjectInteract1 : MonoBehaviour, IInteractable
{
    
    public void Interact()
    {
        Destroy(gameObject);
        
    }
    
}
