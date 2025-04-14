using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour, IInteractable
{
    
    [TextArea]
    public string noteText = "This is a mysterious note...";

    
    public void Interact()
    {
        UIManager.Instance.ShowNote(noteText);
        
    }

   
}

