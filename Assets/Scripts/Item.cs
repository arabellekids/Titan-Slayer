using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new item",menuName = "Inventory/Item")]
public class Item : ScriptableObject {
    public string name;
    public Sprite InventorySprite;
    
}
