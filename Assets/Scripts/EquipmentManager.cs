using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EquipmentManager : MonoBehaviour {

    #region Singleton
    private static EquipmentManager instance;
    public static EquipmentManager Instance
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

        var numSlots = Enum.GetNames(typeof(EquipmentSlot)).Length;
        equipment = new Equipment[numSlots];
    }
    #endregion

    public Equipment[] equipment;

    public bool Equip(Equipment newItem)
    {
        Unequip(newItem.equipSlot);

        // Still equipment in the equipment slot!?
        if (equipment[(int)newItem.equipSlot] != null)
        {
            // Then we can't equip this item
            return false;
        }

        equipment[(int)newItem.equipSlot] = newItem;

        if (OnEquipmentChanged != null)
        {
            OnEquipmentChanged.Invoke(null, newItem);
        }
        return true;
    }

    public Equipment Unequip(EquipmentSlot slot)
    {
        if (equipment[(int)slot] == null)
        {
            return null;
        }

        var oldItem = equipment[(int)slot];

        if (!InventoryManager.Instance.AddItem(oldItem))
        {
            // Not enough bag space to unequip this item!
            return null;
        }

        equipment[(int)slot] = null;

        if (OnEquipmentChanged != null)
        {
            OnEquipmentChanged.Invoke(oldItem, null);
        }

        return oldItem;
    }

    public event Action<Equipment, Equipment> OnEquipmentChanged;
}
