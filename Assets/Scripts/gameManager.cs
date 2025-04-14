using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
    public static gameManager instance;
    public TextMeshProUGUI[] ItemName;
    public TextMeshProUGUI[] ItemCount;
    private gameManager Instance;
    private int[] n = {0,0,0,0,0};
    
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Inventory(string item)
    {
        for (int i = 0; i < item.Length; i++)
        {
            if (ItemName[i].text == "")
            {
                n[i]++;
                ItemName[i].text = item;
                ItemCount[i].text = n[i].ToString("D1");
                break;
            }

            if (ItemName[i].text == item)
            {
                n[i]++;
                ItemCount[i].text = n[i].ToString("D1");
                break;
            }
        }
        
    }
}
