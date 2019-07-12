using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Eguipment",menuName = "Inventory/Eguipment")]
public class Equipment : Item {

    public EquipmentSlot equipSlot;
    public float ArmorMod;
    public float DmgMod;
    public GameObject mesh;

    public override void Use()
    {
        Debug.Log("equiping " + name);
        var spawnPoint = GameObject.FindGameObjectWithTag(equipSlot.ToString()).transform;
        var newObject = Instantiate(mesh, spawnPoint.position, spawnPoint.rotation, spawnPoint);
        InventoryManager.Instance.RemoveItem(this);
        EquipmentManager.Instance.Equip(this);
    }
}
public enum EquipmentSlot { Head, Chest, Legs, Feet, Weapon, Shield }