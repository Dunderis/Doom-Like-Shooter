using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject // assign THAT OBJECT ON EVERY OBJECT ON THE MAP with script "PickupItem"

{
    public string itemName;
    public Sprite icon;
}