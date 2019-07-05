using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Eguipment",menuName = "Inventory/Eguipment")]
public class Equipment : Item {

    public EquipmentSlot equipSlot;
    public float ArmorMod;
    public float DmgMod;

    public override void Use()
    {
        base.Use();

        InventoryManager.Instance.RemoveItem(this);
        EquipmentManager.Instance.Equip(this);
    }
}
public enum EquipmentSlot { head, chest, legs, feet, weapon, shield }