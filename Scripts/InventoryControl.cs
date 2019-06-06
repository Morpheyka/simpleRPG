using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryControl : MonoBehaviour
{
    private WeaponControl weaponControl;
    public Item sword;

    private void Start()
    {
        weaponControl = GetComponent<WeaponControl>();
        List<BaseStat> swordStats = new List<BaseStat>();
        swordStats.Add(new BaseStat(4, "Power", "Your power level."));
        sword = new Item(swordStats, "Sword");

        weaponControl.EquipWeapon(sword);
    }
}
