using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "new item",menuName = "Inventory/Item")]
public class Item : ScriptableObject {

    public Sprite inventorySprite;

    public virtual void Use()
    {
        Debug.Log("Using item " + name);
    }
}
