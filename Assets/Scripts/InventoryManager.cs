using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

    #region Singleton
    private static InventoryManager instance;
    public static InventoryManager Instance
    {
        get
        {
            return instance;
        }
    }

    public void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Multiple instances of " + name + " detected!");
        }
        instance = this;
    }
    #endregion

    public int capacity = 20;
    public List<Item> items = new List<Item>();

    public bool AddItem(Item item)
    {
        if (items.Count >= capacity)
        {
            Debug.Log("Bags are full!");
            return false;
        }

        items.Add(item);
        return true;
    }
}
