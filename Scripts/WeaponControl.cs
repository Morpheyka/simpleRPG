using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponControl : MonoBehaviour
{
    public Transform weaponHold;
    public GameObject equippedWeapon { get; set; }
    CharacterStats charStats;

    private void Start()
    {
        charStats = GetComponent<CharacterStats>();
    }

    public void EquipWeapon(Item itemToEquip)
    {
        if(equippedWeapon != null)
        {
            charStats.RemoveBonusStat(equippedWeapon.GetComponent<IWeapon>().Stats);
            Destroy(weaponHold.transform.GetChild(0).gameObject);
        }

        equippedWeapon = (GameObject)Instantiate(Resources.Load<GameObject>("Weapons/" + itemToEquip.ObjectSlug),
            weaponHold.position, weaponHold.rotation);
        equippedWeapon.transform.parent = weaponHold;
        equippedWeapon.GetComponent<IWeapon>().Stats = itemToEquip.Stats;
        charStats.AddBonusStat(itemToEquip.Stats);
        Debug.Log("Char stats = " + charStats.stats[StatsList.Power].CalculatedStatValue());
        Debug.Log("Weapon stats = " + equippedWeapon.GetComponent<IWeapon>().Stats[StatsList.Power].CalculatedStatValue());
    }

    public void Attack()
    {
        equippedWeapon.GetComponent<IWeapon>().PerformAttack();
    }
}
