using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStat
{
    public List<int> StatsBonus { get; set; }

    public int BaseValue { get; set; }
    public int FinalValue { get; set; }
    public string StatDesc { get; set; }
    public string StatName { get; set; }
    public int BonusValue { get; set; }

    public BaseStat(int baseValue, string statName, string statDesc)
    {
        BaseValue = baseValue;
        StatName = statName;
        StatDesc = statDesc;
        StatsBonus = new List<int>();
    }

    public void AddBonusStat(int bonus)
    {
        StatsBonus.Add(bonus);
    }

    public void RemoveBonusStat(int bonus)
    {
        StatsBonus.Remove(StatsBonus.Find(x => x == bonus));
    }

    public int CalculatedStatValue()
    {
        FinalValue = 0;
        StatsBonus.ForEach(x => FinalValue += x);
        FinalValue += BaseValue;

        return FinalValue;
    }
}
