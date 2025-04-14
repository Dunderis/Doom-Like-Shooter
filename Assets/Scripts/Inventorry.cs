using System;
using UnityEngine;
using TMPro;

public class Inventorry : MonoBehaviour
{
    
    
    public GameObject InventorryText;
    private string[] Inventorys = {"","","","",""};
    private bool Opened = false;

    
    void Start()
    {
        InventorryText.SetActive(false);
        print(Inventorys.Length);
        
    }

 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !Opened)
        {
            
            InventorryText.SetActive(true);
            Opened = true;
        }
        else if(Input.GetKeyDown(KeyCode.E) && Opened)
        {
            InventorryText.SetActive(false);
            Opened = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        for (int i = 0; i < 5; i++)
        {
            if (Inventorys[i] == "" && !other.gameObject.CompareTag("Floor") )
            {
                Inventorys[i] = other.transform.tag.ToString();
                gameManager.instance.Inventory(Inventorys[i]);
                Destroy(other.gameObject);
                print("Hello");
                break;
            }
            if(Inventorys[i] == other.transform.tag.ToString())
            {
                gameManager.instance.Inventory(Inventorys[i]);
                Destroy(other.gameObject);
                break;
            }
        }

        for (int i = 0; i < Inventorys.Length; i++)
        {
            print(Inventorys[i]);
        }
        
    }
}
