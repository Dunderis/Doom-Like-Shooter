using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;
using UnityEngine.UI;
using TMPro;
using UnityEditor.PackageManager;
using System.Linq.Expressions;

public class InventorySystem : MonoBehaviour // PUT THIS ON EMPTY OBJECT
{
    public static InventorySystem Instance;

    public List<Item> items = new List<Item>();
    public List<GameObject>inventorySlots = new List<GameObject>();
    public GameObject activationWindow;
    public GameObject chosenItemSlot;
    public TMP_Text itemText;
    private int inventorySize = 10;
    private int chosenItemIndex = -1;

    [Header("Health Bars")]
    public HealthBar hpBar;
    public HealthBar armorBar;

    private void Awake()
    {
        Instance = this;
    }
    private void Update()
    {
        for (int i = 0; i <= 9; i++)
        {
            if (Input.GetKeyDown((KeyCode)System.Enum.Parse(typeof(KeyCode), "Alpha" + i)))
            {
                Debug.Log("Number key " + i + " was pressed.");
                if (i == 0) chosenItemIndex = 9;
                else chosenItemIndex = i - 1;
                if(chosenItemIndex<items.Count) ShowActivation(true);
                else ShowActivation(false);
            }
        }
        if(chosenItemIndex!=-1 && Input.GetKeyDown(KeyCode.E))
        {
            UseItem();
            ShowActivation(false);
        }
    }

    public bool AddItem(Item newItem)
    {
        if (items.Count >= inventorySize)
        {
            Debug.Log("Inventory full!");
            return false;
        }
        if(newItem.itemName=="Ammo")
        {
            //ShootScript.Instance.ammo += 60;
            return true;
        }
        items.Add(newItem);
        Debug.Log("Item added: " + newItem.itemName);
        UpdateInventory();
        return true;
    }

    public void UseItem()
    {
        Debug.Log("Used: " + items[chosenItemIndex].itemName);
        switch (items[chosenItemIndex].itemName)
        {
            case "Medkit1":
                Player.Instance.HealHp(10);
                hpBar.Heal(10);
                break;
            case "Medkit2":
                Player.Instance.HealHp(50);
                hpBar.Heal(50);
                break;
            case "Armor1":
                Player.Instance.HealArmor(10);
                armorBar.Heal(10);
                break;
            case "Armor2":
                Player.Instance.HealArmor(25);
                armorBar.Heal(25);
                break;
            default:
                break;
        }
        
        items.Remove(items[chosenItemIndex]);
        chosenItemIndex = -1;
        ShowActivation(false);
        UpdateInventory();
        
    }
    public void UpdateInventory()
    {
        for (int i = 0; i < inventorySize; i++)
        {
            if (i<items.Count)
            {
                inventorySlots[i].GetComponent<Image>().sprite = items[i].icon;
                inventorySlots[i].GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
            else
            {
                inventorySlots[i].GetComponent<Image>().sprite = null;
                inventorySlots[i].GetComponent<Image>().color = new Color(1,1,1,0.2f);
            }
        }
    }
    private void ShowActivation(bool show)
    {
        chosenItemSlot.SetActive(show);
        chosenItemSlot.transform.localPosition = new Vector2(-100+(chosenItemIndex%5)*40,17-chosenItemIndex/5*39);
        activationWindow.SetActive(show);
        if(show==true) itemText.text = items[chosenItemIndex].itemName;
    }
}