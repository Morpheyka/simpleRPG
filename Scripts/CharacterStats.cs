using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    public List<BaseStat> stats = new List<BaseStat>();
    public Slider hpBar;
    
    private void Start()
    {
        stats.Add(new BaseStat(3, "Power", "Your power level"));
        stats.Add(new BaseStat(10, "MaxHP", "Your maximum hit points"));
        stats.Add(new BaseStat(stats[StatsList.MaxHP].BaseValue, "CurrentHP", "Your current hit points"));

        CalculateHP();
        //Debug.Log(stats[Stats.Power].CalculatedStatValue());
    }   

    public void AddBonusStat(List<BaseStat> bonuses)
    {
        foreach(BaseStat bonus in bonuses)
        {
            stats.Find(x => x.StatName == bonus.StatName).AddBonusStat(bonus.BaseValue);
        }
    }

    public void CalculateHP()
    {
        float updateHP = stats[StatsList.CurHP].CalculatedStatValue() / stats[StatsList.MaxHP].CalculatedStatValue();
        hpBar.value = updateHP;
    }

    public void RemoveBonusStat(List<BaseStat> bonuses)
    {
        foreach (BaseStat bonus in bonuses)
        {
            stats.Find(x => x.StatName == bonus.StatName).RemoveBonusStat(bonus.BaseValue);
        }
    }
}
